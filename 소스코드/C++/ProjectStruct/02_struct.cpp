#include <iostream>

struct Position {
	int x = 0;
	int y = 0;
};

struct Rectengle {
	double width;
	double height;
};

int main() {
	//Position p;
	//p.x = 3;
	//p.y = 5;
	Position p = { 3,5 };
	std::cout << p.x << " " << p.y << std::endl;

	//--------------실습 해답---------------

	double width, height;
	std::cout << "가로, 세로 길이를 입력하세요. ";
	std::cin >> width >> height;

	Rectengle rec = { width, height };

	std::cout << "넓이는 : " << rec.width * rec.height;

	return 0;
}