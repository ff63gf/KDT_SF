#include<iostream>
#include<fstream>
#include<string>
#include<vector>
using namespace std;

int  main() {
	//ifstream file("hello.txt");
	//ofstream files("Output.txt");
	//string str;
	//vector<string> v;
	//while (getline(file, str)) {
	//	v.push_back(str);
	//}

	//for (vector<string>::reverse_iterator it = v.rbegin(); it != v.rend(); ++it) {
	//	files << *it+'\n';
	//}//���� ������ ����ض� �̴��� �ܼ����X

	ifstream input_file;
	ofstream out_file;

	//out_file.open("member.txt");
	//string str;
	//string storige = "";
	//cout << "3���� ȸ���� ���� �̸� ��й�ȣ�� ���������� �Է��ϼ���.\n";
	//for (int i = 0; i < 3; i++) {
	//	cout << i + 1 << "��° ȸ�� : ";
	//	getline(cin, str);
	//	storige += str + '\n';
	//}
	//out_file << storige; //����� ���ڿ��� ���Ͽ� ����ϱ�!
	//out_file.close();

	cout << "---------ȸ�� ��� ���� �б�---------\n";

	string line;
	input_file.open("member.txt"); // ���Ͽ� ����ִ� ���ڿ��� �����´�.

	while (getline(input_file, line)) { // ���ٿ� ����ִ� ���ڿ��� �ϳ��� ����ؼ� �� ����ϸ� �������´�.
		cout << line << '\n';
	}

	input_file.clear();
	input_file.seekg(0, ios::beg);

	while (getline(input_file, line)) { // ���ٿ� ����ִ� ���ڿ��� �ϳ��� ����ؼ� �� ����ϸ� �������´�.
		cout << line << '\n';
	}

	cout << "\n---------------login----------------\n";

	string name, pw;
	int check_name, check_pw, flag = 1;

	while (flag) {
		cout << "name: ";
		cin >> name;
		cout << "pw: ";
		cin >> pw;

		while (getline(input_file, line)) {
			check_name = line.find(name);
			check_pw = line.find(pw);
			cout << "find�Լ�->" << check_name << ' ' << check_pw << '\n';
			if (check_name != -1 && check_pw != -1) {
				cout << "�α��μ���!\n"; flag = 0; break;
			}
		}
		if (flag == 1) cout << "�α��ν���! �ٽ��Է����ּ���Ф�\n";
		input_file.clear();
		input_file.seekg(0, ios::beg);
	}
	input_file.close();


}