using Microsoft.EntityFrameworkCore.Storage;
using RecipesWebApp.Data;
using RecipesWebApp.Data.Models;
using RecipesWebApp.Data.Repositories;

namespace MyRecipeWebApp.Models;

public class RecipesViewModel
{
    private readonly RecipeRepository _repo;
    
    public List<Recipes> RecipeList { get; set; }
    
    public Recipes CurrentRecipe { get; set; }
    
    public bool IsActionSuccess { get; set; }

    public string ActionMessage { get; set; } = "";
    
    public RecipesViewModel(PracticeContext context)
    {
        _repo = new RecipeRepository(context);
        RecipeList = GetAllRecipes();
        CurrentRecipe = RecipeList.FirstOrDefault()!;
    }

    public RecipesViewModel(PracticeContext context, int recipeId)
    {
        _repo = new RecipeRepository(context);
        RecipeList = GetAllRecipes();
        CurrentRecipe = recipeId > 0 ? GetRecipe(recipeId) : new Recipes();
    }

    public void SaveRecipe(Recipes recipes)
    {
        if (recipes.RecipeId > 0)
        {
            _repo.Update(recipes);
        }
        else
        {
            recipes.RecipeId = _repo.Create(recipes);
        }

        RecipeList = GetAllRecipes();
        CurrentRecipe = GetRecipe(recipes.RecipeId);
    }

    public void RemoveRecipe(int recipeId)
    {
        _repo.Delete(recipeId);
        RecipeList = GetAllRecipes();
        CurrentRecipe = RecipeList.FirstOrDefault()!;
    }
    
    public List<Recipes> GetAllRecipes()
    {
        return _repo.GetAllRecipes();
    }
    
    public Recipes GetRecipe(int recipeId)
    {
        return _repo.GetRecipeById(recipeId);
    }
}