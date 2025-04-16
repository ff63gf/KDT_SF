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

	// WSAStartup(): Winsock을 초기화하는 함수 
	// MAKEWORD(2, 2)는 Winsock의 2.2 버전을 사용하겠다는 의미 
	// 0을 반환했다는 것은 Winsock 사용 준비 완료
	// 오류 발생 시 0이 아닌 다른 값을 반환
	int code = WSAStartup(MAKEWORD(2, 2), &wsa);

	if (code == 0)
	{
		cout << "사용할 닉네임 입력 >> ";
		cin >> my_nickname;

		// PF_INET: IPv4 주소 영역 사용
		// SOCK_STREAM: 연결형 서비스, TCP 프로토콜 대응
		// IPPROTO_TCP: TCP를 사용(PF_INET, SOCK_STREAM과 함께 사용)
		client_socket = socket(PF_INET, SOCK_STREAM, IPPROTO_TCP);

		SOCKADDR_IN client_addr = {};
		client_addr.sin_family = AF_INET;

		// htons(): host to network short
		// 네트워크에서는 Big-endian (비트 기준 큰 단위부터 저장)
		// 호스트에서는 Little-endian (비트 기준 작은 단위부터 저장)
		client_addr.sin_port = htons(7777); 

		// InetPton(): IPv4 또는 IPv6 주소를 이진 형식(byte)으로 변환
		InetPton(AF_INET, TEXT("127.0.0.1"), &client_addr.sin_addr);

		while (true)
		{
			// connect(): 서버와 연결 성공 시 0을 반환
			// SOCKADDR_IN client_addr에 있는 IPv4 정보를 바탕으로 서버와 연결
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

		// 소켓을 통해 수신된 데이터의 크기가 0보다 크다면
		if (recv(client_socket, buffer, MAX_BUFF_SIZE, 0) > 0)
		{
			message = buffer;
			std::stringstream ss(message); // 문자열 공백 제거를 위해 스트림으로 변환
			string user;
			ss >> user; // 공백 제거 후 user로 복사

			// 내가 보낸 메시지가 아닐 경우 메시지 출력
			if (user != my_nickname)
			{
				cout << buffer << endl;
			}				
		}
		else // recv()로 수신한 소켓이 0 이거나 더 작을 경우 = 연결 끊김
		{
			cout << "Server OFF" << endl;
			return -1;
		}
	}
}