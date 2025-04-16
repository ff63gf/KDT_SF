//마방진 만들기

#include <iostream>
#include <string>
#include <iomanip>

int main()
{
	int n;

	std::cout << "마방진의 행 혹은 열의 수를 자연수로 입력해주세요.";
	std::cin >> n;

	int i, j;
	int** arr = new int* [n];

	for (i = 0; i < n; i++) {
		arr[i] = new int[n];
	}

	for (i = 0; i < n; i++) {
		for (j = 0; j < n; j++) {
			arr[i][j] = 0;
		}
	}

	int x = 0;
	int y = n / 2;

	arr[x][y] = 1;

	for (i = 2; i <= n * n; i++) {
		x = x - 1;
		y = y + 1;

		if ((y >= n) && (x < 0)) {
			x = x + 2;
			y = y - 1;
		}

		if (x < 0) {
			x = n - 1;
		}

		if (y >= n) {
			y = 0;
		}

		if (arr[x][y] != 0) {
			x = x + 2;
			y = y - 1;
		}

		arr[x][y] = i;
	}

	for (i = 0; i < n; i++) {
		for (j = 0; j < n; j++) {
			std::cout << std::setw(3) << std::to_string(arr[i][j]);
		}

		std::cout << "\n";
	}

	return 0;
}