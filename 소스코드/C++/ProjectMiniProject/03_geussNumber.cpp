//���� ���� ���߱� ����

#include <iostream>
#include <ctime>
using namespace std;

int main(void) {

	srand((unsigned int)time(NULL));

	int correctNumbers[6];
	int userNumbers[6];

	int correctCount = 0;

	for (int i = 0; i < 6; i++) {
		correctNumbers[i] = 0;
	}

	for (int i = 0; i < 6; i++) {
		userNumbers[i] = 0;
	}

	int count = 0;
	while (count < 6) {
		bool is_dup = false;
		int num = std::rand() % 25 + 1;
		for (int i = 0; i < count; i++) {
			if (correctNumbers[i] == num) {
				is_dup = true;
				break;
			}
		}
		if (!is_dup) {
			correctNumbers[count] = num;
			count++;
		}
	}

	cout << "���ڴ� 1 ~ 25������ ���ڸ� �Է��� �� �ֽ��ϴ�. " << endl;
	count = 0;
	while (count < 6) {
		int tempInput;
		cout << count + 1 << "��° ��ȣ�� �Է��ϼ���: ";
		cin >> tempInput;
		if (tempInput > 25 || tempInput < 1) {
			cout << "�߸��� �����Դϴ�. �ٽ� �Է����ּ���. " << endl;
		}
		else {
			bool is_dup = false;
			for (int j = 0; j < 6; j++) {
				if (tempInput == userNumbers[j]) {
					cout << "�̹� �Էµ� �����Դϴ�. " << endl;
					is_dup = true;
					break;
				}
			}
			if (!is_dup) {
				userNumbers[count++] = tempInput;
			}
		}
	}

	

	for (int i = 0; i < 6; i++) {
		for (int j = 0; j < 6; j++) {
			if (correctNumbers[i] == userNumbers[j]) {
				correctCount++;
				break;
			}
		}
	}

	cout << "--------------------------" << endl;
	cout << "��÷��ȣ ����! " << endl;
	for (int i = 0; i < 6; i++) {
		cout << correctNumbers[i] << " ";
	}
	cout << endl;
	cout << "1 ~ 7����� ����� ���� �� �ֽ��ϴ�." << endl;
	cout << "��� : " << 7 - correctCount << "���Դϴ�! " << endl;

	return 0;

}