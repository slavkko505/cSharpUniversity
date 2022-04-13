using System;
using System.Reflection;


namespace Jewelry
{
    class MainClass
    {
        private static void read_txt_file<T>(LstCollection<T> l) where T: GeneralClass, new()
        {
            Console.WriteLine("Enter file_name: ");
            var file = Validation.ValidateFile(Console.ReadLine());
            if (file.EndsWith(".txt")) l.ReadTxtFile(file);
            else l.ReadJsonFile(file);
        }
        
        private static void sort_elements<T>(LstCollection<T> l) where T: GeneralClass, new()
        {
            Console.WriteLine("Enter field for which you want to sort: \n" +
                              "POSSIBLE: Title, Code, Price, Date_of_creation, " +
                              "Material, Type, Id:\n");
            l.Sort(Console.ReadLine());
        }
        
        private static void search_elements<T>(LstCollection<T> l) where T: GeneralClass, new()
        {
            Console.WriteLine("Enter parameter which elements you want to find: \n");
            var res = new LstCollection<T>(l.Search(Console.ReadLine()));
            Console.WriteLine(res);
        }
        
        private static void add_elements<T>(LstCollection<T> l) where T: GeneralClass, new()
        {
            var p = new T();
            p.Input();
            l.AddItem(p);
        }
        
        private static void del_product<T>(LstCollection<T> l) where T: GeneralClass, new()
        {
            Console.WriteLine("Enter id to delete: ");
            l.Delete(Console.ReadLine());
        }
        
        private static void edit_product<T>(LstCollection<T> l) where T: GeneralClass, new()
        {
            Console.Write("Enter id to edit: ");
            var id = Console.ReadLine();
            Console.Write("Enter atter to edit: ");
            var atter = Console.ReadLine();
            Console.Write("Enter value to change: ");
            var value = Console.ReadLine();
            l.Edit(id, atter, value);
        }
        
        private static void write_file<T>(LstCollection<T> l) where T: GeneralClass, new()
        {
            Console.WriteLine("Enter file_name: ");
            var file = Validation.ValidateFile(Console.ReadLine());
            if (file.EndsWith(".txt")) l.WriteTxtFile(file);
            else l.WriteJsonFile(file);
        }
        
        private static void add_txt_file<T>(LstCollection<T> l) where T: GeneralClass, new()
        {
            Console.WriteLine("Enter file_name: ");
            l.AddToTxtFile(Validation.ValidateFile(Console.ReadLine()));
        }
        
        private static string get_help_message()
        {
            string helpMessage =
                "\n  Help menu:" +
                "\n  1 - to read from file"  +
                "\n  2 - to sort elements"  +
                "\n  3 - to search element"  +
                "\n  4 - add Jewelry to collection" +
                "\n  5 - to del element from collection" +
                "\n  6 - to edit element from collection"  +
                "\n  7 - to write collection elements to file " +
                "\n  8 - to add  collection elements to txt file " +
                "\n  9 - to print collection" +
                "\n  exit - to exit" + "\n";
            return helpMessage;
        }

        public static void Main(string[] args)
        {
            LstCollection<Jewelry> l = new LstCollection<Jewelry>();;
            while (true) 
            {
                Console.WriteLine(get_help_message());
                string task = Console.ReadLine();
                switch (task)
                {
                    case "1":
                        Validation.ValidateInput(l, read_txt_file);
                        break;
                    case "2":
                        Validation.ValidateInput(l, sort_elements);
                        break;
                    case "3":
                        Validation.ValidateInput(l, search_elements);
                        break;
                    case "4":
                        Validation.ValidateInput(l, add_elements);
                        break;
                    case "5":
                        Validation.ValidateInput(l, del_product);
                        break;
                    case "6":
                        Validation.ValidateInput(l, edit_product);
                        break;
                    case "7":
                        Validation.ValidateInput(l, write_file);
                        break;
                    case "8":
                        Validation.ValidateInput(l, add_txt_file);
                        break;
                    case "9":
                        if(l.Length() >= 0)
                            Console.WriteLine(l);
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("error!");
                        continue;
            }
                Console.WriteLine();
            } 
        }
    }
}