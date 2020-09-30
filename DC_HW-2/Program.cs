using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Collections.Immutable;

namespace DC_HW_2
{
    class Program
    {
        #region fields

        #endregion
        #region some class examples

        #endregion

        /// <summary>
        /// Метод создания оболочки звездами
        /// </summary>
        /// <param name="str">возврат звезд</param>
        /// <returns>Референс строки</returns>
        static string filling(in string str)
        {
            string returningValue = "";
            for (int i = 0; i < str.Length; ++i) { returningValue += '*'; }
            return returningValue;
        }

        /// <summary>
        /// Вывод стилизированных заголовков
        /// </summary>
        /// <param name="str">заголовок</param>
        static void constructing(string str)
        {
            Console.WriteLine(filling(str));
            Console.WriteLine(str);
            Console.WriteLine(filling(str));
            Console.WriteLine();
        }

        static string PC_Data()
        {
            string returnValue = "";
            string[] drivesNames = Environment.GetLogicalDrives();

            for (int x = 0; x < drivesNames.Length; ++x)
            {
                returnValue += $"Drive{x + 1}: {drivesNames[x]}\n";
            }
            
            return returnValue;
        }

        static void FabricTest()
        {
            IFabric fabric = new ProdusedClassFabric();
            List<IProdusedClass> listOfObjects = new List<IProdusedClass>();
            Console.WriteLine("Введите число создаваемых объектов");
            Console.Write(": ");

            string cashe = Console.ReadLine();
            int count;

            while (!Int32.TryParse(cashe, out count))
            {
                Console.WriteLine($"Ввели не то, результат - {false}");
                Console.WriteLine("Повторите ввод");
                Console.Write(": ");
                cashe = Console.ReadLine();
            }
            Console.WriteLine("Successfull");
            for (int i = 0; i < count; ++i)
            {
                listOfObjects.Add(fabric.Produse());
            }

            int minus, zero, plus;
            minus = listOfObjects.Count(i => i.bruh < 0);
            plus = listOfObjects.Count(i => i.bruh > 0);
            zero = listOfObjects.Count(i => i.bruh == 0);

            Console.WriteLine();
            Console.WriteLine($"Плотность распределения из {listOfObjects.Count} " +
                $"объектов:\n\tПоложительные - {((double)plus / listOfObjects.Count) * 100}" +
                $"\n\tОтрицательные - {((double)minus / listOfObjects.Count) * 100}" +
                $"\n\tНули - {((double)zero / listOfObjects.Count) * 100}");

        }

        /// <summary>
        /// By Harbor
        /// </summary>
        static void VariantFirst()
        {
            // Коллекция типов
            Type[] a = AppDomain.CurrentDomain.GetAssemblies().SelectMany(t => t.GetTypes()).Where(t => t.IsClass).ToArray();

            // Мап количества типов данных(значение) в каждом отдельном наймспейсе(ключ)
            Dictionary<string, int> eachNamespaceCount = new Dictionary<string, int>();
            
            // Тупо звезды
            string stars = "****************";

            // Хедер заголовков программы НА ВСЕ ВЫВОДЫ ПРОГИ
            // Для копипаста: ProgrammHeader = $"{stars} {stars}";
            string ProgrammHeader = $"{stars} Programm starts {stars}";
            constructing(ProgrammHeader);

            // Инициализация счетчика типов
            int counter = 0;
            
            // Кэш строки-хендлера для string?
            string cashe;

            foreach(var x in a)
            {

                if (x.Namespace != null) { 
                    cashe = x.Namespace ?? "null";
                    try {
                        // Хендлер нужен для Dictionary.ContainsKey(cashe) т.к. метод кидает исключение с недопуском поиска ключа со значением null
                        if (!eachNamespaceCount.ContainsKey(cashe))
                        {
                            eachNamespaceCount.Add(cashe, 0);
                        }
                    }
                    finally
                    {
                        eachNamespaceCount[cashe]++;
                        ++counter;
                        Console.WriteLine($"{counter}: Type {x.Name} \tfrom namespace {x.Namespace};");
                    }

                }
            }
            Console.WriteLine();


            ProgrammHeader = $"{stars} Count of types in each namespases {stars}";
            constructing(ProgrammHeader);

            int checkSumm = 0;
            foreach (var x in eachNamespaceCount)
            {
                Console.WriteLine($"\tnamespace {x.Key} has {x.Value} types");
                checkSumm += x.Value;
            }
            Console.WriteLine();

            ProgrammHeader = $"{stars} Count of namespaces = { eachNamespaceCount.Count} {stars}";
            constructing(ProgrammHeader);



            ProgrammHeader = $"{stars} Count of types = { counter } {stars}";
            constructing(ProgrammHeader);


            ProgrammHeader = $"{stars} {(checkSumm.Equals(counter)? "NULL НЕ ПРОШЕЛ!": "NULL ПРОШЕЛ!") } {stars}";
            constructing(ProgrammHeader);



            ProgrammHeader = $"{stars} Programm ends {stars}";
            constructing(ProgrammHeader);


            Console.ReadLine();
        }
        /// <summary>
        /// By LeakyRus
        /// </summary>
        static void VariantSecond()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(t => t.GetTypes()).ToList();

            // сборка, неймспейс, тип
            Dictionary<string, Dictionary<string, List<Type>>> spaceType = new Dictionary<string, Dictionary<string, List<Type>>>();

            foreach (Type type in types)
            {
                string assembly = type.Assembly.GetName().Name;

                if (!spaceType.ContainsKey(assembly))
                {
                    spaceType.Add(assembly, new Dictionary<string, List<Type>>());
                }

                string space = type.Namespace ?? "null";

                if (!spaceType[assembly].ContainsKey(space))
                {
                    spaceType[assembly].Add(space, new List<Type>());
                }

                spaceType[assembly][space].Add(type);
            }

            foreach (var a in spaceType)
            {
                Console.WriteLine($"{a.Key}");
                foreach (var n in a.Value)
                {
                    Console.WriteLine($"\t{n.Key}");

                    foreach (var t in n.Value)
                    {
                        Console.WriteLine($"\t\t{t.Name}");
                    }
                }

                Console.WriteLine();
            }
        }
        /// <summary>
        /// Just main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                char input =  Console.ReadKey().KeyChar;
                Console.Clear();
                switch (input)
                {
                    case 'i':
                        {
                            VariantFirst(); break;

                        }
                    case 'j': 
                        {
                            VariantSecond(); break;
                        }
                        
                    case 'k': 
                        {
                            Console.WriteLine(PC_Data()); break;
                        }
                    case 'f':
                        {
                            FabricTest(); break;
                        }
                    case (char)27: { return; }
                    default: { Console.WriteLine("Введите i j k f для взаимодействия, esc - для выхода"); } break;
                }

                

            }

        }
    }

    
}
