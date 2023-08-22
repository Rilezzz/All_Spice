import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},

  /** @type {import('./models/Recipe.js').Recipes[]} */
  recipes: [],

  /** @type {import('./models/Recipe.js').Recipes[]} */
  selectedRecipe: null,

  /** @type {import('./models/Ingredient.js').Ingredients[]} */
  ingredients: []
})
