#include <iostream>
#include <fstream>
#include <string>
#include <vector>

using std::cout;
using std::cin;
using std::endl;

int main() {
	
	std::ifstream file_read("hello.txt");

	if (file_read.fail()) {
		cout << "파일 없음" << endl;
		return -1;
	}

	std::ofstream file_write("output.txt");

	std::vector<std::string> storage;
	std::string line;
	while (std::getline(file_read, line)) { // get_line() file의 내용을 한 줄씩 읽어옴
		storage.push_back(line);
	}

	file_read.close();

	for (auto it = storage.rbegin(); it != storage.rend(); ++it) {
		file_write << *it << std::endl;
	}

	file_write.close();
	
	return 0;
}