// std::unique_lock 사용법
// 24.06.20 john

#include <iostream>
#include <thread>
#include <mutex>
#include <chrono>

std::mutex mtx;

void try_to_lock(int id) {
    std::unique_lock<std::mutex> lock(mtx, std::defer_lock); // lock을 바로 획득하지 않음

    if (lock.try_lock()) { // lock을 시도
        std::cout << "Thread " << id << " acquired the lock." << std::endl;
        std::this_thread::sleep_for(std::chrono::seconds(1)); // 자원 사용 시뮬레이션

        lock.unlock(); // lock 해제
        std::cout << "Thread " << id << " released the lock." << std::endl;
    }
    else {
        std::cout << "Thread " << id << " could not acquire the lock." << std::endl;
    }
}

void use_release(int id) {
    std::unique_lock<std::mutex> lock(mtx); // lock을 바로 획득
    std::cout << "Thread " << id << " acquired the lock and will release it soon." << std::endl;
    std::this_thread::sleep_for(std::chrono::seconds(1)); // 자원 사용 시뮬레이션

    std::mutex* mtx_ptr = lock.release(); // lock을 해제하지만 뮤텍스는 유지
    std::cout << "Thread " << id << " released the lock but retains the mutex." << std::endl;

    // mtx_ptr을 사용하여 수동으로 뮤텍스를 잠글 수 있음
    mtx_ptr->unlock();
}

int main() {
    std::thread t1(try_to_lock, 1);
    std::thread t2(try_to_lock, 2);
    std::thread t3(use_release, 3);

    t1.join();
    t2.join();
    t3.join();

    return 0;
}
