using RecipesWebApp.Data.Models;

namespace RecipesWebApp.Data.Repositories;

public class RecipeRepository
{
    private readonly PracticeContext _context;

    public RecipeRepository(PracticeContext context)
    {
        _context = context;
    }
    
    //Create
    public int Create(Recipes recipes)
    {
        _context.Add(recipes);

        _context.SaveChanges();

        return recipes.RecipeId;
    }
    
    //Update
    public void Update(Recipes recipes)
    {
        Recipes existingRecipes = _context.Recipes.Find(recipes.RecipeId)!;

        existingRecipes.RecipeName = recipes.RecipeName;
        existingRecipes.MealType = recipes.MealType;
        existingRecipes.MainIngredients = recipes.MainIngredients;
        existingRecipes.PrepTime = recipes.PrepTime;

        _context.SaveChanges();
    }
    
    //Delete
    public void Delete(int recipeId)
    {
        Recipes recipes = _context.Recipes.Find(recipeId)!;

        _context.Remove(recipes);

        _context.SaveChanges();
    }
    
    //Get all
    public List<Recipes> GetAllRecipes()
    {
        List<Recipes> recipeList = _context.Recipes.ToList();
        return recipeList;
    }
    
    //Get by Id
    public Recipes GetRecipeById(int recipeId)
    {
        Recipes recipes = _context.Recipes.Find(recipeId)!;
        return recipes;
    }
}