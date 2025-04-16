// 실습1. 스레드 생성 및 실행
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
        // 참고! emplace_back은 push_back과 다른게 내부에서 객체가 복사되지 않음
        // threads.push_back(std::thread(printNumbers, i + 1)) 과 같음
        threads.emplace_back(printNumbers, i + 1);    
    }

    for (auto& th : threads) {
        th.join();
    }

    return 0;
}
