using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Jewelry
{
    public static class Validation
    {
        public delegate void MyFunction<T>(LstCollection<T> l) where T : GeneralClass, new();
        public static string ValidateTitle(string value)
        {
            if (value=="0") return value;
            if (value.Any(char.IsDigit))
            {
                throw new ArgumentException("Title must not contain integers.");
            }
            return value;
        }
        
        public static double ValidatePrice(double value)
        {
            string strValue = value.ToString(CultureInfo.InvariantCulture).
                IndexOf(".", StringComparison.Ordinal) == -1 ? value.ToString(CultureInfo.InvariantCulture) 
                                                               + "." : value.ToString(CultureInfo.InvariantCulture);
            if (strValue.Substring(strValue.IndexOf(".", StringComparison.Ordinal)).Length > 3)
            {
                throw new ArgumentException("Price must have two digits after coma.");
            }
            return value;
        }
        
        public static string ValidateDate(string value)
        {
            if (value == "0") return value;
            DateTime v = DateTime.Parse(value);
            if (DateTime.Compare(DateTime.Now, v) < 0)
            {
                throw new ArgumentException("Non-existent Date.");
            }
            return v.ToShortDateString();
        }
       
        public static string ValidMatOrType(string value, string[] mas, bool t)
        {
            string str = "";

            if (t)
            {
                str = "material";
            }
            else
            {
                str = "type";
            }
            
            if (!value.Any(char.IsDigit))
            {
                for (int i = 0; i < mas.Length; i++)
                {
                    if (value == mas[i])
                    {
                        return value;
                    }
                }
                throw new ArgumentException($"Wrong {str}");
            }
            throw new ArgumentException($"Wrong {str}");
        }
        
        public static string ValidateCode(string value)
        {
            string code;
            
            if (value.Length != 10 || value[5] != '/' || value[7] != '-')
            {
                throw new ArgumentException("Wrong code");
            }

            code = value[..5] + value[6] + value[8..];
            foreach (var child in code)
            {
                if (!Char.IsDigit(child))
                {
                    throw new ArgumentException("Wrong code");
                }
            }
            return value;
        }
        
        public static string ValidateFile(string value)
        {
            string[] validFileExtensions = { ".txt", ".json"};
            if (!validFileExtensions.Any(value.EndsWith))
            {
                throw new ArgumentException("Incorrect .txt format.");
            }
            return value;
        }
        
        public static List<T> ValidateSearch<T>(List<T> value) where T: GeneralClass
        {
            if (value.Count == 0)
            {
                throw new ArgumentException("There's no such elements!");
            }
            return value;
        }
        
        public static PropertyInfo ValidateEdit(PropertyInfo value)
        {
            if (value == null)
            {
                throw new ArgumentException("Wrong Attribute name");
            }
            return value;
        }

        public static void ValidateInput<T>(LstCollection<T> l, MyFunction<T> f) where T: GeneralClass, new()
        {
            while (true)
            {
                try
                {
                    f(l);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try one more time!");
                    continue;
                }
            }
        }
    }
}