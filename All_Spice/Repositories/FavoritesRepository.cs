
namespace All_Spice.Repositories;

public class FavoritesRepository
{
  private readonly IDbConnection _db;

  public FavoritesRepository(IDbConnection db)
  {
    _db = db;
  }




  // CREATE FAVORITE
  internal Favorite CreateFavorite(Favorite favoriteData)
  {
    string sql = @"
      INSERT INTO favorites (accountId, recipeId)
      VALUES (@AccountId, @RecipeId);
      SELECT LAST_INSERT_ID()
      ;";
    int profileFavoriteId = _db.ExecuteScalar<int>(sql, favoriteData);
    favoriteData.Id = profileFavoriteId;
    return favoriteData;
  }






  // GET FAVORITES BY RECIPE ID
  internal List<ProfileFavorites> GetFavoritesByRecipeId(int recipeId)
  {
    string sql = @"
      SELECT
      fav.*,
      acc.*
      FROM favorites fav
      JOIN accounts acc ON acc.id = fav.accountId
      WHERE fav.recipeId = @recipeId
      ;";

    List<ProfileFavorites> favorites = _db.Query<Favorite, ProfileFavorites, ProfileFavorites>(
      sql,
      (favorite, profile) =>
      {
        profile.FavoriteId = favorite.Id;
        return profile;
      },
      new { recipeId }).ToList();
    return favorites;
  }





  // GET FAVORITES BY ACCOUNT
  internal List<RecipeFavorites> GetMyProfileFavorites(string userId)
  {
    string sql = @"
      SELECT
      fav.*,
      rec.*,
      acc.*
      FROM favorites fav
      JOIN recipes rec ON rec.id = fav.recipeId
      JOIN accounts acc ON acc.id = rec.creatorId
      WHERE fav.accountId = @userId
      ;";

    List<RecipeFavorites> favorites = _db.Query<Favorite, RecipeFavorites, Profile, RecipeFavorites>(
      sql,
      (favorite, recipe, profile) =>
      {
        recipe.FavoriteId = favorite.Id;
        recipe.Creator = profile;
        return recipe;
      },
      new { userId }
    ).ToList();

    return favorites;
  }




  // REMOVE FAVORITE RECIPE
  internal void RemoveFavoriteRecipe(int favoriteId)
  {
    string sql = "DELETE FROM favorites WHERE id = @favoriteId LIMIT 1";
    _db.Execute(sql, new { favoriteId });

  }




  // GET FAVORITE RECIPE BY ID
  internal Favorite GetFavoriteRecipeById(int favoriteId)
  {
    string sql = "SELECT * FROM favorites WHERE id = @favoriteId;";
    Favorite favorite = _db.QueryFirstOrDefault<Favorite>(sql, new { favoriteId });
    return favorite;
  }
}
