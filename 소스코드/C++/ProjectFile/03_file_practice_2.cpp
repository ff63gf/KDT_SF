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
	std::cout << "�̸��� �Է��ϼ���.";
	std::cin >> name;

	std::cout << "����� �Է��ϼ���.";
	std::cin >> pw;

	bool flag = false;
	while (member_file >> str1 >> str2) {
		if (name == str1 && pw == str2) {
			flag = true;
			break;
		}
	}

	if (flag) cout << "�α��� ����";
	else cout << "�α��� ����";

	member_file.close();

	return 0;
}