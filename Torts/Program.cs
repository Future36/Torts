using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Torts
{
    internal class Program
    {
        static void Main()
        {
            Menu mainMenu = new Menu();
            Menu TortForm = new Menu("->");
            TortForm.Zagolovok = "Форма торта";
            TortForm.AddItem(0, "Квадрат - 250", 250, TortForm.HideMenu);
            TortForm.AddItem(1, "Круг - 400", 300, TortForm.HideMenu);
            TortForm.AddItem(2, "Треугольник - 500", 500, TortForm.HideMenu);
            TortForm.AddItem(3, "Сердце - 1000", 1000, TortForm.HideMenu);
            TortForm.PlayMenu = mainMenu;



            Menu CakeSize = new Menu("->");
            CakeSize.Zagolovok = "Размер торта";
            CakeSize.AddItem(0, "Маленький - 500", 500, CakeSize.HideMenu);
            CakeSize.AddItem(1, "Средний - 1000", 1000, CakeSize.HideMenu);
            CakeSize.AddItem(2, "Большой - 1500", 1500, CakeSize.HideMenu);
            CakeSize.AddItem(3, "ОГРОМНЫЙ - 5000", 5000, CakeSize.HideMenu);

            CakeSize.PlayMenu = mainMenu;

            Menu CakeFlavour = new Menu("->");
            CakeFlavour.Zagolovok = "Вкус коржей";
            CakeFlavour.AddItem(0, "Шоколад - 500", 500, CakeFlavour.HideMenu);
            CakeFlavour.AddItem(1, "Ваниль - 200", 200, CakeFlavour.HideMenu);
            CakeFlavour.AddItem(2, "Шоколад+Ваниль - 600", 600, CakeFlavour.HideMenu);
            CakeFlavour.AddItem(3, "Карамель - 500", 500, CakeFlavour.HideMenu);
            CakeFlavour.prices = new int[] { 500, 200, 600, 500 };
            CakeFlavour.PlayMenu = mainMenu;

            Menu CakeFilling = new Menu("->");
            CakeFilling.Zagolovok = "Начинка торта";
            CakeFilling.AddItem(0, "Шоколад - 250", 250, CakeFilling.HideMenu);
            CakeFilling.AddItem(1, "Ваниль - 200", 200, CakeFilling.HideMenu);
            CakeFilling.AddItem(2, "Карамель - 500", 500, CakeFilling.HideMenu);
            CakeFilling.AddItem(3, "Натуральный манго - 1000", 1000, CakeFilling.HideMenu);
            CakeFilling.prices = new int[] { 250, 200, 500, 1000 };


            CakeFilling.PlayMenu = mainMenu;

            Menu CountYarys = new Menu("->");
            CountYarys.Zagolovok = "Количество ярусов";
            CountYarys.AddItem(0, "Один ярус - 500", 500, CountYarys.HideMenu);
            CountYarys.AddItem(1, "Два яруса - 900", 900, CountYarys.HideMenu);
            CountYarys.AddItem(2, "Три яруса - 1300", 1300, CountYarys.HideMenu);

            CountYarys.PlayMenu = mainMenu;

            Menu Dekor = new Menu("->");
            Dekor.Zagolovok = "Декор";
            Dekor.AddItem(0, "Мармелад - 200", 200, Dekor.HideMenu);
            Dekor.AddItem(1, "Ягоды - 500", 500, Dekor.HideMenu);
            Dekor.AddItem(2, "Авторская мастика", 2000, Dekor.HideMenu);
            Dekor.AddItem(3, "Без декора", 0, Dekor.HideMenu);

            Dekor.PlayMenu = mainMenu;
            mainMenu.Zagolovok = "  Кафе Чаепитие";
            mainMenu.AddItem(0, "Форма Торта", 0, TortForm.ShowMenu);
            mainMenu.AddItem(1, "Размер Торта", 0, CakeSize.ShowMenu);
            mainMenu.AddItem(2, "Вкус Коржей", 0, CakeFlavour.ShowMenu);
            mainMenu.AddItem(3, "Начинка торта", 0, CakeFilling.ShowMenu);
            mainMenu.AddItem(4, "Количество ярусов", 0, CountYarys.ShowMenu);
            mainMenu.AddItem(5, "Декор", 0, Dekor.ShowMenu);
            mainMenu.AddItem(6, "Конец оформления заказа", 0, Exit);

            mainMenu.ShowMenu();


            static void Exit()
            {
                Console.WriteLine("Ваш чек готов!");

                string path = "C:\Users\rusla\Desktop\Voicevision 8";
                string text = "Описание заказа";
                foreach (string item in Global.Order) { Console.WriteLine(item); };
                string price = "Цена: " + Global.Price;
                if (File.Exists(path))
                {
                    File.AppendAllText(path, text);
                    File.AppendAllText(path, price);
                }
                else
                {
                    File.Create(path);
                }
                Environment.Exit(0);
            }

        }

    }

}
