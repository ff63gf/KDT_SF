#include <iostream>
#include <string>

using namespace std;


// isNum : return true
// isNotNum : return false
bool CheckNum(string str)
{
	for (int i = 0; i < str.length(); i++)
	{
		if (isdigit(str[i]) == 0)
		{
			return false;
		}
	}
}


int main()
{
	string str1, str2;

	while (true)
	{
		cout << "두 개의 숫자를 입력해주세요 : ";
		cin >> str1 >> str2;

		bool isNum = true;

		if (CheckNum(str1) && CheckNum(str2))
		{
			cout << str1 + str2 << " " << stoi(str1) + stoi(str2) << endl;
		}
		else
		{
			cout << "숫자가 아닙니다. 다시 입력해주세요." << endl;
		}
	}

	return 0;
}