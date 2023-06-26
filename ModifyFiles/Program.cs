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
            while (!(i != 1 | i != 2))
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
            while (!(i != 1 | i != 2 | i != 3 | i != 4))
            {
                Console.WriteLine("invalid input,please enter a valid input.");
                kindOfChange = Console.ReadLine();
                i = int.Parse(kindOfChange);
            }
            if (i == 1)
            {
                createFile(directory);
            }
            else if (i == 2)
            {
                deleteFile(directory);
            }
            else if (i == 3)
            {
                moveFile(directory);
            }
            else if (i == 4)
            {
                mainMenu(directory);
            }

        }

        public static void directoryMenu(string directory)
        {

            Console.WriteLine("Choose one of these action:");
            Console.WriteLine("1.Create a directory");
            Console.WriteLine("2.Delete a directory");
            Console.WriteLine("3.Move a directory");
            Console.WriteLine("4.Go back");
            Console.WriteLine("****************************");

            var kindOfChange = Console.ReadLine();
            int i = int.Parse(kindOfChange);
            while (!(i != 1 | i != 2 | i != 3 | i != 4))
            {
                Console.WriteLine("invalid input,please enter a valid input.");
                kindOfChange = Console.ReadLine();
                i = int.Parse(kindOfChange);
            }
            if (i == 1)
            {
                createDirectory(directory);
            }
            else if (i == 2)
            {
                deleteDirectory(directory);
            }
            else if (i == 3)
            {
                moveDirectory(directory);
            }
            else if (i == 4)
            {
                mainMenu(directory);
            }
        }

        public static void createFile(string directory)
        {
            Console.WriteLine("input file name:");
            string fileName = Console.ReadLine().Trim();
            Console.WriteLine("input file format: (txt,img,...)");
            string fileFormat = Console.ReadLine().Trim();
            string path = directory + '/' + fileName + '.' + fileFormat;
            if (!File.Exists(directory))
            {
                FileStream fileStream = File.Create(path);
                fileStream.Close();
                Console.WriteLine("File creation was successful!");
            }
            else
            {
                Console.WriteLine("this file has already exists!");
            }
            mainMenu(directory);
        }
        public static void deleteFile(string directory)
        {
            Console.WriteLine("input file name:");
            string fileName = Console.ReadLine().Trim();
            Console.WriteLine("input file format: (txt,img,...)");
            string fileFormat = Console.ReadLine().Trim();
            string path = directory + '/' + fileName + '.' + fileFormat;

            if (!File.Exists(path))
            {
                Console.WriteLine("there isn't a file with this name or format !");
            }
            else
            {
                File.Delete(path);

                Console.WriteLine("File deletion was successful!");

            }
            mainMenu(directory);
        }
        public static void moveFile(string directory)
        {
            Console.WriteLine("enter a source path:");
            Console.WriteLine();
            Console.WriteLine("for example:    " + directory);
            string source = Console.ReadLine();
            Console.WriteLine("enter a destination path:");
            Console.WriteLine("(if you didn't enter a destination,automoticly file will move to ---->" + directory);
            string destination = Console.ReadLine();
            if (destination == null)
            {
                destination = directory;
            }
            else
            {
                try
                {
                    File.Move(source, destination);

                    Console.WriteLine("File moved successfully.");
                }
                catch (IOException e)
                {
                    Console.WriteLine("An error has occurred while moving the file:");
                    Console.WriteLine(e.Message);
                }
            }
            mainMenu(directory);
        }
        public static void createDirectory(string directory)
        {
            Console.WriteLine("choose a name for directory.");
            string name = Console.ReadLine();
            string path = directory + "/" + name;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine("Directory created successfully.");
            }
            else
            {
                Console.WriteLine("this directory has already exists!");
            }

            mainMenu(directory);
        }
        public static void deleteDirectory(string directory)
        {
            Console.WriteLine("input a directory name .");
            string name = Console.ReadLine();
            string path = directory + "/" + name;
            if (Directory.Exists(path))
            {
                Directory.Delete(path);
                Console.WriteLine("Directory removed successfully.");
            }
            else
            {
                Console.WriteLine("this directory doesn't exists!");
            }
            mainMenu(directory);
        }

        public static void moveDirectory(string directory)
        {

            Console.WriteLine("enter a source path:");
            Console.WriteLine();
            Console.WriteLine("for example:    " + directory);
            string source = Console.ReadLine();
            Console.WriteLine("enter a destination path:");
            Console.WriteLine("(if you didn't enter a destination,automoticly file will move to ---->" + directory);
            string destination = Console.ReadLine();
            if (destination == null)
            {
                destination = directory;
            }
            else
            {
                try
                {
                    Directory.Move(source, destination);

                    Console.WriteLine("Directory moved successfully.");
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine("An error has occurred while moving the directory:");
                    Console.WriteLine(e.Message);
                }
            }
            mainMenu(directory);
        }



    }
}
