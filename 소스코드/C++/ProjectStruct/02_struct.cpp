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

	//--------------�ǽ� �ش�---------------

	double width, height;
	std::cout << "����, ���� ���̸� �Է��ϼ���. ";
	std::cin >> width >> height;

	Rectengle rec = { width, height };

	std::cout << "���̴� : " << rec.width * rec.height;

	return 0;
}