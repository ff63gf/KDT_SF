// mutex, lock_guard »ç¿ë¹ý
// 24.06.20 John

#include <iostream>
#include <thread>
#include <mutex>
#include <vector>

int counter = 0;
std::mutex mtx;

void incrementCounter() {
    for (int i = 0; i < 1000; ++i) {
        std::lock_guard<std::mutex> lock(mtx);
        ++counter;
    }
}

int main() {
    std::vector<std::thread> threads;

    for (int i = 0; i < 400; ++i) {
        threads.emplace_back(incrementCounter);
    }

    for (std::thread& th : threads) {
        th.join();
    }

    std::cout << "Final counter value: " << counter << std::endl;

    return 0;
}
