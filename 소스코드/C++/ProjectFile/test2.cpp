#include <iostream>
#include <fstream>

int main() {
    std::ofstream file("example.txt", std::ios::in | std::ios::out); // Open the file for both reading and writing

    if (!file) {
        std::cerr << "Error opening file." << std::endl;
        return 1;
    }

    // Seek to a specific position in the file (byte offset)
    std::streampos positionToModify = 10; // Change this to your desired position
    file.seekp(positionToModify, std::ios::beg);

    // Write new data at the specified position
    //std::string newData = "This is the new data.";
    std::string newData = "This";
    file.write(newData.c_str(), newData.length());

    // Close the file
    file.close();

    std::cout << "Data modified successfully." << std::endl;

    return 0;
}