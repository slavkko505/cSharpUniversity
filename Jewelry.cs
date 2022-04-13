using System;
using System.ComponentModel;

//Клас "JEWELRY" з полями: ID, title, code(*****/*-**), price, data_of_creation (date),
// material(gold/silver/platinum), type(rings/earrings/bracelets).

namespace Jewelry
{
    public class Jewelry : GeneralClass
    {
        private string title, code, date_of_creation, material, type;
        private double price;
        string[] matelialMass = {"gold", "silver", "platinum"};
        string[] typeMass = {"rings", "earrings", "bracelets"};
        
        
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
        
    }
}