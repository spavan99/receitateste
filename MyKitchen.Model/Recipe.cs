using System.Runtime;

namespace MyKitchen.Model
{
    //o que que é
    public class Recipe
    {
        //o que que tem
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public User Owner { get; set; }
        public Category Category { get; set; }
        public int PreparationTime { get; set; } //Intervalo em minutos
        public string PreparationMethod { get; set; }
        public Difficulty Difficulty { get; set; }
        public bool IsApproved { get; set; }
        public List<IngredientLine> Ingredients { get; set; }
        public string Image {  get; set; }
        public double Rating { get; set; }

        //o que que faz
    }
}