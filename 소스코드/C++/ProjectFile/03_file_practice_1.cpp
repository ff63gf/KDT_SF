#include <iostream>
#include <fstream>
#include <string>

using std::cout;
using std::cin;
using std::endl;
using std::getline;
using std::string;

int main() {
	
	std::ofstream file("member.txt");
	cout << "3명의 회원에 대한 이름 비밀번호를 순차적으로 입력하세요.\n";
	string member_info = "";
	for (int i = 0; i < 3; i++) {
		cout << i + 1 << "번째 회원 : ";
		string name, pw;
		cin >> name >> pw;
		member_info = member_info + name + " " + pw + "\n";

		//string info;
		//getline(cin, info); //한 줄씩 입력 받을 수 있음. (엔터를 입력하기 전까지 모든 문자열을 info에 저장)
		//member_info += info + "\n";
	}

	file << member_info;
	file.close();

	cout << endl;

	cout << "------------회원 명부 파일 읽기------------\n";
	std::ifstream file_read("member.txt");
	if (file_read.fail()) {
		cout << "파일 읽기 실패";
		return -1;
	}

	string line;
	while (getline(file_read, line)) {
		cout << line << endl;
	}
	file_read.close();
	
	return 0;
}