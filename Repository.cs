using System.Xml.Linq;

namespace Collections
{
    public class Repository
    {
        #region Задание 1. Работа с листом

        List<int> list = new List<int>();        

        private void FillList()
        {
            list.Clear();

            Random rnd = new Random();

            while (list.Count < 100)
            {
                list.Add(rnd.Next(0, 101));
            }

            Console.WriteLine("Создан список из случайных чисел в диапазоне от 0 до 100");
            Console.WriteLine();
        }

        private void DisplayList()
        {
            int i = 0;

            Console.WriteLine("Список:");
            Console.WriteLine();

            foreach (int number in list)
            {
                Console.Write($"{number, 4}");
                i++;

                if (i == 25)
                {
                    Console.WriteLine();
                    i = 0;
                }
            }

            Console.WriteLine();
        }

        private void RemoveItemsFromList()
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > 25 && list[i] < 50)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }

            Console.WriteLine("Числа, которые больше 25, но меньше 50 удалены из списка");
            Console.WriteLine();
        }

        public void ShowWorkWithList()
        {
            FillList();
            DisplayList();
            RemoveItemsFromList();
            DisplayList();
            Console.WriteLine();
        }

        #endregion

        #region Задание 2. Телефонная книга

        Dictionary<double, string> dict = new Dictionary<double, string>();

        private double GetOnlyDouble()
        {
            string userInput;
            double requiredValue;
            bool status = false;

            do
            {
                userInput = $"{Console.ReadLine()}";

                if (userInput.Length <= 14)
                {
                    status = double.TryParse(userInput, out var result);

                    if (status == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Недопустимый ввод, введите числовое значение");
                    }
                }
                else
                {
                    Console.WriteLine("Превышено допустимое количество введенных знаков");
                    Console.WriteLine("Введите числовое значение длиной не более 14-ти символов");
                }
            }
            while (status == false);

            return requiredValue = Convert.ToDouble(userInput);
        }

        private string ContinueOrNot()
        {
            Console.WriteLine("Для выхода - введите пробел");
            Console.WriteLine("Для продолжения - любое другое значение");
            string userInput = $"{Console.ReadLine()}";           

            return userInput;
        }

        private void AddNewEntry()
        {
            string status = String.Empty;

            do
            {
                Console.WriteLine("Введите номер телефона в числовом формате без пробелов и дефисов");
                double phoneNumber = GetOnlyDouble();
                Console.WriteLine();                
                
                if (!dict.TryGetValue(phoneNumber, out var value))
                {
                    Console.WriteLine("Введите Ф.И.О. владельца номера");
                    string ownerFIO = $"{Console.ReadLine()}";
                    Console.WriteLine();

                    dict.Add(phoneNumber, ownerFIO);

                    Console.WriteLine("Запись сохранена");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Невозможно добавить запись с таким номером телефона");
                    Console.WriteLine("По данному номеру уже зарегистрирован владелец: " + $"{value}");
                    Console.WriteLine();
                }

                status = ContinueOrNot();
            }
            while (status != " ");
        }

        private void FindOwner()
        {
            string status = String.Empty;

            do
            {
                Console.WriteLine("Введите номер телефона в числовом формате без пробелов и дефисов");
                double phoneNumber = GetOnlyDouble();
                Console.WriteLine();

                if (dict.TryGetValue(phoneNumber, out var value))
                {
                    Console.WriteLine("По данному номеру телефона зарегистрирован: " + $"{value}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("По данному номеру телефона не было зарегистрировано ни одного владельца");
                    Console.WriteLine();
                }               

                status = ContinueOrNot();
            }
            while (status != " ");
        }

        public void PhoneBookMenu()
        {
            Console.WriteLine("Добавить новую запись - введите 1");
            Console.WriteLine("Найти владельца по номеру телефона - введите 2");
            Console.WriteLine("Для выхода - введите пробел");

            string userInput = $"{Console.ReadLine()}";
            Console.WriteLine();

            switch (userInput)
            {
                case "1":
                    AddNewEntry();
                    PhoneBookMenu();
                    break;
                case "2":
                    FindOwner();
                    PhoneBookMenu();
                    break;
                case " ":
                    break;
                default:
                    Console.WriteLine("Выберите один из предложенных вариантов");
                    Console.WriteLine();
                    break;
            }
        }

        #endregion

        #region Задание 3. Проверка повторов

        HashSet<double> set = new HashSet<double>();       

        private void FillHashSet()
        {
            string status = String.Empty;

            do
            {
                Console.WriteLine("Введите число");
                double userInput = GetOnlyDouble();
                Console.WriteLine();

                if (set.Contains(userInput))
                {
                    Console.WriteLine("Данное число уже вводилось ранее");
                    Console.WriteLine();
                }
                else
                {
                    set.Add(userInput);

                    Console.WriteLine("Число успешно сохранено");
                    Console.WriteLine();
                }

                status = ContinueOrNot();
            }
            while (status != " ");
        }

        private void DisplayHashSet()
        {
            Console.WriteLine("Получено множество:");
            Console.WriteLine();

            int i = 0;

            foreach (var item in set)
            {
                Console.Write($"{item}" + "  ");
                i++;

                if (i == 5)
                {
                    Console.WriteLine();
                    i = 0;
                }                
            }
            
            Console.WriteLine();
            Console.WriteLine();
        }

        public void ShowWorkWithHashSet()
        {
            FillHashSet();
            DisplayHashSet();
        }

        #endregion

        #region Задание 4. Записная книжка

        public void NotebookInXmlFormat()
        {
            string userInputString;
            double userInputDouble;

            Console.WriteLine("Введите Ф.И.О.");
            userInputString = $"{Console.ReadLine()}";
            Console.WriteLine();                        

            XElement Person = new XElement("Person");
            XAttribute name = new XAttribute("name", userInputString);
            Person.Add(name);

            XElement Address = new XElement("Address");
            Person.Add(Address);

            Console.WriteLine("Введите название улицы");
            userInputString = $"{Console.ReadLine()}";
            Console.WriteLine();

            XElement Street = new XElement("Street", userInputString);
            Address.Add(Street);

            Console.WriteLine("Введите номер дома");
            userInputString = $"{Console.ReadLine()}";
            Console.WriteLine();

            XElement HouseNumber = new XElement("HouseNumber", userInputString);
            Address.Add(HouseNumber);

            Console.WriteLine("Введите номер квартиры");
            userInputString = $"{Console.ReadLine()}";
            Console.WriteLine();

            XElement FlatNumber = new XElement("FlatNumber", userInputString);
            Address.Add(FlatNumber);

            XElement Phones = new XElement("Phones");
            Person.Add(Phones);

            Console.WriteLine("Введите МОБИЛЬНЫЙ номер телефона в числовом формате без пробелов и дефисов");
            userInputDouble = GetOnlyDouble();
            Console.WriteLine();

            XElement MobilePhone = new XElement("MobilePhone", userInputDouble);
            Phones.Add(MobilePhone);

            Console.WriteLine("Введите ДОМАШНИЙ номер телефона в числовом формате без пробелов и дефисов");
            userInputDouble = GetOnlyDouble();
            Console.WriteLine();

            XElement FlatPhone = new XElement("FlatPhone", userInputDouble);
            Phones.Add(FlatPhone);

            Person.Save("_Person.xml");

            Console.WriteLine("Создан файл _Person.xml");
            Console.WriteLine();           
        }

        #endregion
    }
}
