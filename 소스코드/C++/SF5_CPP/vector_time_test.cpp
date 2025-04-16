#include <iostream>
#include <vector>
#include <ctime>

using namespace std;

int main()
{
	int count = 100000000;
	clock_t start, finish;
	double duration;

	vector<int> test_vec1(1);
	vector<int> test_vec2(1);

	
	start = clock();

	for (int i = 0; i < count; i++)
	{
		test_vec1.push_back(i + 1);
	}

	finish = clock();

	duration = (double)(finish - start);

	cout << "push_back() : " << duration << "msec" << endl;


	start = clock();

	test_vec2.reserve(count);

	for (int i = 0; i < count; i++)
	{
		test_vec2.push_back(i + 1);
	}

	finish = clock();

	duration = (double)(finish - start);

	cout << "reserve() : " << duration << "msec" << endl;



	return 0;
}