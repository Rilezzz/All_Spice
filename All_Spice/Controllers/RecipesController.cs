

namespace All_Spice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
  private readonly RecipesService _recipesService;
  private readonly Auth0Provider _auth0Provider;
  private readonly IngredientsService _ingredientsService;
  private readonly FavoritesService _favoritesService;


  public RecipesController(RecipesService recipesService, Auth0Provider auth0Provider, IngredientsService ingredientsService, FavoritesService favoritesService)
  {
    _recipesService = recipesService;
    _auth0Provider = auth0Provider;
    _ingredientsService = ingredientsService;
    _favoritesService = favoritesService;
  }

  // CREATE RECIPES
  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      recipeData.CreatorId = userInfo.Id;
      Recipe recipe = _recipesService.CreateRecipe(recipeData);
      return recipe;
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }




  // GET RECIPES BY ID
  [HttpGet("{recipeId}")]
  public ActionResult<Recipe> GetRecipeById(int recipeId)
  {
    try
    {
      Recipe recipe = _recipesService.GetRecipeById(recipeId);
      return Ok(recipe);

    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }


  }



  // GET ALL RECIPES
  [HttpGet]
  public ActionResult<List<Recipe>> GetRecipes()
  {
    try
    {
      List<Recipe> recipes = _recipesService.GetRecipes();
      return Ok(recipes);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }





  // UPDATE RECIPES
  [HttpPut("{recipeId}")]
  public ActionResult<Recipe> UpdateRecipe(int recipeId, [FromBody] Recipe recipeData)
  {
    try
    {
      Recipe recipe = _recipesService.UpdateRecipe(recipeId, recipeData);
      return Ok(recipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }




  // REMOVE RECIPES
  [HttpDelete("{recipeId}")]
  public ActionResult<string> RemoveRecipe(int recipeId)
  {
    try
    {
      Recipe recipe = _recipesService.RemoveRecipe(recipeId);

      return Ok($"{recipe.Title} has been deleted");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }




  // GET INGREDIENTS BY RECIPE ID
  [HttpGet("{recipeId}/ingredients")]
  public ActionResult<List<Ingredient>> GetIngredientsByRecipeId(int recipeId)
  {
    try
    {
      List<Ingredient> ingredients = _ingredientsService.GetIngredientsByRecipeId(recipeId);
      return Ok(ingredients);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }




  // GET FAVORITES BY RECIPE ID
  [HttpGet("{recipeId}/favorites")]
  public ActionResult<List<ProfileFavorites>> GetFavoritesByRecipeId(int recipeId)
  {
    try
    {
      List<ProfileFavorites> favorites = _favoritesService.GetFavoritesByRecipeId(recipeId);
      return Ok(favorites);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}

