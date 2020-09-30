using System;
using System.Collections.Generic;
using System.Text;


namespace DC_HW_2
{
    public class ProdusedClass : IProdusedClass
    {
        public string Props { get; private set; }
        public string Info { get; private set; }

        public int bruh { get; private set; }

        public ProdusedClass()
        {
            Random r = new Random();
            bruh = r.Next(-100, 100);
            Console.WriteLine($"Объект класса \"{this.GetType().Name}\" успешно инициализирован со значением {bruh}");
        }
        ~ProdusedClass()
        {

        }
    }
}