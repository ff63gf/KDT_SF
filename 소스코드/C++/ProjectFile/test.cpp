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
	//}//파일 안으로 출력해라 이느낌 콘솔출력X

	ifstream input_file;
	ofstream out_file;

	//out_file.open("member.txt");
	//string str;
	//string storige = "";
	//cout << "3명의 회원에 대한 이름 비밀번호를 순차적으로 입력하세요.\n";
	//for (int i = 0; i < 3; i++) {
	//	cout << i + 1 << "번째 회원 : ";
	//	getline(cin, str);
	//	storige += str + '\n';
	//}
	//out_file << storige; //저장된 문자열을 파일에 출력하기!
	//out_file.close();

	cout << "---------회원 명부 파일 읽기---------\n";

	string line;
	input_file.open("member.txt"); // 파일에 들어있는 문자열을 꺼내온다.

	while (getline(input_file, line)) { // 한줄에 들어있는 문자열을 하나씩 출력해서 다 출력하면 빠져나온다.
		cout << line << '\n';
	}

	input_file.clear();
	input_file.seekg(0, ios::beg);

	while (getline(input_file, line)) { // 한줄에 들어있는 문자열을 하나씩 출력해서 다 출력하면 빠져나온다.
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
			cout << "find함수->" << check_name << ' ' << check_pw << '\n';
			if (check_name != -1 && check_pw != -1) {
				cout << "로그인성공!\n"; flag = 0; break;
			}
		}
		if (flag == 1) cout << "로그인실패! 다시입력해주세요ㅠㅠ\n";
		input_file.clear();
		input_file.seekg(0, ios::beg);
	}
	input_file.close();


}