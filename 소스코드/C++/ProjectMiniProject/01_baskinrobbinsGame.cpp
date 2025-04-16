//배스킨라빈스 31게임

#include <iostream>
#include <chrono>
using namespace std;

void switch_turn(string &turn) {
	if (turn == "사용자") turn = "컴퓨터";
	else turn = "사용자";
}

int main(void) {

	srand((unsigned int)time(NULL));

	int nowNumber = 0;
	bool isContinue = true;
	string turn = "사용자";

	while (isContinue) {
		int num = 0;

		if (turn == "사용자") {
			cout << "개수를 입력하세요: ";
			cin >> num;
			if (num < 1 || num > 3) {
				cout << "1~3 사이의 수를 입력하세요." << endl;
				continue;
			}
		}
		else {
			num = rand() % 3 + 1;
		}

		cout << turn << "가 부른 숫자! " << endl;
		
		switch_turn(turn);

		for (int i = 0; i < num; i++) {
			nowNumber++;
			cout << nowNumber << endl;
			if (nowNumber == 31) {
				cout << "게임 종료! "<< turn << "의 승리입니다. " << endl;
				isContinue = false;
				break;
			}
		}

		cout << endl;

	}
}