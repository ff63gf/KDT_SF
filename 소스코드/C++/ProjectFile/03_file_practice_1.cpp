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
	cout << "3���� ȸ���� ���� �̸� ��й�ȣ�� ���������� �Է��ϼ���.\n";
	string member_info = "";
	for (int i = 0; i < 3; i++) {
		cout << i + 1 << "��° ȸ�� : ";
		string name, pw;
		cin >> name >> pw;
		member_info = member_info + name + " " + pw + "\n";

		//string info;
		//getline(cin, info); //�� �پ� �Է� ���� �� ����. (���͸� �Է��ϱ� ������ ��� ���ڿ��� info�� ����)
		//member_info += info + "\n";
	}

	file << member_info;
	file.close();

	cout << endl;

	cout << "------------ȸ�� ��� ���� �б�------------\n";
	std::ifstream file_read("member.txt");
	if (file_read.fail()) {
		cout << "���� �б� ����";
		return -1;
	}

	string line;
	while (getline(file_read, line)) {
		cout << line << endl;
	}
	file_read.close();
	
	return 0;
}