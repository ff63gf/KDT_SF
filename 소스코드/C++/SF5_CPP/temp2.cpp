#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <sstream> //???? split??

using namespace std;

int ConfirmPW(string input);
void NoticeLogin(bool nameCheck, bool pwCheck);
int CofirmTel(string input);

int main()
{
	string line, name, pw, tel, name_input, pw_input, tel_input;
	bool nameCheck, pwCheck;
	vector <string> memberVector;

	cout << "* ?¥á??? ???? ?? ?????? ???? *" << endl
		<< "( quit ??? ?? ???? )" << endl;

	ifstream member_file("member.txt");

	while (getline(member_file, line))
	{
		memberVector.push_back(line);
	}

	member_file.close();

	while (1)
	{
		nameCheck = false;
		pwCheck = false;

		cout << endl << "????? ????????: ";
		cin >> name_input;

		if (name_input == "quit")
		{
			return 0;
		}

		cout << "????? ????????: ";
		cin >> pw_input;

		while (ConfirmPW(pw_input) > 0)
		{
			cout << endl << "[?????]" << endl
				<< "????? ????????: ";
			cin >> pw_input;
		}


		for (string line : memberVector)
		{
			stringstream ss(line);
			ss >> name >> pw;

			//cout << "??¥ï?: " << name << " " << pw << endl;

			if (name_input == name)
			{
				nameCheck = true;

				if (pw_input == pw)
				{
					pwCheck = true;
					break;
				}
			}
		}

		NoticeLogin(nameCheck, pwCheck);

		// ?¥á??? ???? ??
		if (nameCheck == true && pwCheck == true)
		{
			cout << endl << "???????? ??????????: ";
			cin >> tel_input;

			while (CofirmTel(tel_input) > 0)
			{
				cout << endl << "[?????]" << endl
					<< "???????? ??????????: ";
				cin >> tel_input;
			}

			ifstream read_file("member_tel.txt");

			int type = 0;
			bool breakCheck = false;
			vector <string> telVector;

			if (read_file.is_open())
			{
				while (getline(read_file, line))
				{
					telVector.push_back(line);

					if (breakCheck == false)
					{
						stringstream ss(line);
						ss >> name >> tel;

						if (name == name_input) // member_tel.txt ???? ?? ?¥á??? ?? ????? ??? ????
						{
							// ??? ??? ?? ????
							type = 1;
							breakCheck = true;
						}
						else // ????? ??? ???? x
						{
							// ????? ??? ?????? ???
							type = 2;
						}
					}
				}
			}
			else
			{
				type = 2;
			}

			read_file.close();

			ofstream tel_file("member_tel.txt");

			switch (type)
			{
			case 1:
				for (int i = 0; i < telVector.size(); i++)
				{
					stringstream ss(telVector[i]);
					ss >> name >> tel;

					if (name == name_input) // ???? ??
					{
						telVector[i] = name + " " + tel_input; // ???????? ????
					}
				}
				break;
			case 2:
				telVector.push_back(name_input + " " + tel_input);
				break;
			}

			for (string line : telVector) // ????? ???
			{
				//cout << line << endl;
				tel_file << line << endl;
			}

			tel_file.close();
		}
	}
}

int ConfirmPW(string input)
{
	if (input.size() < 6 || input.size() > 17)
	{
		cout << endl << "- ??¬Û???? 6~17 ???????:)" << endl;
		return 1;
	}
	// ??? ????? 2,3,4 ????????? ??? ?? ??

	return 0;
}

void NoticeLogin(bool nameCheck, bool pwCheck)
{
	if (nameCheck == true && pwCheck == true)
	{
		cout << endl << "?¥á??? ????" << endl;
	}
	else
	{
		cout << endl << "?¥á??? ????" << endl;

		if (nameCheck == false)
		{
			cout << endl << "- ???????? ??? ????? ???????:)" << endl;
		}
		else if (pwCheck == false)
		{
			cout << endl << "- ??¬Û???? ??????? ??????:)" << endl;
		}
	}
}

int CofirmTel(string input)
{
	vector <string> telNum;
	string num;
	stringstream ss(input);

	while (getline(ss, num, '-'))
	{
		telNum.push_back(num);
	}

	if (telNum.size() != 3)
	{
		return 1; // ?????? ?????? ??? xxx-xxxx-xxxx
	}
	else if (telNum[0] != "010")
	{
		return 2; // 010???? ???????? ????
	}
	else if (telNum[1].size() != 4 || telNum[2].size() != 4)
	{
		return 3; // ?????? ??????? ?????
	}
	return 0;
}