// std::unique_lock ����
// 24.06.20 john

#include <iostream>
#include <thread>
#include <mutex>
#include <chrono>

std::mutex mtx;

void try_to_lock(int id) {
    std::unique_lock<std::mutex> lock(mtx, std::defer_lock); // lock�� �ٷ� ȹ������ ����

    if (lock.try_lock()) { // lock�� �õ�
        std::cout << "Thread " << id << " acquired the lock." << std::endl;
        std::this_thread::sleep_for(std::chrono::seconds(1)); // �ڿ� ��� �ùķ��̼�

        lock.unlock(); // lock ����
        std::cout << "Thread " << id << " released the lock." << std::endl;
    }
    else {
        std::cout << "Thread " << id << " could not acquire the lock." << std::endl;
    }
}

void use_release(int id) {
    std::unique_lock<std::mutex> lock(mtx); // lock�� �ٷ� ȹ��
    std::cout << "Thread " << id << " acquired the lock and will release it soon." << std::endl;
    std::this_thread::sleep_for(std::chrono::seconds(1)); // �ڿ� ��� �ùķ��̼�

    std::mutex* mtx_ptr = lock.release(); // lock�� ���������� ���ؽ��� ����
    std::cout << "Thread " << id << " released the lock but retains the mutex." << std::endl;

    // mtx_ptr�� ����Ͽ� �������� ���ؽ��� ��� �� ����
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
