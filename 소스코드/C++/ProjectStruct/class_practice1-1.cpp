#include <iostream>

using std::endl;

class Rectangle {
	int width;
	int height;

	public :
		// 기본 생성자 
		Rectangle(int x, int y) 
		{
			this->width = x;
			this->height = y;
		}

		// 복사 생성자
		Rectangle(Rectangle& other)
		{
			this->width = other.width;
			this->height = other.height;
		}

		int area() {
			return width * height;
	}
};


int main() {

	Rectangle rect1(10, 20);
	
	Rectangle r1 = rect1;
	Rectangle r2(rect1);

	std::cout << "r1 area : " << r1.area() << endl;
	std::cout << "r2 area : " << r2.area() << endl;

	Rectangle rect2(20, 30);
	rect1 = rect2;

	std::cout << "rect1 area : " << rect1.area() << endl;

	return 0;
}