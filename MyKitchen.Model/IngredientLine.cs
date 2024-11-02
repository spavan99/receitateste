namespace MyKitchen.Model
{
    public class IngredientLine
    {
        public int Id { get; set; }
        public Ingredient Ingredient { get; set; }
        //public Recipe Recipe { get; set; }
        public int Amount { get; set; }
        public MeasureUnit MeasureUnit { get; set; }
    }
}
