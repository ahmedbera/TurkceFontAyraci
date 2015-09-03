using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.IO;
using SharpFont;


namespace ConsoleApplication1
{
    class Program
    {
        public string anaKonum = Directory.GetCurrentDirectory();
        static void Main(string[] args)
        {
            string anaKonum = Directory.GetCurrentDirectory();
            string turkceFontlar = Path.Combine(anaKonum, "Turkce Fontlar");
            Console.WriteLine("Dosya Konumu: " + anaKonum);
            Console.WriteLine();

            Directory.CreateDirectory(turkceFontlar);
            
            var files =
                from ktp in Directory.EnumerateFiles(anaKonum)
                where ktp.EndsWith(".ttf") || ktp.EndsWith(".otf")
                select ktp;

            Library kutuphane = new Library();


            foreach (var fontInFolder in files)
            {
                FileInfo hareketEdecekFont = new FileInfo(fontInFolder);
                Face font = new Face(kutuphane, fontInFolder);

                uint harf1 = font.GetCharIndex(287); // ğ 
                uint harf2 = font.GetCharIndex(351); // ş
                uint harf3 = font.GetCharIndex(231); // ç
                uint harf4 = font.GetCharIndex(246); // ö
                uint harf5 = font.GetCharIndex(252); // ü
                bool uselessSwitch = false;
                if (harf1 == 0 || harf2 == 0 || harf3 == 0 || harf4 == 0 || harf5 == 0)
                {
                    Console.WriteLine(font.FamilyName + " :Türkçe Karakterler: YOK");
                }
                else
                {
                    Console.WriteLine(font.FamilyName + " :Türkçe Karakterler: VAR");
                    uselessSwitch = true;
                }
                if (uselessSwitch == true)
                {
                    hareketEdecekFont.CopyTo(turkceFontlar + "\\" + hareketEdecekFont.Name, true);
                }
            }
            Console.WriteLine("\nTamalandı...");
            Console.ReadLine();
        }
    }
}
