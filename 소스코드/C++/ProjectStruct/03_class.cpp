#include <iostream>

class Position {
	int x = 0; // 鞘靛
	int y = 0;

	public: // 立辟 力绢磊
		Position() { // 积己磊
			std::cout << "Position 按眉 积己\n";
		}

		Position(int x, int y) { // 积己磊
			this->x = x;
			this->y = y;
			std::cout << "Position 按眉 积己2\n";
		}

		void printXY() { // 皋家靛
			std::cout << x << " " << y << std::endl;
		}

};

int main() {
	Position p;
	//p.x = 3; // 坷幅 朵!!!!
	//p.y = 5;
	Position p2(2,3);

	p.printXY();
	p2.printXY();

	return 0;
}