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
        public static string anaKonum = Directory.GetCurrentDirectory() ;
        static void Main(string[] args)
        {
            string turkceFontlar = Path.Combine(anaKonum, "Turkce Fontlar");
            Console.WriteLine("Dosya Konumu: " + anaKonum);
            Console.WriteLine();

            Directory.CreateDirectory(turkceFontlar);

            var files = Directory.GetFiles(anaKonum).Where(x => x.EndsWith(".ttf") || x.EndsWith(".otf")).Select( x => x); //This didnt fix,but looks better hue
            Console.WriteLine("File Count: " + files.Count());
            Library kutuphane = new Library();


            for(int i=0; i < files.Count();i++)
            {
                string path = files.ElementAt(i);
                FileInfo hareketEdecekFont = new FileInfo(path);
                Face font = kutuphane.NewFace(path, 0); //This line fixed the error




                uint harf1 = font.GetCharIndex(287); // ğ 
                uint harf2 = font.GetCharIndex(351); // ş
                uint harf3 = font.GetCharIndex(231); // ç
                uint harf4 = font.GetCharIndex(246); // ö
                uint harf5 = font.GetCharIndex(252); // ü

                List<uint> charList = new List<uint> { harf1, harf2, harf3, harf4, harf5 };
                bool hasTurkishChars = false;


                if (harf1 == 0 || harf2 == 0 || harf3 == 0 || harf4 == 0 || harf5 == 0)
                {
                    hasTurkishChars = false;
                }
                else
                {
                    hasTurkishChars = true;
                }
                //Not working >.<
                //for (int chitanda = 0; chitanda < charList.Count; chitanda++)
                //{
                //    uint gIndex = 0;
                //    uint chCode = font.GetNextChar(harf3, out gIndex);
                //    if (chCode != charList[chitanda])
                //    {
                //        hasTurkishChars = false;
                //    }
                //}
                if (!hasTurkishChars)
                {
                    Console.WriteLine(font.FamilyName + " :Türkçe Karakterler: YOK");
                }
                else
                {
                    Console.WriteLine(font.FamilyName + " :Türkçe Karakterler: VAR");
                    hareketEdecekFont.CopyTo(turkceFontlar + "\\" + hareketEdecekFont.Name, true);
                }
                font.Dispose();
            }
            Console.WriteLine("\nTamalandı...");
        }
    }
}
