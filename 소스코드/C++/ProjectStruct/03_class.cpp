#include <iostream>

class Position {
	int x = 0; // �ʵ�
	int y = 0;

	public: // ���� ������
		Position() { // ������
			std::cout << "Position ��ü ����\n";
		}

		Position(int x, int y) { // ������
			this->x = x;
			this->y = y;
			std::cout << "Position ��ü ����2\n";
		}

		void printXY() { // �޼ҵ�
			std::cout << x << " " << y << std::endl;
		}

};

int main() {
	Position p;
	//p.x = 3; // ���� ��!!!!
	//p.y = 5;
	Position p2(2,3);

	p.printXY();
	p2.printXY();

	return 0;
}