using System;
using System.ComponentModel;

//Клас "JEWELRY" з полями: ID, title, code(*****/*-**), price, data_of_creation (date),
// material(gold/silver/platinum), type(rings/earrings/bracelets).

namespace Jewelry
{
    public class Jewelry
    {
        private string id,title, code, date_of_creation, material, type;
        private double price;
        string[] matelialMass = {"gold", "silver", "platinum"};
        string[] typeMass = {"rings", "earrings", "bracelets"};
        public Jewelry InputProduct()
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
        public string Id { get; set; }
        
        public string Title
        {
            get => title; 
            set => title = Validation.ValidateTitle(value); 
        }
        
        public string Code
        {
            get => code; 
            set => code = Validation.ValidateCode(value); 
        }
        
        public double Price
        {
            get => price;
            set => price = Validation.ValidatePrice(value); 
        }
        
        public string Date_of_creation
        {
            get => date_of_creation;
            set => date_of_creation = Validation.ValidateDate(value);
        }
       
        public string Material
        {
            get => material;
            set => material = Validation.ValidMatOrType(value, matelialMass,true);
        }
        
        public string Type
        {
            get => type;
            set => type = Validation.ValidMatOrType(value, typeMass, false);
        }

        public override string ToString() {
            string res = "";
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(this)) 
                res += ($"{prop.Name}: {prop.GetValue(this)}\n");
            return res.Substring(0, res.Length-1);
        }
    }
}