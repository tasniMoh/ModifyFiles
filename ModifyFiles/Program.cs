using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;

namespace ModifyFiles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string directory = @"E:\pathForProjects\filewatcher";

            mainMenu(directory);

            Console.ReadKey();
            /*
                        var builder = new StringBuilder("You can do these actions :");

                        builder.AppendLine();
                        builder.Append("1.Remove a File");
                        builder.AppendLine("2.Rename a File");
                        builder.AppendLine("3.Create a File");
                        builder.AppendLine("4.");*/

        }
        public static void mainMenu(string directory)
        {

            Console.WriteLine("What do you want to change? (enter just a number)");
            Console.WriteLine();
            Console.WriteLine("1.Files");
            Console.WriteLine("2.Directories");
            Console.WriteLine("****************************");
            var kindOfChange = Console.ReadLine();
            int i = int.Parse(kindOfChange);
            while(!(i!=1|i!=2))
            {
                Console.WriteLine("invalid input,please enter a valid input.");
                kindOfChange = Console.ReadLine();
                 i = int.Parse(kindOfChange);
            }
            if (i == 1)
            {
                fileMenu(directory);
            }
            else if (i == 2)
            {
                directoryMenu(directory);
            }
            
        }
        public static void fileMenu(string directory)
        {

            Console.WriteLine("Choose one of these action:");
            Console.WriteLine("1.Create a file");
            Console.WriteLine("2.Delete a file");
            Console.WriteLine("3.Move a file");
            Console.WriteLine("4.Go back");
            Console.WriteLine("****************************");

            var kindOfChange = Console.ReadLine();
            int i = int.Parse(kindOfChange);
            if (i == 1)
            {
                CreateFile(directory);
            }

        }

        public static void directoryMenu(string directory)
        {

            Console.WriteLine("Choose one of these action:");
            Console.WriteLine("1.Create a directory");
            Console.WriteLine("2.Delete a directory");
            Console.WriteLine("3.Move ");
            Console.WriteLine("4.Go back");
            Console.WriteLine("****************************");

            var kindOfChange = Console.ReadLine();
            int i = int.Parse(kindOfChange);
        }

        public static void CreateFile(string directory)
        {
            Console.WriteLine("input file name:");
            string fileName = Console.ReadLine().Trim();
            Console.WriteLine("input file format: (txt,img,...)");
            string fileFormat = Console.ReadLine().Trim();
            directory = directory + '/' + fileName + '.' + fileFormat;
            if (!File.Exists(directory))
            {
                FileStream fileStream = File.Create(directory);
                fileStream.Close();
                Console.WriteLine("File creation was successful!");
            }
            else
            {
                Console.WriteLine("this file has already exists!");
            }
        }

    }
}
