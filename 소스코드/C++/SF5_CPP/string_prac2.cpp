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
		cout << "�� ���� ���ڸ� �Է����ּ��� : ";
		cin >> str1 >> str2;

		bool isNum = true;

		if (CheckNum(str1) && CheckNum(str2))
		{
			cout << str1 + str2 << " " << stoi(str1) + stoi(str2) << endl;
		}
		else
		{
			cout << "���ڰ� �ƴմϴ�. �ٽ� �Է����ּ���." << endl;
		}
	}

	return 0;
}