using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11_1
{
    /* 1. Создайте консольное приложение. Создайте базовый класс Printer с одним виртуальным методом Print
   принимающим один строковой аргумент и выводящим значение аргумента в консоль. Создайте производные классы ColourPrinter и PhotoPrinter
   которые наследуют поведение базового класса и реализуют виртуальный метод Print из базового класса, оттенить работу соответствующим сообщением в консоли.
   Класс ColourPrinter должен иметь дополнительный метод Print принимающий текст и цвет.
   Класс PhotoPrinter должен иметь дополнительный метод Print принимающий фото.
     * */
    class Program
    {
        static void Main(string[] args)
        {
            var colorPrinter = new ColorPrinter();
            var photoPrinter=new PhotoPrinter();
            colorPrinter.Print("Message");
            colorPrinter.Print("Text",ConsoleColor.Blue);
            photoPrinter.Print("text");
            photoPrinter.Print(new Photo());
            Console.ReadKey();
        }
    }
}
