

namespace All_Spice.Services;

public class RecipesService
{

  private readonly RecipesRepository _recipeRepository;

  public RecipesService(RecipesRepository recipeRepository)
  {
    _recipeRepository = recipeRepository;
  }



  // CREATE RECIPES
  internal Recipe CreateRecipe(Recipe recipeData)
  {
    int recipeId = _recipeRepository.CreateRecipe(recipeData);

    Recipe recipe = GetRecipeById(recipeId);

    return recipe;
  }






  // GET RECIPES BY ID
  internal Recipe GetRecipeById(int recipeId)
  {
    Recipe recipe = _recipeRepository.GetRecipeById(recipeId);

    if (recipe == null)
    {
      throw new Exception("Request Successful");
    }

    return recipe;
  }






  // GET ALL RECIPES
  internal List<Recipe> GetRecipes()
  {
    List<Recipe> recipes = _recipeRepository.GetRecipes();
    return recipes;
  }







  // UPDATE RECIPES
  internal Recipe UpdateRecipe(int recipeId, Recipe recipeData)
  {
    Recipe originalRecipe = GetRecipeById(recipeId);

    originalRecipe.Title = recipeData.Title ?? originalRecipe.Title;
    originalRecipe.Instructions = recipeData.Instructions ?? originalRecipe.Instructions;
    originalRecipe.Img = recipeData.Img ?? originalRecipe.Img;
    originalRecipe.Category = recipeData.Category ?? originalRecipe.Category;
    Recipe recipe = _recipeRepository.UpdateRecipe(originalRecipe);
    return recipe;
  }






  // REMOVE RECIPES
  internal Recipe RemoveRecipe(int recipeId)
  {
    Recipe recipe = GetRecipeById(recipeId);
    _recipeRepository.RemoveRecipe(recipeId);
    return recipe;
  }

}
