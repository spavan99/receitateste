using MyKitchen.Model;
using System.Text.Json;

namespace MyKitchen.Sandbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Recipe receita = new Recipe();

            receita.Name = "Brigadeiro";
            receita.Difficulty = new Difficulty() { Name = "Easy" };
            receita.PreparationMethod = "Coloque o leite condensado numa panela com manteiga...";
            receita.PreparationTime = 40;
            receita.Category = new Category() { Name = "Doçes" };
            receita.Description = "Uma sobremesa saborosa...";
            receita.Owner = new User() { Name = "Yuri" };

            List<IngredientLine> ingredientLines = new List<IngredientLine>();
            
            IngredientLine leiteCondensado = new IngredientLine();
            leiteCondensado.Ingredient = new Ingredient() { Name = "Leite condensado"};
            leiteCondensado.Amount = 600;
            leiteCondensado.MeasureUnit = new MeasureUnit() { Name = "Gr" };
            //leiteCondensado.Recipe = receita;

            IngredientLine achocolatado = new IngredientLine();
            achocolatado.Ingredient = new Ingredient() { Name = "Achocolatado" };
            achocolatado.Amount = 6;
            achocolatado.MeasureUnit = new MeasureUnit() { Name = "Colher de sopa" };
           // achocolatado.Recipe = receita;

            IngredientLine manteiga = new IngredientLine();
            manteiga.Ingredient = new Ingredient() { Name = "Manteiga" };
            manteiga.Amount = 2;
            manteiga.MeasureUnit = new MeasureUnit() { Name = "Colher de sopa" };
            //manteiga.Recipe = receita;

            ingredientLines.Add(leiteCondensado);
            ingredientLines.Add(achocolatado);
            ingredientLines.Add(manteiga);

            receita.Ingredients = ingredientLines;


            Console.WriteLine(JsonSerializer.Serialize(receita));
        }
    }
}