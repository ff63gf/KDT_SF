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
		// private으로 선언해 놓고, 구현해 놓지 않은 의도를 여기에 명확하게 표시해 두는 게
		// 나중에 maintainer에 대한 예의겠죠.
		int x = 0;
		int y = 0;
		int* p = new int;

	public:
		PositionClass(int x, int y) { //일반 생성자
			set_p(x, y, 100);
		}
		
		PositionClass(const PositionClass&) = delete; //복사 생성자 삭제
		PositionClass& operator=(const PositionClass&) = delete; //복사 대입연산자 삭제 => 객체를 복사하지 못함
		
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