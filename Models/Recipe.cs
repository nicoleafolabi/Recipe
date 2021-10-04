using System;
namespace RecipeMaker
{
    public class Recipe
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public int Calories {get; set;}
        public string Ingredients {get; set;}
        public Recipe (string name, int calories, string ingredients){
            Name = name;
            Calories = calories;
            Ingredients = ingredients;
        }
        public override string ToString() => $"id/{Id} : name/{Name} : calories/{Calories} : ingredients/{Ingredients}";
    }
}