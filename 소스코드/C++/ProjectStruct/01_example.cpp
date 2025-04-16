#include <iostream>
#include <fstream>
using std::ifstream;

struct Position {
	int x = 0;
	int y = 0;
	int* p = new int;

	Position(int x, int y) {
		set_p(x, y, 100);
	}

	void set_p(int x, int y, int p) {
		*this->p = p;
		this->x = x;
		this->y = y;
	}

	void get_p() {
		std::cout << &x << " " << &y << " " << p << std::endl;
		std::cout << x << " " << y << " " << *p << std::endl;
	}
};

class PositionClass {
		// private���� ������ ����, ������ ���� ���� �ǵ��� ���⿡ ��Ȯ�ϰ� ǥ���� �δ� ��
		// ���߿� maintainer�� ���� ���ǰ���.
		int x = 0;
		int y = 0;
		int* p = new int;

	public:
		PositionClass(int x, int y) { //�Ϲ� ������
			set_p(x, y, 100);
		}
		
		PositionClass(const PositionClass&) = delete; //���� ������ ����
		PositionClass& operator=(const PositionClass&) = delete; //���� ���Կ����� ���� => ��ü�� �������� ����
		
		void set_p(int x, int y, int p) {
			*this->p = p;
			this->x = x;
			this->y = y;
		}

		void get_p() {
			std::cout << &x << " " << &y << " " << p << std::endl;
			std::cout << x << " " << y << " " << *p << std::endl;
		}
};

int main() {
	//Position p(3,4 );
	//Position p2 = p;

	////p.set_p(1, 2);
	//p.get_p();

	//p2.set_p(1, 1);
	//p2.get_p();

	PositionClass pc(4, 4);
	PositionClass &pcc = pc;


	pc.get_p();

	pcc.set_p(1, 1, 50);
	pcc.get_p();

	pc.get_p();

	return 0;
}