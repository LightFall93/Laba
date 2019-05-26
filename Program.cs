using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laba
{
    class Program
    {
        static void Main(string[] args)
        {
            string com1 = "Переименование изображении в соответствии с датой сьемки.";
            string com2 = "Добавления на изображение отметку, когда фото было сделано.";
            string com3 = "Сортировка изображений по папкам по годам. ";


            Console.WriteLine("Ваши команды:"  );
            Console.WriteLine("Введите 1 для: "+ com1);
            Console.WriteLine("Введите 2 для: "+ com2);
            Console.WriteLine("Введите 3 для: "+ com3);

                switch (Console.ReadLine())
                {
                    case "1":
                    {
                        Console.WriteLine("Введите ваш путь к папке изображений, который надо обработать.");
                        //string ImagePathEntered = Console.ReadLine();

                        string ImagePathEntered = "E:\\Images2";
                        Console.WriteLine("E:\\Images2");
                        string ImagePathNeed = ImagePathEntered+"_"+ com1;

                        DirectoryInfo dirInfo = new DirectoryInfo(ImagePathEntered);
                        string dirName = new DirectoryInfo(ImagePathEntered).Name;

                        dirInfo.CreateSubdirectory($"{dirName}_{com1}");


                    }
                    break;

                    case "2":
                    {
                        //Meod1();
                    }
                        break;

                    case "3":
                    {
                        Console.WriteLine("tipo metod ");
                    }
                        break;

                }
            

            Console.ReadLine();
        }
    }
}
