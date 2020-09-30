using System;
using System.Collections.Generic;
using System.Text;

namespace DC_HW_2
{
    public class ProdusedClass : IProdusedClass
    {
        public string Props { get; private set; }
        public string Info { get; private set; }

        public ProdusedClass()
        {
            Console.WriteLine($"Объект класса \"{this.GetType().Name}\" успешно инициализирован");
        }
        ~ProdusedClass()
        {

        }
    }
}