using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Torts
{
    public class Menu
    {
        public Menu PlayMenu { get; set; }
        public string Zagolovok { get; set; }
        public string Arrow { get; set; }

        public int AllPrice { get; private set; } = 0;

        private List<ElementsofMenu> ItemList;
        public int[] prices = new int[] { };

        private int position;
        private bool Exit;

        public Menu(string arrow = "->")
        {
            ItemList = new List<ElementsofMenu>();
            position = 0;

            this.Arrow = arrow;
        }
        public void Draw()
        {
            Console.Clear();
            Console.WriteLine(Zagolovok);

            for (int i = 0; i < ItemList.Count; i++)
            {
                if (i == position)
                {
                    Console.Write(Arrow + " ");
                    Console.WriteLine(ItemList[i].Discription);
                }
                else
                {
                    Console.Write(new string(' ', (Arrow.Length + 0)));
                    Console.WriteLine(ItemList[i].Discription);
                }
            }
            Console.WriteLine("\nЦена:" + Global.Price);
            Console.WriteLine("\nЗаказ: ");
            foreach (string item in Global.Order)
            {
                Console.WriteLine(item);
            }
        }
        public void ShowMenu()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Draw();
            Exit = false;
            while (!Exit)
            {
                MenuUpdate();

            }
        }

        public void HideMenu()
        {

            Exit = true;
        }

        public void MenuUpdate()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Enter:
                    {
                        Console.Clear();
                        Console.CursorVisible = true;
                        ItemList[position].Action();
                        Global.Price += ItemList[position].Price;
                        Global.Order.Add(ItemList[position].Discription);
                        Console.CursorVisible = false;
                        Console.Clear();
                        Draw();
                        break;
                    }
                case ConsoleKey.Escape:
                    {
                        if (PlayMenu != null)
                        {
                            HideMenu();
                        }
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        position--;
                        if (position < 0)
                        {
                            position++;
                            Console.Clear();
                            Draw();

                        }
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {

                        if (position < (ItemList.Count - 1))
                        {
                            position++;
                            Console.Clear();
                            Draw();

                        }
                        break;
                    }
            }
        }

        public bool AddItem(int meh, string discription, int price, Action action)
        {
            if (!ItemList.Any(item => item.meh == meh))
            {

                ItemList.Add(new ElementsofMenu(meh, discription, price, action));

                return true;
            }
            return false;
        }
    }
}
