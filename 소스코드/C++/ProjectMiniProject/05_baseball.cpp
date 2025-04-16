#include <iostream>
#include <ctime>

using namespace std;

int main() {
    cout << "�߱� ����" << endl;

    const int num_size = 3;
    int random_num[num_size] = {};

    int index = 0;
    while (index < num_size) {
        bool is_dup = false;
        int num = std::rand() % 9 + 1;
        for (int i = 0; i < index; i++) {
            if (random_num[i] == num) {
                is_dup = true;
                break;
            }
        }
        if (!is_dup) {
            random_num[index] = num;
            index++;
        }
    }

    int strike = 0, ball = 0;
    int input[num_size] = {};
    int count = 0;
    bool theEnd = false;

    while (true) {
        
        cout << "1 ~ 9 ������ ���� 3���� �Է� �Ͻÿ� (�̿��� ����: ����)" << endl;
        for (int i = 0; i < num_size; i++) {
            cin >> input[i];
            if (input[i] > 9 || input[i] < 1) {
                theEnd = true;
                break;
            }
        }

        if (theEnd) {
            cout << "������ �����Ͽ����ϴ�." << endl;
            break;
        }


        for (int i = 0; i < num_size; i++) {

            for (int j = 0; j < num_size; j++) {

                if (random_num[i] == input[j]) {

                    if (i == j) {
                        strike++;
                    }
                    else {
                        ball++;
                    }
                }

            }
        }

        count++;

        if (strike == 3) {
            cout << count << "�� ���� ������ϴ�." << endl;
            break;
        }
        else {
            cout << "Strike : " << strike << "\tBall : " << ball << endl;
            strike = 0;
            ball = 0;
        }

    }

    return 0;
}