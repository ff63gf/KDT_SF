using System;
using Microsoft.Data.Analysis;

class Program
{
    static void Main()
    {
        // 데이터 생성
        int[] ids = { 1, 2, 3, 4, 5 };
        string[] names = { "Alice", "Bob", "Charlie", "David", "Eve" };
        int[] ages = { 25, 30, 35, 40, 45 };

        // 컬럼 생성
        PrimitiveDataFrameColumn<int> idColumn = new PrimitiveDataFrameColumn<int>("ID", ids);
        StringDataFrameColumn nameColumn = new StringDataFrameColumn("Name", names);
        PrimitiveDataFrameColumn<int> ageColumn = new PrimitiveDataFrameColumn<int>("Age", ages);

        // 데이터프레임 생성
        DataFrame df = new DataFrame(idColumn, nameColumn, ageColumn);

        // 데이터프레임 출력
        Console.WriteLine(df);
    }
}
