#pragma comment(lib, "ws2_32.lib")

#include <WinSock2.h>
#include <string>
#include <iostream>
#include <thread>
#include <vector>

#define MAX_BUFF_SIZE 1024
#define MAX_CLIENT 3

using std::cout;
using std::cin;
using std::endl;
using std::string;
using std::vector;

struct SOCKET_INFO
{
	SOCKET socket;
	string user;
};

vector<SOCKET_INFO> socket_list;
SOCKET_INFO server_socket;

int client_count = 0;

void server_init();
void add_client();
void send_msg(const char* message);
void recv_msg(int idx);
void del_client(int idx);

int main()
{
	// WSA: Windows Sockets API 
	WSADATA wsa;

	// WSAStartup(): Winsoc�� �ʱ�ȭ �ϴ� �Լ�
	// MAKEWORD(2, 2)�� Winsock�� 2.2 ������ ����ϰڴٴ� �ǹ�
	// ���࿡ �����ϸ� 0��, �����ϸ� 0�� �ƴ� ���� ��ȯ
	int code = WSAStartup(MAKEWORD(2, 2), &wsa);

	// 0�� ��ȯ�ƴٴ� ���� Winsock ����غ� �Ǿ��ٴ� ��
	if (code == 0)
	{
		server_init();

		std::thread client_threads[MAX_CLIENT];
		for (int i = 0; i < MAX_CLIENT; i++)
		{
			client_threads[i] = std::thread(add_client);
		}

		// ������ �޼����� ���������� ����?
		while (true)
		{
			string text, message = "";

			// ���κ��� getline �Ǵ� ���ΰ�, ����� �Է��� �ƴ��װ�
			// ����� �Է��� �´�, ������ ���� �ְ�޴� ����
			std::getline(cin, text);
			const char* buffer = text.c_str();

			message = server_socket.user + ": " + buffer;
			send_msg(message.c_str());
		}

		for (int i = 0; i < MAX_CLIENT; i++)
		{
			client_threads[i].join();
		}

		closesocket(server_socket.socket);
	}
	else // WSAStartup() �۵� ����
	{
		cout << "���α׷� ����. (Error Code: " << code << ")";
	}

	WSACleanup();

	return 0;
}

// ���� �ʱ�ȭ
void server_init()
{
	// PF_INET: IPv4 �ּ� ���� ���
	// SOCK_STREAM: ������ ����, TCP �������� ����
	// IPPROTO_TCP: TCP�� ���(PF_INET, SOCK_STREAM�� �Բ� ���)
	server_socket.socket = socket(PF_INET, SOCK_STREAM, IPPROTO_TCP);

	// �� define ������ �ǹ��ϴ� ����?
	SOCKADDR_IN server_addr = {};
	server_addr.sin_family = AF_INET;
	
	// htons(): host to network, �Է°��� short
	// ��Ʈ��ũ������ Big-endian���� ��ȯ (��Ʈ ���� ū �������� ����)
	// ȣ��Ʈ������ Little-endian���� ��ȯ (��Ʈ ���� ���� �������� ����)
	server_addr.sin_port = htons(7777);

	// htonl(): htons()�� ������ �Է°��� long
	// INADDR_ANY: localhost, 127.0.0.1�� �ǹ�
	server_addr.sin_addr.s_addr = htonl(INADDR_ANY); 

	// ������ ���Ͽ� �ּ� �ο�, ������ TCP ����̹Ƿ� IPv4 �ο�
	bind(server_socket.socket, (sockaddr*)&server_addr, sizeof(server_addr));

	// ���� Ȱ��ȭ, �������� Ŭ���̾�Ʈ ���� ��� ���¿� ��
	// SOMAXCONN (backlog �Է°�) : �ý����� ����ϴ� ������ ���� Ŭ���̾�Ʈ ���� ��⿭�� �Ҵ�
	listen(server_socket.socket, SOMAXCONN);

	server_socket.user = "server";

	cout << "Server ON" << endl;
}

void add_client()
{
	SOCKADDR_IN addr = {};
	int addrsize = sizeof(addr);
	char buffer[MAX_BUFF_SIZE] = { };

	ZeroMemory(&addr, addrsize);

	SOCKET_INFO new_client = {};

	// accept(): ���������� Ŭ���̾�Ʈ�� ��û�� ����
	// AOCKADDR_IN addr�� ���� client�� ������ �޾ƿ�
	new_client.socket = accept(server_socket.socket, (sockaddr*)&addr, &addrsize);
	
	// client ������ ����ִ� ������ ����
	recv(new_client.socket, buffer, MAX_BUFF_SIZE, 0);
	new_client.user = string(buffer);

	string message = "[�ý���] " + new_client.user + " ���� �����߽��ϴ�.";
	cout << message << endl;
	// �������� ���ŵ� client ������ ���Ϳ� ����
	socket_list.push_back(new_client);

	// client�� ������ ������ ���������� ������ ������ ����
	std::thread recv_thread(recv_msg, client_count);

	client_count++;
	cout << "[�ý���] ���� ������ ��: " << client_count << "��" << endl;
	send_msg(message.c_str());

	recv_thread.join();
}

void send_msg(const char* message)
{
	for (int i = 0; i < client_count; i++)
	{
		// ������ ���� char* ���� ����
		send(socket_list[i].socket, message, MAX_BUFF_SIZE, 0);
	}
}

void recv_msg(int idx)
{
	char buffer[MAX_BUFF_SIZE] = { };
	string message = "";

	while (1)
	{
		ZeroMemory(&buffer, MAX_BUFF_SIZE);
		
		// recv(): �������� char* �� ���� �����ϰ�, ���ŵ� ũ�⸦ ����Ʈ ������ ����
		if (recv(socket_list[idx].socket, buffer, MAX_BUFF_SIZE, 0) > 0) // ���� ���� ���� �ִٸ�
		{
			message = socket_list[idx].user + ": " + buffer;
			cout << message << endl;
			send_msg(message.c_str());
		}
		else // �������� ���ŵ� ���� ���ٸ� = client ���� ����
		{
			message = "[�ý���] " + socket_list[idx].user + "���� �����߽��ϴ�.";
			cout << message << endl;
			send_msg(message.c_str());
			del_client(idx); // Ŭ���̾�Ʈ ���� ���� ����
			return;
		}
	}
}

void del_client(int idx)
{
	closesocket(socket_list[idx].socket);
	client_count--;
}
