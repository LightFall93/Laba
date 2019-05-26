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
                switch ("1")
            {
                    case "1":
                    {
                        ImageRenameWithDate(com1);
                    }
                    break;

                    case "2":
                    {
                        //Meod2();
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
            string ImagePathEntered = "E:\\333\\zz";

            string dirName = new DirectoryInfo(ImagePathEntered).Name;

            string ImagePathCreated = ImagePathEntered + $"\\{dirName}_{com1}";
            DirectoryInfo dirInfo = new DirectoryInfo(ImagePathEntered);
            
            dirInfo.CreateSubdirectory($"{dirName}_{com1}");

            var file_mas = dirInfo.GetFiles();


            foreach (var item in file_mas)
            {
                Console.WriteLine(item.FullName +" "+ item.CreationTime);
            }

            Image myImage = Image.FromFile(@"E:\Images2\IMG_20140912_183647.JPG");
            PropertyItem propItem = myImage.GetPropertyItem(306);
            DateTime dtaken;
            DateTime dtaken2;

            string sdate = Encoding.UTF8.GetString(propItem.Value).Trim();
            //Console.WriteLine("sdate: " + sdate);
            string secondhalf = sdate.Substring(sdate.IndexOf(" "), (sdate.Length - sdate.IndexOf(" ")));
            string firsthalf = sdate.Substring(0, 10);
            firsthalf = firsthalf.Replace(":", "-");
            sdate = firsthalf + secondhalf;
            dtaken = DateTime.Parse(sdate);
            //Console.WriteLine("dtaken: " + dtaken);


            DirectoryInfo dirInfo2 = new DirectoryInfo(ImagePathEntered);

                //foreach (var item in file_mas)
                foreach (FileInfo item in dirInfo.GetFiles("*.jpg*"))
                {

                File.Copy(item.FullName, ImagePathCreated + "\\" + item.Name, true);

                File.Move("oldfilename", "newfilename");

                Image myImage2 = Image.FromFile(item.FullName);
                PropertyItem propItem2 = myImage.GetPropertyItem(306);

                string sdate2 = Encoding.UTF8.GetString(propItem.Value).Trim();
                Console.WriteLine("sdate2: " + sdate2);
                string secondhalf2 = sdate2.Substring(sdate2.IndexOf(" "), (sdate2.Length - sdate2.IndexOf(" ")));
                string firsthalf2 = sdate2.Substring(0, 10);
                firsthalf2 = firsthalf2.Replace(":", "-");
                sdate2 = firsthalf2 + secondhalf2;
                dtaken2 = DateTime.Parse(sdate2);
                Console.WriteLine("dtaken2: " + dtaken2);

                //File.Copy(file.FullName, ImagePathCreated + "\\" + file.Name,true);
                }





        }
    }
}
