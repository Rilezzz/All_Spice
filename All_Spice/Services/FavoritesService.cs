
namespace All_Spice.Services;

public class FavoritesService
{
  private readonly FavoritesRepository _favoritesRepository;

  public FavoritesService(FavoritesRepository favoritesRepository)
  {
    _favoritesRepository = favoritesRepository;
  }



  // CREATE FAVORITE
  internal Favorite CreateFavorite(Favorite favoriteData)
  {
    Favorite favorite = _favoritesRepository.CreateFavorite(favoriteData);
    return favorite;
  }





  // GET FAVORITES BY RECIPE ID
  internal List<ProfileFavorites> GetFavoritesByRecipeId(int recipeId)
  {
    List<ProfileFavorites> favorites = _favoritesRepository.GetFavoritesByRecipeId(recipeId);
    return favorites;
  }




  // GET FAVORITES BY ACCOUNT
  internal List<RecipeFavorites> GetMyProfileFavorites(string userId)
  {
    List<RecipeFavorites> favorites = _favoritesRepository.GetMyProfileFavorites(userId);

    return favorites;
  }





  // REMOVE FAVORITE RECIPE
  internal void RemoveFavoriteRecipe(int favoriteId, string userId)
  {
    Favorite favorite = GetFavoriteRecipeById(favoriteId);

    if (favorite.AccountId != userId)
    {
      throw new Exception("You cannot remove this recipe if it is not in your favorites.");
    }

    _favoritesRepository.RemoveFavoriteRecipe(favoriteId);
  }



  // GET FAVORITE RECIPE BY ID 
  internal Favorite GetFavoriteRecipeById(int favoriteId)
  {
    Favorite favorite = _favoritesRepository.GetFavoriteRecipeById(favoriteId);

    if (favorite == null)
    {
      throw new Exception($"No recipe with ID of{favoriteId}");
    }

    return favorite;

  }
}

