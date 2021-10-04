using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace RecipeMaker
{
    [ApiController]
    [Route("api/recipe")]
    public class RecipeController : ControllerBase
    {
        private Database _db;

        public RecipeController(Database db)
        {
            _db = db;

        }

        [HttpGet("createRecipe/{name}/{calories}/{ingredients}")]
        public ActionResult<Recipe> GetRecipeObject(string name, int calories, string ingredients)
        {

            Recipe recipe = new Recipe(name, calories, ingredients);

            return recipe;
        }
        [HttpPost]
        public IActionResult createRecipe(Recipe recipe)
        {
            _db.Add(recipe);
            _db.SaveChanges();

            return Ok(recipe);

        }
         [HttpGet]
    public IActionResult GetAllRecipes()
    {
      var recipies = _db.Recipes.ToList();
      return Ok(recipies);
    }
       [HttpGet("{ingredients}")]
    public IActionResult GetRecipeById(string ingredients)
    {
      var recipe = _db.Recipes.Where(d => d.Ingredients.Contains(ingredients));
      if (recipe is null) return NotFound();
      
      return Ok(recipe);
    }
    }
}