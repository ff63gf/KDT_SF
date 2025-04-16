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

	srand(time(NULL)); // 시드지정
	int random_number;

	int idx = 0;
	while(true)
	{ 
		random_number = rand();

		// 0 ~ 44 값이 아닌 1 ~ 45가 오도록
		pick_num.push_back((random_number % 45) + 1);

		// unique() 함수를 사용하여 앞에서 부터 중복없이 정렬 후 
		// 뒤에 있는 중복 요소들을 삭제
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