namespace Collections
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Repository repositoryExemplar = new Repository();           

            void Menu()
            {
                Console.WriteLine("Задание 1. Работа с листом - введите 1");
                Console.WriteLine("Задание 2. Телефонная книга - введите 2");
                Console.WriteLine("Задание 3. Проверка повторов - введите 3");
                Console.WriteLine("Задание 4. Записная книжка - введите 4");
                Console.WriteLine("Для выхода - введите пробел");

                string userInput = $"{Console.ReadLine()}";
                Console.WriteLine();

                switch (userInput)
                {
                    case "1":
                        repositoryExemplar.ShowWorkWithList();
                        break;
                    case "2":
                        repositoryExemplar.PhoneBookMenu();
                        break;
                    case "3":
                        repositoryExemplar.ShowWorkWithHashSet();
                        break;
                    case "4":
                        repositoryExemplar.NotebookInXmlFormat();
                        break;
                    case " ":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Выберите один из предложенных вариантов");
                        Console.WriteLine();
                        break;
                }

                Menu();
            }

            Menu();            
        }
    }
}