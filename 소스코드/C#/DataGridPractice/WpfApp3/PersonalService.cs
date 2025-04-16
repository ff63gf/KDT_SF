using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reflection;
using System.Windows;

namespace WpfApp3
{
    internal static class PersonalService
    {
        public static string[] CSVColumnToDataGrid(string path)
        {
            using(StreamReader sr = new StreamReader(path))
            {
                try
                {
                    string[] columns = sr.ReadLine().Split(',');
                    return columns;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return null;
                }
            }
        }

        public static List<Person> CSVtoDataGrid(string path)
        {
            bool first_loop = true;

            // 클래스를 사용하는 리스트 생성
            List<Person> list = new List<Person>();

            string lines = File.ReadAllText(path);

            foreach(string line in lines.Split('\n'))
            {
                if (first_loop) 
                {
                    first_loop = false; 
                }
                else
                {
                    try
                    {
                        string[] split_data = line.Split(',');

                        if (split_data[0] != "")
                        {
                            // 클래스 생성과 동시에 리스트에 값 추가
                            list.Add(new Person()
                            {
                                Name = split_data[0],
                                Age = int.Parse(split_data[1]),
                                Feature = split_data[2]
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        return null;
                    }
                    
                }
            }
            return list;
        }
    }
}
