#include <iostream>
#include <fstream>
#include <vector>

int main() {
    // Define an array of integers
    int numbers[] = { 1, 2, 3, 4, 5 };

    // Determine the number of elements in the array
    int numElements = sizeof(numbers) / sizeof(numbers[0]);

    // Define a binary file for writing
    std::ofstream binaryOut("numbers.bin", std::ios::binary);

    if (!binaryOut) {
        std::cerr << "Error opening binary file for writing." << std::endl;
        return 1;
    }

    // Write the array to the binary file
    binaryOut.write(reinterpret_cast<const char*>(numbers), sizeof(numbers));

    // Close the binary file
    binaryOut.close();

    // Define a binary file for reading
    std::ifstream binaryIn("numbers.bin", std::ios::binary);

    if (!binaryIn) {
        std::cerr << "Error opening binary file for reading." << std::endl;
        return 1;
    }

    // Read the array back from the binary file into a vector
    std::vector<int> readNumbers(numElements);
    std::vector<char> readChars(sizeof(int)*numElements);
    binaryIn.read(reinterpret_cast<char*>(&readNumbers[0]), sizeof(int) * numElements);
    binaryIn.clear();
    binaryIn.seekg(0);
    binaryIn.read(reinterpret_cast<char*>(&readChars[0]), sizeof(int) * numElements);

    // Close the binary file
    binaryIn.close();

    // Print the read data
    std::cout << "Read data from binary file:" << std::endl;
    for (int i = 0; i < numElements; ++i) {
        std::cout << readNumbers[i] << " ";
    }
    std::cout << std::endl;
    for (int i = 0; i < sizeof(int) * numElements; ++i) {
        std::cout << readChars[i] << " ";
    }
    std::cout << std::endl;

    return 0;
}
