//�轺Ų��� 31����

#include <iostream>
#include <chrono>
using namespace std;

void switch_turn(string &turn) {
	if (turn == "�����") turn = "��ǻ��";
	else turn = "�����";
}

int main(void) {

	srand((unsigned int)time(NULL));

	int nowNumber = 0;
	bool isContinue = true;
	string turn = "�����";

	while (isContinue) {
		int num = 0;

		if (turn == "�����") {
			cout << "������ �Է��ϼ���: ";
			cin >> num;
			if (num < 1 || num > 3) {
				cout << "1~3 ������ ���� �Է��ϼ���." << endl;
				continue;
			}
		}
		else {
			num = rand() % 3 + 1;
		}

		cout << turn << "�� �θ� ����! " << endl;
		
		switch_turn(turn);

		for (int i = 0; i < num; i++) {
			nowNumber++;
			cout << nowNumber << endl;
			if (nowNumber == 31) {
				cout << "���� ����! "<< turn << "�� �¸��Դϴ�. " << endl;
				isContinue = false;
				break;
			}
		}

		cout << endl;

	}
}