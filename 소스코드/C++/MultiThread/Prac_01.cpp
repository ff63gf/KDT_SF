// �ǽ�1. ������ ���� �� ����
// 240619 John

#include <iostream>
#include <thread>
#include <vector>

void printNumbers(int threadID) {
    for (int i = 1; i <= 10; ++i) {
        std::cout << "Thread " << threadID << ": " << i << std::endl;
    }
}

int main() {
    std::vector<std::thread> threads;

    for (int i = 0; i < 5; ++i) {
        // ����! emplace_back�� push_back�� �ٸ��� ���ο��� ��ü�� ������� ����
        // threads.push_back(std::thread(printNumbers, i + 1)) �� ����
        threads.emplace_back(printNumbers, i + 1);    
    }

    for (auto& th : threads) {
        th.join();
    }

    return 0;
}
