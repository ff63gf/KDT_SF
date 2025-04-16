#include <iostream>
#include <fstream>
#include <string> // getline�Լ��� ����ϱ� ���� include

using std::cout;
using std::cin;
using std::endl;
using std::string;

int main() {

	std::ifstream file; // ������ ���� ���� ����
	// ���Ϸ� ���� ��� �͵��� ������ͼ� ���α׷��� �Է��� �� �ְ� �����ִ� Ŭ����(file -> program)
	
	file.open("test_file.txt"); // test_file�̶�� ���� ����

	if (file.fail()) {
		cout << "���� ����" << endl;
		return -1; // c++ main�Լ����� 0�� �ƴ� �ٸ� ���ڸ� ��ȯ�ϸ� ������ �ǹ��ϸ�, ���α׷� ����
	}

	string str, str2, line;

	// file >> str; // file�� ������ str�� ����. (��, ���Ⱑ ������ �������� �о ������!)
	file >> str >> str2;
	cout << str << " " << str2 << endl;

	while (file >> str >> str2) {
		cout << str << " " << str2 << endl;
	}

	// �� �پ� ����ϱ�
	//while (std::getline(file, line)) { // getline() file�� ������ �� �پ� �о��
	//	cout << line << endl;
	//}

	file.close(); // file�� ����.

	return 0;
}