

namespace All_Spice.Repositories;

public class RecipesRepository
{

  private readonly IDbConnection _db;

  public RecipesRepository(IDbConnection db)
  {
    _db = db;
  }




  // CREATE RECIPES
  internal int CreateRecipe(Recipe recipeData)
  {
    string sql = @"
    INSERT INTO recipes (title, img, instructions, category,  creatorId)
    VALUES (@Title, @Img, @Instructions, @Category, @CreatorId);
    SELECT LAST_INSERT_ID()
    ;";

    int recipeId = _db.ExecuteScalar<int>(sql, recipeData);

    return recipeId;
  }





  // GET RECIPES BY ID
  internal Recipe GetRecipeById(int recipeId)
  {
    string sql = @"
    SELECT 
    rec.*,
    acc.* 
    FROM recipes rec
    JOIN accounts acc ON acc.id = rec.creatorId 
    WHERE rec.id = @recipeId LIMIT 1
    ;";

    Recipe recipe = _db.Query<Recipe, Profile, Recipe>(
      sql,
      (recipe, profile) =>
      {
        recipe.Creator = profile;
        return recipe;
      },
      new { recipeId }).FirstOrDefault();
    return recipe;
  }





  // GET ALL RECIPES
  internal List<Recipe> GetRecipes()
  {
    string sql = @"
    SELECT
    rec.*,
    acc.* 
    FROM recipes rec
    JOIN accounts acc ON acc.id = rec.creatorId
    ;";

    List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(
      sql,
      (recipe, profile) =>
      {
        recipe.Creator = profile;
        return recipe;
      }
      ).ToList();
    return recipes;
  }








  // UPDATE RECIPES
  internal Recipe UpdateRecipe(Recipe originalRecipe)
  {
    string sql = @"
    UPDATE recipes 
    SET
    title = @Title,
    instructions = @Instructions,
    img = @Img,
    category = @Category
    WHERE id = @Id
    LIMIT 1;
    SELECT * FROM recipes WHERE id = @Id
    ;";
    Recipe updatedRecipe = _db.QueryFirstOrDefault<Recipe>(sql, originalRecipe);

    return updatedRecipe;
  }








  // REMOVE RECIPES
  internal void RemoveRecipe(int recipeId)
  {
    string sql = "DELETE FROM recipes WHERE id = @recipeId LIMIT 1;";
    _db.Execute(sql, new { recipeId });
  }
}
