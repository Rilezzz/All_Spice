import { AppState } from "../AppState.js"
import { Ingredient } from "../models/Ingredient.js"
import { Recipe } from "../models/Recipe.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class RecipesService {
  async getRecipes() {
    const res = await api.get('api/recipes')
    logger.log('[Got Recipes]', res.data)
    const recipes = res.data.map(recipe => new Recipe(recipe))
    AppState.recipes = recipes
  }


  async getRecipeById(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}`)
    logger.log('[Got Recipe]', res.data)
    const selectedRecipe = new Recipe(res.data)
    AppState.selectedRecipe = selectedRecipe
  }


  async getIngredientsByRecipeId(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}/ingredients`)
    logger.log('[Got Ingredients]', res.data)
    const ingredients = res.data.map(i => new Ingredient(i))
    AppState.ingredients = ingredients
  }


} export const recipesService = new RecipesService()