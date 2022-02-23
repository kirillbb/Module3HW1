namespace Module3HW1
{
    public static class Starter
    {
        public static void Run()
        {
            StringList();
            IntList();
        }

        private static void IntList()
        {
            MyList<int> myList = new MyList<int>();
            Console.WriteLine("\n- Add items to empty list:");
            myList.Add(5);
            myList.Add(4);
            myList.Add(7);
            myList.Add(9);
            myList.Add(13);
            myList.Add(12);
            myList.Add(1);
            Print(myList);

            int[] arr = { 12, 47, 9, 101, 21 };
            Console.Write($"\n- AddRange: {{ 12, 47, 9, 101, 21 }}");
            Console.WriteLine();
            myList.AddRange(arr);
            Print(myList);

            var value = 47;
            Console.WriteLine($"\n- Remove {{{value}}}:");
            myList.Remove(value);
            Print(myList);

            var index = 2;
            Console.WriteLine($"\n- RemoveAt index [{index}]:");
            myList.RemoveAt(index);
            Print(myList);

            Console.WriteLine("\n- Sort int list:");
            myList.Sort();
            Print(myList);
        }

        private static void StringList()
        {
            MyList<string> stringList = new MyList<string>(new string[4] { "apple", "snickers", "tea", "car" });
            Console.WriteLine("- String List:");
            Print(stringList);

            stringList.Sort();
            Console.WriteLine("\n- Sort string list:");
            Print(stringList);

            Console.WriteLine("\n- Add item \"4ur4hella\":");
            stringList.Add("4ur4hella");
            Print(stringList);
        }

        private static void Print(MyList<int> list)
        {
            foreach (var item in list)
            {
                if (item == 0)
                {
                    continue;
                }

                Console.Write($"{item} ");
            }

            Console.WriteLine($"\nLast Index: {list.LastIndex} Lenght: {list.CurrentLenght}");
        }

        private static void Print(MyList<string> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine($"\nLast Index: {list.LastIndex} Lenght: {list.CurrentLenght}");
        }
    }
}