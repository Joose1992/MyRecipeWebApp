namespace RecipesWebApp.Data.Models;

public class Recipes
{
    public int  RecipeId { get; set; }
    
    public string RecipeName { get; set; } = "";

    public string MealType { get; set; } = "";

    public string MainIngredients { get; set; } = "";

    public string PrepTime { get; set; } = "";

    public Recipes(int recipeId, string recipeName, string mealType, string mainIngredients, string prepTime)
    {
        RecipeId = recipeId;
        RecipeName = recipeName;
        MealType = mealType;
        MainIngredients = mainIngredients;
        PrepTime = prepTime;
    }

    public Recipes()
    {
        
    }

}