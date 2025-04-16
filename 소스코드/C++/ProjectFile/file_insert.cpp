#include <iostream>
#include <fstream>
#include <string>

int main() {
    std::string filename = "example.txt"; // Change this to your file's name
    std::ifstream originalFile(filename);

    if (!originalFile) {
        std::cerr << "Error opening file for reading." << std::endl;
        return 1;
    }

    std::string tempFilename = "temp.txt"; // Temporary file
    std::ofstream tempFile(tempFilename);

    if (!tempFile) {
        std::cerr << "Error opening temporary file for writing." << std::endl;
        return 1;
    }

    // Point in the file where you want to insert data (byte position)
    std::streampos insertPosition = 50; // Change this to your desired position

    // Read and copy data up to the insertion point
    char ch;
    // tellg : 현재 위치 리턴
    while (originalFile.tellg() < insertPosition && originalFile.get(ch)) {
        tempFile.put(ch);
    }

    // Insert new data
    std::string newData = "This is the new data to insert.";
    tempFile << newData;

    // Skip the data at the insertion point in the original file
    originalFile.seekg(newData.length(), std::ios::cur);

    // Copy the remaining data from the original file
    while (originalFile.get(ch)) {
        tempFile.put(ch);
    }

    // Close both files
    originalFile.close();
    tempFile.close();

    // Replace the original file with the temporary file
    if (remove(filename.c_str()) != 0) {
        std::cerr << "Error removing original file." << std::endl;
        return 1;
    }
    if (rename(tempFilename.c_str(), filename.c_str()) != 0) {
        std::cerr << "Error renaming temporary file." << std::endl;
        return 1;
    }

    std::cout << "Data inserted successfully." << std::endl;

    return 0;
}
