#include <iostream>

using namespace std;

class Character {
        string name;
        int level = 0;
        int item_num = 0;
    
    public:
        Character(string name) {
            this->name = name;
            cout << name << " 캐릭터가 생성 되었습니다.\n";
        }

        void setName(string name) {
            this->name = name;
            cout << "이름이 변경되었습니다.\n";
            cout << "new name : " << name << endl;
        }

        void level_up() {
            level++;
            cout << "level up!!\n";
            cout << "현재 레벨 : " << level << endl;
        }

        void item_up() {
            item_num++;
            cout << "아이템을 얻었습니다!\n";
            cout << "현재 아이템 개수 : " << item_num << endl;
        }

        void item_down() {
            item_num--;
            cout << "아이템을 사용했습니다!\n";
            cout << "현재 아이템 개수 : " << item_num << endl;
        }

        void printInfo() {
            cout << "이름 : " << name << endl;
            cout << "레벨 : " << level << endl;
            cout << "현재 아이템 개수 : " << item_num << endl;
        }
};

void printMenu()
{
    cout << endl << endl;
    cout << "----------액션 선택----------" << endl;
    cout << " 1. 이름 변경" << endl;
    cout << " 2. 레벨 업" << endl;
    cout << " 3. 아이템 습득" << endl;
    cout << " 4. 아이템 사용" << endl;
    cout << " 5. 상태 확인" << endl;
    cout << "----------------------------" << endl;
}


int main()
{
    char action;
    string name, new_name;

    cout << "캐릭터 이름을 입력해주세요 : ";
    cin >> name;

    Character c1(name);

    while (1) {
        printMenu();
        cout << "어떤 동작을 실행하시겠습니까? (0: 종료) ";
        cin >> action;
        cout << endl;

        if (action == '0') break;

        switch (action) {
            case '1':
                cout << "새 이름을 입력해주세요: ";
                cin >> new_name;
                c1.setName(new_name);
                break;
            case '2':
                c1.level_up();
                break;
            case '3':
                c1.item_up();
                break;
            case '4':
                c1.item_down();
                break;
            default:
                c1.printInfo();
        }
    }
}

