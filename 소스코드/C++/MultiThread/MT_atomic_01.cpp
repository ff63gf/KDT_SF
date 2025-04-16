// std::atomic ����
// 24.06.20 john

#include <iostream>
#include <thread>
#include <atomic>
#include <vector>

// �Ϲ����� ���� ����
//int counter = 0;
// atomic���� ����
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

    // �����ϰ� �� ����
    counter.store(999);

    // �����ϰ� �� ����
    int num = counter.load();

    // �����ϰ� �� ��
    // counter�� ���� 999�� true�� ��ȯ�ϰ� 30���� ���� ����
    int expacted = 999;
    bool result = counter.compare_exchange_strong(expacted, 30);
    // �ݺ��� �ȿ��� ���ų�, ������ �߿��ϴٸ� weak�� ���
    bool result = counter.compare_exchange_weak(expacted, 30);

    // counter�� 10�� ���ϰ� ������ �ִ� ���� ��ȯ
    int before = counter.fetch_add(10);

    return 0;
}
