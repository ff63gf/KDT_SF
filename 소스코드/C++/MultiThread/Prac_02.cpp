// 실습2. 공유 자원 보호하기
// 24.06.19 John

#include <iostream>
#include <thread>
#include <mutex>

//std::mutex mtx;

class BankAccount {
public:
    BankAccount(int initial_balance) : balance(initial_balance) {}

    void deposit(int amount) {
        std::lock_guard<std::mutex> lock(mtx);
        balance += amount;
        std::cout << "Deposited " << amount << ", new balance: " << balance << std::endl;
    }

    void withdraw(int amount) {
        std::lock_guard<std::mutex> lock(mtx);
        if (balance >= amount) {
            balance -= amount;
            std::cout << "Withdrew " << amount << ", new balance: " << balance << std::endl;
        }
        else {
            std::cout << "Failed to withdraw " << amount << ", balance: " << balance << std::endl;
        }
    }

    int get_balance() const {
        std::lock_guard<std::mutex> lock(mtx);
        return balance;
    }

private:
    int balance;
    mutable std::mutex mtx;
    //std::mutex mtx;
};

void deposit_task(BankAccount& account, int amount, int times) {

    for (int i = 0; i < times; ++i) {
        account.deposit(amount);
    }
}

void withdraw_task(BankAccount& account, int amount, int times) {
    for (int i = 0; i < times; ++i) {
        account.withdraw(amount);
    }
}

int main() {
    BankAccount account(1000); // 초기 잔고 1000

    std::thread t1(deposit_task, std::ref(account), 50, 20); // 50을 20번 입금
    std::thread t2(withdraw_task, std::ref(account), 30, 30); // 30을 30번 출금

    t1.join();
    t2.join();

    std::cout << "Final balance: " << account.get_balance() << std::endl;

    return 0;
}
