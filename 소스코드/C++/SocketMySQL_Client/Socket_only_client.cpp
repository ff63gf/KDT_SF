#pragma comment(lib, "ws2_32.lib")

#include <WinSock2.h>
#include <WS2tcpip.h>
#include <string>
#include <sstream>
#include <iostream>
#include <thread>

#define MAX_BUFF_SIZE 1024

using std::cout;
using std::cin;
using std::endl;
using std::string;

SOCKET client_socket;
string my_nickname;

int chat_recv();

int main()
{
	// WSA: Windows Socket API
	WSADATA wsa;

	// WSAStartup(): Winsock�� �ʱ�ȭ�ϴ� �Լ� 
	// MAKEWORD(2, 2)�� Winsock�� 2.2 ������ ����ϰڴٴ� �ǹ� 
	// 0�� ��ȯ�ߴٴ� ���� Winsock ��� �غ� �Ϸ�
	// ���� �߻� �� 0�� �ƴ� �ٸ� ���� ��ȯ
	int code = WSAStartup(MAKEWORD(2, 2), &wsa);

	if (code == 0)
	{
		cout << "����� �г��� �Է� >> ";
		cin >> my_nickname;

		// PF_INET: IPv4 �ּ� ���� ���
		// SOCK_STREAM: ������ ����, TCP �������� ����
		// IPPROTO_TCP: TCP�� ���(PF_INET, SOCK_STREAM�� �Բ� ���)
		client_socket = socket(PF_INET, SOCK_STREAM, IPPROTO_TCP);

		SOCKADDR_IN client_addr = {};
		client_addr.sin_family = AF_INET;

		// htons(): host to network short
		// ��Ʈ��ũ������ Big-endian (��Ʈ ���� ū �������� ����)
		// ȣ��Ʈ������ Little-endian (��Ʈ ���� ���� �������� ����)
		client_addr.sin_port = htons(7777); 

		// InetPton(): IPv4 �Ǵ� IPv6 �ּҸ� ���� ����(byte)���� ��ȯ
		InetPton(AF_INET, TEXT("127.0.0.1"), &client_addr.sin_addr);

		while (true)
		{
			// connect(): ������ ���� ���� �� 0�� ��ȯ
			// SOCKADDR_IN client_addr�� �ִ� IPv4 ������ �������� ������ ����
			if (connect(client_socket, (SOCKADDR*)&client_addr, sizeof(client_addr)) == 0)
			{
				cout << "Server Connect" << endl;
				send(client_socket, my_nickname.c_str(), my_nickname.length(), 0);
				break;
			} 
			cout << "Connecting..." << endl;
		}

		std::thread recv_thread(chat_recv);

		while (true)
		{
			string text;
			std::getline(cin, text);
			const char* buffer = text.c_str();
			send(client_socket, buffer, strlen(buffer), 0);
		}

		recv_thread.join();
		closesocket(client_socket);
	}

	WSACleanup();
	return 0;
}


int chat_recv()
{
	char buffer[MAX_BUFF_SIZE] = {};
	string message;

	while (true)
	{
		ZeroMemory(&buffer, MAX_BUFF_SIZE);

		// ������ ���� ���ŵ� �������� ũ�Ⱑ 0���� ũ�ٸ�
		if (recv(client_socket, buffer, MAX_BUFF_SIZE, 0) > 0)
		{
			message = buffer;
			std::stringstream ss(message); // ���ڿ� ���� ���Ÿ� ���� ��Ʈ������ ��ȯ
			string user;
			ss >> user; // ���� ���� �� user�� ����

			// ���� ���� �޽����� �ƴ� ��� �޽��� ���
			if (user != my_nickname)
			{
				cout << buffer << endl;
			}				
		}
		else // recv()�� ������ ������ 0 �̰ų� �� ���� ��� = ���� ����
		{
			cout << "Server OFF" << endl;
			return -1;
		}
	}
}