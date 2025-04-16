#include <iostream>
#include <fstream>

int main() {
    // Specify the file path
    std::string file_path = "binary_data.bin";

    // Create an output file stream
    std::ofstream output_file(file_path, std::ios::binary);

    // Check if the file was opened successfully
    if (!output_file.is_open()) {
        std::cerr << "Failed to open the file for writing: " << file_path << std::endl;
        return 1; // Return an error code
    }

    // Define binary data to be written
    int binary_data[] = { 1, 2, 3, 4, 5, 48, 65, 0x12345678 };

    // Calculate the size of the data in bytes
    std::size_t data_size = sizeof(binary_data);

    // Write the binary data to the file
    //output_file.write(reinterpret_cast<const char*>(binary_data), data_size);
    output_file.write((char*)&binary_data, data_size);

    // Close the file
    output_file.close();

    std::cout << "Binary data has been written to " << file_path << std::endl;

    return 0; // Return success
}
