using System;
using System.ComponentModel;

namespace Jewelry
{
    public abstract class GeneralClass
    {
        public string Id { get; set; }
        
        public GeneralClass Input()
        {
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(this))
            {
                if (prop.Name != "Id")
                {
                    Console.Write($"{prop.Name}: ");
                    prop.SetValue(this, Convert.ChangeType(Console.ReadLine(), prop.PropertyType));
                }
                this.Id = Guid.NewGuid().ToString();
            }
            return this;
        }
        
        public override string ToString() {
            string res = "";
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(this)) 
                res += ($"{prop.Name}: {prop.GetValue(this)}\n");
            return res.Substring(0, res.Length-1);
        }
    }
}