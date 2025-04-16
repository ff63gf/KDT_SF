#include <iostream>

class Rectnagle {
	int width;
	int height;

public:
	Rectnagle() {};

	Rectnagle(int w, int h) {
		width = w;
		height = h;
	}

	void setWidth(int w) {
		width = w;
	}

	void setHeight(int h) {
		height = h;
	}

	int area() {
		return width * height;
	}
};


int main() {
	int w;
	int h;
	std::cout << "사각형의 가로와 세로 길이를 입력해주세요. (띄어쓰기로 구분) ";
	std::cin >> w >> h;

	Rectnagle r = Rectnagle();
	r.setWidth(w);
	r.setHeight(h);

	std::cout << "넓이는 : " << r.area();

	return 0;
}