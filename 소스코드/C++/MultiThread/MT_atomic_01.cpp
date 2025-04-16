// std::atomic 사용법
// 24.06.20 john

#include <iostream>
#include <thread>
#include <atomic>
#include <vector>

// 일반적인 변수 선언
//int counter = 0;
// atomic으로 선언
std::atomic<int> counter(0);

void increment(int iterations) {
    for (int i = 0; i < iterations; ++i) {
        ++counter;
    }
}

int main() {
    const int num_threads = 10;
    const int num_iterations = 1000;
    std::vector<std::thread> threads;

    for (int i = 0; i < num_threads; ++i) {
        threads.push_back(std::thread(increment, num_iterations));
    }

    for (auto& t : threads) {
        t.join();
    }

    std::cout << "Final counter value: " << counter << std::endl;

    // 안전하게 값 삽입
    counter.store(999);

    // 안전하게 값 복사
    int num = counter.load();

    // 안전하게 값 비교
    // counter의 값이 999면 true를 반환하고 30으로 값을 변경
    int expacted = 999;
    bool result = counter.compare_exchange_strong(expacted, 30);
    // 반복문 안에서 돌거나, 성능이 중요하다면 weak를 사용
    bool result = counter.compare_exchange_weak(expacted, 30);

    // counter에 10을 더하고 이전에 있던 값을 반환
    int before = counter.fetch_add(10);

    return 0;
}
