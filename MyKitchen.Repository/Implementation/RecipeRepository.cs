using Microsoft.Data.SqlClient;
using MyKitchen.Model;
using MyKitchen.Repository.Interface;

namespace MyKitchen.Repository.Implementation
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly string _tableName = "recipes";

        public Recipe Create(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Recipe Retrieve(int id)
        {
            throw new NotImplementedException();
        }

        public List<Recipe> RetrieveAll()
        {
            string sql = $"SELECT * FROM {_tableName};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Recipe> recipes = new List<Recipe>();
            while (reader.Read())
            {
                recipes.Add(Parse(reader));
            }
            return recipes;
        }

        public Recipe Update(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        private Recipe Parse(SqlDataReader reader)
        {
            Recipe recipe = new Recipe()
            {
                Id = Convert.ToInt32(reader["id"]),
                Name = Convert.ToString(reader["name"]),
                Description = Convert.ToString(reader["description"]),
                Owner = new User() { Id = Convert.ToInt32(reader["id_user"]) },
                Category = new Category() { Id = Convert.ToInt32(reader["id_category"]) },
                PreparationTime = Convert.ToInt32(reader["prep_time"]),
                PreparationMethod = Convert.ToString(reader["prep_method"]),
                Difficulty = new Difficulty() { Id = Convert.ToInt32(reader["id_difficulty"]) },
                Ingredients = new List<IngredientLine>(),
                IsApproved = Convert.ToBoolean(reader["is_approved"]),
                Image = Convert.ToString(reader["image"])
            };

            return recipe;
        }
    }
}
