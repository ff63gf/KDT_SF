#include <iostream>
#include <fstream>
#include <string> // getline함수를 사용하기 위해 include

using std::cout;
using std::cin;
using std::endl;
using std::string;

int main() {

	std::ifstream file; // 파일을 담을 변수 선언
	// 파일로 부터 어떠한 것들을 가지고와서 프로그램에 입력할 수 있게 도와주는 클래스(file -> program)
	
	file.open("test_file.txt"); // test_file이라는 파일 열기

	if (file.fail()) {
		cout << "파일 없음" << endl;
		return -1; // c++ main함수에서 0이 아닌 다른 숫자를 반환하면 에러를 의미하며, 프로그램 종료
	}

	string str, str2, line;

	// file >> str; // file의 내용을 str에 저장. (단, 띄어쓰기가 나오기 전까지만 읽어서 저장함!)
	file >> str >> str2;
	cout << str << " " << str2 << endl;

	while (file >> str >> str2) {
		cout << str << " " << str2 << endl;
	}

	// 한 줄씩 출력하기
	//while (std::getline(file, line)) { // getline() file의 내용을 한 줄씩 읽어옴
	//	cout << line << endl;
	//}

	file.close(); // file을 닫음.

	return 0;
}