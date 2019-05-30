using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Drawing.Imaging;

namespace Laba
{
    class Program
    {
        static void Main(string[] args)
        {

            string com1 = "Переименование изображении в соответствии с датой сьемки";
            string com2 = "Добавления на изображение отметку, когда фото было сделано";
            string com3 = "Сортировка изображений по папкам по годам";

            Console.WriteLine("Ваши команды:"  );
            Console.WriteLine("Введите 1 для: "+ com1);
            Console.WriteLine("Введите 2 для: "+ com2);
            Console.WriteLine("Введите 3 для: "+ com3);

                //switch (Console.ReadLine())
                switch ("2")
            {
                    case "1":
                    {
                        ImageRenameWithDate(com1);
                    }
                    break;

                    case "2":
                    {
                        AddDateOnImagePicture(com2);
                    }
                        break;

                    case "3":
                    {
                        Console.WriteLine("tipo metod3 ");
                    }
                        break;

                }
            Console.ReadLine();
        }

        public static void ImageRenameWithDate(string com1)
        {
            Console.WriteLine("Введите ваш путь к папке изображений, который надо обработать.");
            //string ImagePathEntered = Console.ReadLine();
            string ImagePathEntered = "E:\\Images";

            string dirName = new DirectoryInfo(ImagePathEntered).Name;

            string ImagePathCreated = ImagePathEntered + $"\\{dirName}_{com1}";
            DirectoryInfo dirInfo = new DirectoryInfo(ImagePathEntered);

            DirectoryInfo dirInfo2 = new DirectoryInfo(ImagePathCreated);

            if (!dirInfo2.Exists)
            {
                dirInfo.CreateSubdirectory($"{dirName}_{com1}");
            }

            var file_mas = dirInfo.GetFiles();

            foreach (var item in file_mas)
            {
                if (item.Name.EndsWith(".jpg"))
                {
                    PropertyItem propItem = null;
                    Image myImage = Image.FromFile(item.FullName);
                    try
                    {
                        propItem = myImage.GetPropertyItem(306);
                    }
                    catch { }
                    if (propItem != null)
                    {
                        string sdate2 = Encoding.UTF8.GetString(propItem.Value).Trim();
                        string secondhalf2 = sdate2.Substring(sdate2.IndexOf(" "), (sdate2.Length - sdate2.IndexOf(" ")));
                        secondhalf2 = secondhalf2.TrimEnd(secondhalf2[secondhalf2.Length - 1]);
                        string firsthalf2 = sdate2.Substring(0, 10);
                        firsthalf2 = firsthalf2.Replace(":", "-");
                        secondhalf2 = secondhalf2.Replace(":", "-");
                        sdate2 = firsthalf2 + secondhalf2;
                        sdate2 = sdate2.Replace(" ", "_");
                        Console.WriteLine("Файл "+ item.FullName +" Скопирован "+ $@"{ImagePathCreated}\{sdate2}" + ".jpg");
                        File.Copy(item.FullName, $@"{ImagePathCreated}\{sdate2}" + ".jpg", true);
                    }

                    else
                    {
                        string tempName = Convert.ToString(item.CreationTime);
                        tempName = tempName.Replace(" ", "_");
                        tempName = tempName.Replace(".", "-");
                        tempName = tempName.Replace(":", "_");                    
                        File.Copy(item.FullName, $@"{ImagePathCreated}\{tempName}" + ".jpg", true);

                    }
                }
            }




        }

        public static void AddDateOnImagePicture(string com2)
        {
            Console.WriteLine("Введите ваш путь к папке изображений, который надо обработать.");
            //string ImagePathEntered = Console.ReadLine();
            string ImagePathEntered = "E:\\Images";

            string dirName = new DirectoryInfo(ImagePathEntered).Name;

            string ImagePathCreated = ImagePathEntered + $"\\{dirName}_{com2}";
            DirectoryInfo dirInfo = new DirectoryInfo(ImagePathEntered);

            DirectoryInfo dirInfo2 = new DirectoryInfo(ImagePathCreated);

            if (!dirInfo2.Exists)
            {
                dirInfo.CreateSubdirectory($"{dirName}_{com2}");
            }

        }






        public static void JustRename()
        {

            string ImagePathEntered = "E:\\Images";

            DirectoryInfo dirInfo = new DirectoryInfo(ImagePathEntered);

            var file_mas = dirInfo.GetFiles();
            FileInfo filemas2 = new FileInfo(ImagePathEntered);

            string tempName;
            foreach (var items in file_mas)
            {
                tempName = Convert.ToString(items.CreationTime);
                tempName = tempName.Replace(" ", "_");
                tempName = tempName.Replace(".", "-");
                tempName = tempName.Replace(":", "_");

                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                items.MoveTo($@"{items.DirectoryName}\{tempName}"+".jpg");


                Console.WriteLine(tempName); 
                Console.WriteLine($@"{items.DirectoryName}\{items.CreationTime}");
            }

        }
    }
}
