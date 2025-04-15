// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string content = File.ReadAllText("./input.txt");
Console.WriteLine(content);

string[] getFileContents(string filePath)
{
    if (!File.Exists(filePath)) throw new FileNotFoundException();

    string content = File.ReadAllText(filePath);
    return content.Split('\n');
}

void getFileContents2(string filePath, out string[] result)
{
    if (!File.Exists(filePath)) throw new FileNotFoundException();

    string content = File.ReadAllText(filePath);
    result = content.Split('\n');
}

try
{
    //string[] contents = getFileContents("./input.txt");
    string[] contents;
    getFileContents2("./input.txt", out contents);

    foreach (var c in contents)
    {
        try
        {
            int number = int.Parse(c);
            Console.WriteLine($"숫자 {number}");
        }
        catch
        {
            Console.WriteLine($"문자 {c}");
        }
    }
}
catch
{
    Console.WriteLine("파일이 존재하지 않음");
}
finally
{
    Console.WriteLine("완료");
}




//int[] arr = { 1, 3, 5, 2, 6, 7, 10 };
//string[] s_arr = { "10", "32", "1", "8", "102"};

//Array.Sort(arr);
//Console.WriteLine("Sorted array: " + string.Join(", ", arr));

//Array.Reverse(arr);
//Console.WriteLine("Reversed  array: " + string.Join(", ", arr));

//Array.Sort(s_arr);
//Console.WriteLine("Sorted array: " + string.Join(", ", s_arr));

//int[] i_arr = Array.ConvertAll(s_arr, int.Parse);
//Console.WriteLine("Converted int array: " + string.Join(", ", i_arr));
//Array.Sort(i_arr);
//Console.WriteLine("Sorted array: " + string.Join(", ", i_arr));

//int[] arr2 = { 1, 3, 5, 2, 6, 7, 10 };
//int[] arr3 = arr2.OrderBy(x => -x).ToArray();
//Console.WriteLine("Sorted array: " + string.Join(", ", arr2));
//Console.WriteLine("Sorted array: " + string.Join(", ", arr3));

//int[] intArr = { 3, 1, 2 };
//string[] strArr = Array.ConvertAll(intArr, x => x.ToString());
//Console.WriteLine("strArr: " + string.Join(", ", strArr));

//int size = 10;
//var numbers = Enumerable.Range(1, size);
//var same_numbers = Enumerable.Repeat(0, size);

//Console.WriteLine("numbers: " + string.Join(", ", numbers));
//Console.WriteLine("same_numbers: " + string.Join(", ", same_numbers));