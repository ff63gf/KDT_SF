//끝말잇기 게임

#include <iostream>
#include <ctime>
using namespace std;

bool check_time(clock_t start_time) {
	clock_t end = clock();
	if ((end - start_time) / CLOCKS_PER_SEC > 20) {
		return true;
	}
	return false;
}

int main(void) {
	std::string line = "airplane";
	string connect = "->";
	int count = 0;

	int n = line.size();
	char beforeWord = line[n-1];

	clock_t start = clock();

	string strTemp;

	while (true) {
		if (check_time(start)) break;

		cout << line << endl;

		string word;
		cout << "다음 단어를 입력하세요 : ";
		cin >> word;

		char first = word[0];

		if (check_time(start)) {
			cout << "타임 오버!\n\n";
			break;
		}
		else if (first == beforeWord) {
			count++;
			int n = word.size();
			beforeWord = word[n - 1];

			line = line + connect + word;
		}
		else {
			cout << "잘못된 입력입니다. " << endl;
		}

		cout << endl;
	}

	cout << "게임 종료! " << endl;
	cout << "총 입력한 단어 개수 : " << count << endl;

}