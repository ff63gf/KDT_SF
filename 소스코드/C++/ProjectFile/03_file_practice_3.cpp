#include <iostream>
#include <fstream>
#include <string>

using std::cout;
using std::cin;
using std::endl;
using std::string;

bool checkFileOpen(std::ifstream& file) 
{
	if (file.fail()) return false;
	else return true;
}

bool checkFileOpen(std::ofstream& file) 
{
	if (file.fail()) 
	{
		cout << "파일 없음" << endl;
		return false;
	}
	else return true;
}

int main() 
{
	std::ifstream member_file;
	std::string name, pw, name_in, pw_in;

	member_file.open("member.txt");
	if (!checkFileOpen(member_file)) return -1;


	std::cout << "이름을 입력하세요. ";
	std::cin >> name_in;

	std::cout << "비번을 입력하세요. ";
	std::cin >> pw_in;

	bool flag = false; // 로그인 성공 여부를 담는 변수
	while (member_file >> name >> pw) 
	{
		if (name == name_in && pw == pw_in) 
		{
			flag = true;
			break;
		}
	}
	member_file.close();

	if (flag) 
	{
		std::string tel_in, tel;
		cout << "로그인 성공" << endl;
		cout << "전화번호를 입력하세요. ";
		cin >> tel_in;

		std::ifstream member_tel_file_r("member_tel.txt");
		std::string member_tel_temp = "";

		bool is_modify = false; // 기존 정보 수정 or 추가를 판단하는 변수
		if (!member_tel_file_r.fail()) 
		{
			while (member_tel_file_r >> name >> tel) 
			{
				std::string line = name + " ";
				if (name == name_in) 
				{
					line += tel_in;
					is_modify = true;
				}
				else line += tel;
				member_tel_temp += line + "\n";
			}
			member_tel_file_r.close();
		}

		std::ofstream member_tel_file_w;
		
		if (is_modify) 
		{
			member_tel_file_w.open("member_tel.txt");
			member_tel_file_w << member_tel_temp;
		}
		else 
		{
			member_tel_file_w.open("member_tel.txt", std::ios::app);
			member_tel_file_w << name_in + " " + tel_in + "\n";
		}
		
		member_tel_file_w.close();
	}
	else cout << "로그인 실패";

	return 0;
}