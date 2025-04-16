#include <iostream>
#include <cstdlib>
#include <ctime>
#include <vector>
#include <algorithm>

#define PICK_COUNT 6

using namespace std;


int main()
{
	vector<int> pick_num;

	srand(time(NULL)); // �õ�����
	int random_number;

	int idx = 0;
	while(true)
	{ 
		random_number = rand();

		// 0 ~ 44 ���� �ƴ� 1 ~ 45�� ������
		pick_num.push_back((random_number % 45) + 1);

		// unique() �Լ��� ����Ͽ� �տ��� ���� �ߺ����� ���� �� 
		// �ڿ� �ִ� �ߺ� ��ҵ��� ����
		pick_num.erase(unique(pick_num.begin(), pick_num.end()), pick_num.end());

		if (pick_num.size() == PICK_COUNT)
		{
			break;
		}
	}

	for (int i = 0; i < PICK_COUNT; i++)
	{
		cout << pick_num[i] << endl;
	}

}