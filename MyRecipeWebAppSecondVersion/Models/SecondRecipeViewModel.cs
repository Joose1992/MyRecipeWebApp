using RecipesWebApp.Data.Models;

namespace MyRecipeWebAppSecondVersion.Models
{
    public class SecondRecipeViewModel
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string MealType { get; set; }
        public string MainIngredients { get; set; }
        public string PrepTime { get; set; }
        
        public bool IsSuccess { get; set; }
        public string AccionMessage { get; set; }
        public bool IsDeleted { get; set; }

        public Recipes CurrentRecipe { get; set; }
        public List<Recipes> RecipeList { get; set; }
    }
}
