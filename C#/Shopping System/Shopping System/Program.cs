using System;

namespace Shopping_System
{
    internal class Program
    {
        static List<string> CartItems = new List<string>();
        static Dictionary<string, double> ItemPrice = new Dictionary<string, double>()
        {
            {"camera" , 1000},
            {"tv" , 2000},
            {"laptop" , 3000 }       
        };

        static Stack<string> actions = new Stack<string>();
        static void DisplayOptions()
        {
            Console.WriteLine(" 1. add item to cart \n 2. view cart \n 3. remove item from the cart \n 4. checkout \n 5. undo last action \n 6. exit");
            Console.WriteLine("enter your choice number | ");
        }
        static void Main(string[] args)
        {
            #region Design
            // add item to cart
            // view cart
            // remove item from the cart
            // checkout
            // undo last action
            //exit
            #endregion

            while (true)
            {
                DisplayOptions();

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddItem();
                        break;
                    case 2:
                        ViewCart();
                        break;
                    case 3:
                        RemoveItem();
                        break;
                    case 4:
                        Checkout();
                        break;
                    case 5:
                        Undo();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("inalid choice");
                        break;


                }
            }
            






        }

        private static void AddItem()
        {
            Console.Clear();
            // diaplaying existing items
            Console.WriteLine("Available items | ");
            foreach (var item in ItemPrice)
            {
                Console.WriteLine($"Item : {item.Key} , Price : {item.Value}");
            }

            Console.WriteLine("enter the item you want to add to the cart ");
            string Cartitem = Console.ReadLine();

            if (ItemPrice.Keys.Contains(Cartitem)) // ContainsKey() 
            {
                CartItems.Add(Cartitem);
                actions.Push($"add {Cartitem} to cart");
                Console.WriteLine($"item {Cartitem} is added to your cart");
            }
            else
            {
                Console.WriteLine("this item not exist in the store");
            }

            //Console.Clear();



        }

        private static bool ViewCart()
        {
            Console.Clear();

            if (CartItems.Any()) // CartItems.Count > 0
            {
                Console.WriteLine("your cart : ");
                foreach (var item in CartItems)
                {
                    Console.WriteLine($"Item : {item}  Price : {ItemPrice[item]}");
                }
                return true;
                ///ItemPrice.TryGetValue(item , out double key)
                
            }


            else
            {
                Console.WriteLine("cart is empty");
                return false;
            }

        }

        private static void RemoveItem()
        {
            Console.Clear();
            if ( ViewCart())
            {
                Console.WriteLine("enter the item you want to remove from the cart ");
                string Cartitem = Console.ReadLine();

                if (CartItems.Contains(Cartitem)) // ContainsKey() 
                {
                    CartItems.Remove(Cartitem);
                    actions.Push($"remove {Cartitem} from cart");

                    Console.WriteLine($"item {Cartitem} is removed from your cart");
                }
                else
                {
                    Console.WriteLine("this item not exist in the cart");
                }
            }

        }


        private static void Checkout()
        {
            if (ViewCart())
            {
                ViewCart();
                double total = 0;

                foreach (var item in CartItems)
                {
                    total += ItemPrice[item];
                }

                Console.WriteLine("===========================");
                Console.WriteLine($"Total : {total}");
                CartItems.Clear();
                actions.Push("checkout");
            }
            else
            {
                Console.WriteLine("your cart is empty");
            }
        }

        private static void Undo()
        {
            // store the actions in stack  LIFO

            if (actions.Any())
            {
                string lastAction = actions.Pop();
                Console.WriteLine($"Your last action is {lastAction}");
                Console.WriteLine($"last action is undone");

                if (lastAction.Split()[0] == "add")
                {
                    CartItems.Remove(lastAction.Split()[1]);
                }
                else if (lastAction.Split()[0] == "remove")
                {
                    CartItems.Add(lastAction.Split()[1]);
                }
                else if (lastAction.Split()[0] == "checkout")
                {
                    Console.WriteLine("can't undo checkout");
                }

            }
            
        }

        /// list of tubles
        /// tubles contains up to 8 items
        //private static List<Tuple<string, int>> Test()
        private static IEnumerable<Tuple<string, int>> Test()

        {
            var items = new List<Tuple<string, int>>();
            items.Add(new Tuple<string,int>("sam" ,10));
            return items;
            /// all collections impelement  => abstraction
            /// any function that uses this this function can cast IEnumerable to any colletion
            /// IEnumerable  => non mutaple => an't change on it => gives security
            ///IEnumerable => iterable
            /// if you need to modify it => cast it to List
            /// items.ToList()
        }
    }
}
