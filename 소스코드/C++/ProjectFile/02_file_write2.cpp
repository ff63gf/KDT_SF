#include <iostream>
#include <fstream>
#include <string>

int main() {
    std::string file_path = "output.txt";

    std::ofstream output_file(file_path);

    if (!output_file.is_open()) {
        std::cerr << "Failed to open the file for writing: " << file_path << std::endl;
        return 1;
    }

    output_file << "Hello, World!" << std::endl;
    output_file << "This is a sample file." << std::endl;

    output_file.close();

    std::cout << "Data has been written to " << file_path << std::endl;

    return 0;
}
