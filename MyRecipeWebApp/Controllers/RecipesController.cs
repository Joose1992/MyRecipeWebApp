using Microsoft.AspNetCore.Mvc;
using MyRecipeWebApp.Models;
using RecipesWebApp.Data;
using RecipesWebApp.Data.Models;

namespace MyRecipeWebApp.Controllers;

public class RecipesController : Controller
{
    private readonly PracticeContext _context;

    public RecipesController(PracticeContext context)
    {
        _context = context;
    }
    // GEt
    public IActionResult Index()
    {
        RecipesViewModel model = new RecipesViewModel(_context);
        return View();
    }
    
    [HttpPost]
    public IActionResult Index(int recipeId, string recipeName, string mealType, string mainIngredients, string prepTime)
    {
        RecipesViewModel model = new RecipesViewModel(_context);
        
        Recipes recipes = new(recipeId, recipeName, mealType, mainIngredients, prepTime);
        
        model.SaveRecipe(recipes);
        model.IsActionSuccess = true;
        model.ActionMessage = "Recipe has been saved successfully";
        
        return View(model);
    }

    public IActionResult Update(int id)
    {
        RecipesViewModel model = new(_context, id);

        return View(model);
    }

    public IActionResult Delete(int id)
    {
        RecipesViewModel model = new(_context);

        if (id > 0)
        {
            model.RemoveRecipe(id);
            model.IsActionSuccess = true;
            model.ActionMessage = "Recipe has been deleted successfully";
        }

        return View("Index",model);
    }
}