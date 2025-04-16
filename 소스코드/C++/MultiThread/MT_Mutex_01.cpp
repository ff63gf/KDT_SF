#include <iostream>
#include <thread>
#include <mutex>

// global
std::mutex mtx; // 뮤텍스 객체 생성
int counter = 0; // 공유 자원

void increment() {
    for (int i = 0; i < 100000; ++i) {
        mtx.lock(); // 임계 구역에 들어가기 전에 잠금
        ++counter;  // 공유 자원에 접근
        mtx.unlock(); // 임계 구역을 벗어나면 잠금 해제
    }
}

int main() {
    std::thread t1(increment);
    std::thread t2(increment);
    std::thread t3(increment);

    t1.join();
    t2.join();
    t3.join();

    std::cout << "Final counter value: " << counter << std::endl;

    return 0;
}

