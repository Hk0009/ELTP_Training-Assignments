
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Asiignment_9
{
    internal class DirectoryLogic
    {
        static void ReadAllFiles(string dirName)
        {

            var files = from file in Directory.GetFiles(dirName, "*.txt", SearchOption.AllDirectories)
                        select file;
            List<String> FileDir = new List<String>();//Storying in list
            foreach (var file in files)
            {

                FileDir.Add(file);// adding one by one
            }
            foreach (var file in FileDir)
            {
                Console.WriteLine(file);
            }
        }
        static void ReadPerticularLine(string InputFile, string PathName)
        {
            int Line;
            string path = $"{PathName}\\{InputFile}";
            string key;
            do
            {
                Console.WriteLine("Enter the Line you want to read");
                Line = Convert.ToInt32(Console.ReadLine());
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

                // 2. Create an Instance of StreamReader
                StreamReader reader = new StreamReader(fs);
                //first reading all lines
                // second the lines which is going to be input by end user
                // take the first line after skip
                // First or default means if the line is present 1 else null

                string data = File.ReadLines(path).Skip(Line - 1).Take(1).FirstOrDefault();
                reader.Close();
                if (data != null)
                {
                    Console.WriteLine($"{data}");

                }
                else { Console.WriteLine("Empty file search again"); }
                fs.Close();
                Console.WriteLine("Enter number again if you want to read . else type no");
                key = Console.ReadLine();
                if (key.ToUpper().Contains("NO"))
                {
                    return;
                }

            } while (true);

        }
        static void readWHolFile(string InputFile, string PathName)
        {
            string path = $"{PathName}\\{InputFile}";
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);
            string data = reader.ReadToEnd();
            Console.WriteLine(data);

        }



        public void ReadfromList(string dirName)
        {
            Console.WriteLine("FIle which are stored in List");
            ReadAllFiles(dirName);
            Console.WriteLine(" Enter the file name from above which you want to print");
            string Input = Console.ReadLine();
            string path = $"{dirName}\\{Input}";
            int key;
            int a = 0;
            if (!File.Exists(path))
            {
                Console.WriteLine("File doesnt exist");
            }
            else
            {
                do
                {
                    Console.WriteLine("Enter 1 to read file and 2 to read by specific line and 3 to read files with .txt and 4 to end ");
                    key = Convert.ToInt32(Console.ReadLine());
                    switch (key)
                    {
                        case 1:
                            readWHolFile(Input, dirName);
                            break;
                        case 2:
                            ReadPerticularLine(Input, dirName);
                            break;
                        case 3:
                            ReadAllFiles(dirName);
                            break;
                        case 4:
                            a++;
                            break;

                        default:
                            Console.WriteLine("Doesnt Exist");
                            break;
                    }
                } while (a==0);

            }

        }

    }
}
