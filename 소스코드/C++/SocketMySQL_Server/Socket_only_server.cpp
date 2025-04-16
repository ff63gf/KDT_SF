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

	// WSAStartup(): Winsoc을 초기화 하는 함수
	// MAKEWORD(2, 2)는 Winsock의 2.2 버전을 사용하겠다는 의미
	// 실행에 성공하면 0을, 실패하면 0이 아닌 값을 반환
	int code = WSAStartup(MAKEWORD(2, 2), &wsa);

	// 0이 반환됐다는 것은 Winsock 사용준비가 되었다는 뜻
	if (code == 0)
	{
		server_init();

		std::thread client_threads[MAX_CLIENT];
		for (int i = 0; i < MAX_CLIENT; i++)
		{
			client_threads[i] = std::thread(add_client);
		}

		// 들어오는 메세지를 돌려보내는 역할?
		while (true)
		{
			string text, message = "";

			// 어디로부터 getline 되는 것인가, 사용자 입력은 아닐테고
			// 사용자 입력이 맞다, 서버랑 서로 주고받는 구조
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
	else // WSAStartup() 작동 실패
	{
		cout << "프로그램 종료. (Error Code: " << code << ")";
	}

	WSACleanup();

	return 0;
}

// 서버 초기화
void server_init()
{
	// PF_INET: IPv4 주소 영역 사용
	// SOCK_STREAM: 연결형 서비스, TCP 프로토콜 대응
	// IPPROTO_TCP: TCP를 사용(PF_INET, SOCK_STREAM과 함께 사용)
	server_socket.socket = socket(PF_INET, SOCK_STREAM, IPPROTO_TCP);

	// 각 define 값들이 의미하는 것은?
	SOCKADDR_IN server_addr = {};
	server_addr.sin_family = AF_INET;
	
	// htons(): host to network, 입력값이 short
	// 네트워크에서는 Big-endian으로 변환 (비트 기준 큰 단위부터 저장)
	// 호스트에서는 Little-endian으로 변환 (비트 기준 작은 단위부터 저장)
	server_addr.sin_port = htons(7777);

	// htonl(): htons()와 같으나 입력값이 long
	// INADDR_ANY: localhost, 127.0.0.1을 의미
	server_addr.sin_addr.s_addr = htonl(INADDR_ANY); 

	// 생성된 소켓에 주소 부여, 지금은 TCP 방식이므로 IPv4 부여
	bind(server_socket.socket, (sockaddr*)&server_addr, sizeof(server_addr));

	// 소켓 활성화, 이제부터 클라이언트 연결 대기 상태에 들어감
	// SOMAXCONN (backlog 입력값) : 시스템이 허용하는 가능한 많은 클라이언트 수신 대기열을 할당
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

	// accept(): 서버측에서 클라이언트의 요청을 수락
	// AOCKADDR_IN addr을 통해 client의 정보를 받아옴
	new_client.socket = accept(server_socket.socket, (sockaddr*)&addr, &addrsize);
	
	// client 정보가 들어있는 소켓을 수신
	recv(new_client.socket, buffer, MAX_BUFF_SIZE, 0);
	new_client.user = string(buffer);

	string message = "[시스템] " + new_client.user + " 님이 입장했습니다.";
	cout << message << endl;
	// 소켓으로 수신된 client 정보를 벡터에 저장
	socket_list.push_back(new_client);

	// client가 보내는 소켓을 지속적으로 수신할 스레드 생성
	std::thread recv_thread(recv_msg, client_count);

	client_count++;
	cout << "[시스템] 현재 접속자 수: " << client_count << "명" << endl;
	send_msg(message.c_str());

	recv_thread.join();
}

void send_msg(const char* message)
{
	for (int i = 0; i < client_count; i++)
	{
		// 소켓을 통해 char* 값을 전달
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
		
		// recv(): 소켓으로 char* 형 값을 수신하고, 수신된 크기를 바이트 단위로 리턴
		if (recv(socket_list[idx].socket, buffer, MAX_BUFF_SIZE, 0) > 0) // 뭔가 받은 것이 있다면
		{
			message = socket_list[idx].user + ": " + buffer;
			cout << message << endl;
			send_msg(message.c_str());
		}
		else // 소켓으로 수신된 값이 없다면 = client 연결 종료
		{
			message = "[시스템] " + socket_list[idx].user + "님이 퇴장했습니다.";
			cout << message << endl;
			send_msg(message.c_str());
			del_client(idx); // 클라이언트 소켓 연결 종료
			return;
		}
	}
}

void del_client(int idx)
{
	closesocket(socket_list[idx].socket);
	client_count--;
}
