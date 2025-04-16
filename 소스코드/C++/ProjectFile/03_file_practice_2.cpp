#include <iostream>
#include <fstream>
#include <string>

using std::cout;
using std::cin;
using std::endl;
using std::getline;
using std::string;

int main() {
	std::ifstream member_file;
	std::string name, pw, str1, str2;
	member_file.open("member.txt");
	std::cout << "이름을 입력하세요.";
	std::cin >> name;

	std::cout << "비번을 입력하세요.";
	std::cin >> pw;

	bool flag = false;
	while (member_file >> str1 >> str2) {
		if (name == str1 && pw == str2) {
			flag = true;
			break;
		}
	}

	if (flag) cout << "로그인 성공";
	else cout << "로그인 실패";

	member_file.close();

	return 0;
}