

namespace All_Spice.Services;

public class IngredientsService
{

  private readonly IngredientsRepository _ingredientsRepository;

  public IngredientsService(IngredientsRepository ingredientsRepository)
  {
    _ingredientsRepository = ingredientsRepository;
  }



  // CREATE INGREDIENT

  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    int ingredientId = _ingredientsRepository.CreateIngredient(ingredientData);
    Ingredient ingredient = GetIngredientById(ingredientId);
    return ingredient;
  }





  // GET INGREDIENT BY ID 
  internal Ingredient GetIngredientById(int ingredientId)
  {
    Ingredient ingredient = _ingredientsRepository.GetIngredientById(ingredientId);

    if (ingredient == null)
    {
      throw new Exception($"No Ingredient by ID of {ingredient.Id}");
    }

    return ingredient;
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    List<Ingredient> ingredients = _ingredientsRepository.GetIngredientsByRecipeId(recipeId);
    return ingredients;
  }






  // REMOVE INGREDIENT
  internal void RemoveIngredient(int ingredientId, string userId)
  {
    Ingredient ingredient = GetIngredientById(ingredientId);

    if (ingredient.CreatorId != userId)
    {
      throw new Exception("NOT YOUR DATA");
    }

    _ingredientsRepository.RemoveIngredient(ingredientId);
  }
}
