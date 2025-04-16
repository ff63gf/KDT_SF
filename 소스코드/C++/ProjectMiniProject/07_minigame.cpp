#include <iostream>
#include <string>
#include <vector>

using std::string;
using std::cout;
using std::cin;
using std::endl;
using std::vector;
class Weapon {
protected:
    int power;          // 공격력
    int remaining_hit;  // 공격가능횟수
public:
    Weapon(int p, int r) : power(p), remaining_hit(r) {}
    virtual void attack() {};  // 가상함수
    int get_power() {
        return power;
    }
    int get_remaining_hit() {
        return remaining_hit;
    }

    void minums_remaining_hit() {
        remaining_hit--;
    }
};
class Knife : public Weapon {
public:
    Knife() : Weapon(5, 3) {}
    void attack() override {
        cout << "찌르기 !! 푹푹" << endl;
    }
};

class Gun : public Weapon {
public:
    Gun() : Weapon(10, 1) {}
    void attack() override {
        cout << "총쏘기 !! 탕탕" << endl;
    }
};


class Character {
protected:
    int hp;
    int level;
    string name;
    vector<Weapon*> weapons;
public:
    Character(int hp, int level, string name) : hp(hp), level(level), name(name) {}
    void pick_up_weapon(Weapon* weapon) {
        weapons.push_back(weapon);
        cout << "무기를 줍습니다." << endl;
    }
    void attack(Character* target) {
        if (weapons.empty()) {
            cout << "무기가 없습니다." << endl;
            return;
        }
        Weapon* weapon = weapons.back();  // 가장 최근에 얻은 무기 사용
        weapon->attack();
        cout << name << "이(가) " << target->get_name() << "을(를) 공격했습니다." << endl;

        target->damage(weapon->get_power());
        weapon->minums_remaining_hit();

        if (weapon->get_remaining_hit() == 0) {
            weapons.pop_back();
            delete weapon;  // 메모리 해제
        }
    }
    void damage(int damage) {
        hp -= damage;

        cout << name << "의 hp가 -" << damage << "만큼 감소합니다" << endl;

        if (hp <= 0) {
            cout << name << "이(가) 죽었습니다." << endl;
        }
        else {
            cout << name << "의 남은 hp: " << hp << endl;
        }
    }
    string get_name() {
        return name;
    }
    int get_hp() {
        return hp;
    }
};

int user_turn() {
    int num;
    cout << "어떤 동작을 하겠습니까? (1.무기 줍줍   2.공격): ";
    cin >> num;
    if (num == 1 || num == 2) return num;
    else return 0;
}

int user_pick_weapon() {
    int weapon;
    cout << "어떤 무기를 줍겠습니까? (1.칼  2.총): ";
    cin >> weapon;
    if (weapon == 1 || weapon == 2) return weapon;
    else return 0;
}


int main() {
    string name1;
    cout << "캐릭터 이름 입력 : ";
    cin >> name1;
    Character* player1 = new Character(30, 1, name1);
    Character* computer = new Character(30, 1, "컴퓨터");

    std::srand(time(NULL)); // 매번 다른 값을 생성하려면 srand() 함수에 seed 전달.

    bool turn = false; // 0이 사용자, 1이 컴퓨터

    while (1) {
        int num;
        Character* player;
        Character* enemy;
        if (turn) {
            cout << "[computer turn]" << endl;
            num = std::rand() % 2 + 1;
            player = computer;
            enemy = player1;
        }
        else {
            cout << "[" << name1 << " turn]" << endl;
            num = user_turn();
            player = player1;
            enemy = computer;
        }

        if (num == 1) {
            int weapon;
            turn ? weapon = std::rand() % 2 + 1 : weapon = user_pick_weapon();
            if (weapon == 1) player->pick_up_weapon(new Knife());
            else if (weapon == 2) player->pick_up_weapon(new Gun());
            else cout << "그런 무기는 없습니다." << endl;
        }
        else if (num == 2) {
            player->attack(enemy);
            if (enemy->get_hp() <= 0) break;
        }
        else cout << "0~2 사이의 수를 입력하세요." << endl;

        turn = !turn;
        cout << endl;
    }

    string winner = turn ? computer->get_name() : player1->get_name();
    cout << winner << " 승리!";

    delete player1;
    delete computer;
    return 0;
}