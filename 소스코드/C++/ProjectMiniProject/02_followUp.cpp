//�����ձ� ����

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
		cout << "���� �ܾ �Է��ϼ��� : ";
		cin >> word;

		char first = word[0];

		if (check_time(start)) {
			cout << "Ÿ�� ����!\n\n";
			break;
		}
		else if (first == beforeWord) {
			count++;
			int n = word.size();
			beforeWord = word[n - 1];

			line = line + connect + word;
		}
		else {
			cout << "�߸��� �Է��Դϴ�. " << endl;
		}

		cout << endl;
	}

	cout << "���� ����! " << endl;
	cout << "�� �Է��� �ܾ� ���� : " << count << endl;

}