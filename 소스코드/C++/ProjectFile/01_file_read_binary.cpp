#include <iostream>
#include <fstream>

int main() {
    // Specify the file path
    std::string file_path = "binary_data.bin";

    // Create an input file stream
    std::ifstream input_file(file_path, std::ios::binary);

    // Check if the file was opened successfully
    if (!input_file.is_open()) {
        std::cerr << "Failed to open the file for reading: " << file_path << std::endl;
        return 1; // Return an error code
    }

    // Define a buffer to hold the binary data
    char buffer[1024]; // You can adjust the buffer size based on your needs

    // Read binary data from the file
    input_file.read(buffer, sizeof(buffer));

    // Get the number of bytes read
    std::streamsize bytes_read = input_file.gcount();

    // Close the file
    input_file.close();

    if (bytes_read > 0) {
        // Process the binary data in the buffer (here, we'll just print it)
        std::cout << "Read " << bytes_read << " bytes of binary data:" << std::endl;
        for (int i = 0; i < bytes_read; ++i) {
            //std::cout << static_cast<int>(buffer[i]) << " ";
            std::cout << (int)(buffer[i]) << " ";
        }
        std::cout << std::endl;
    }
    else {
        std::cout << "No binary data read from the file." << std::endl;
    }

    return 0; // Return success
}
