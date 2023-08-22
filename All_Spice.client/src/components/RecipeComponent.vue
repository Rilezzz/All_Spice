<template>
  <div class="d-flex flex-column justify-content-around rounded font elevation-5 p-2 rec-card  "
    :title="recipeProp.title">
    <div>
      <div class="d-flex justify-content-between fs-4">
        <p class="d-flex justify-content-start mb-2 glass">{{ recipeProp.category }} </p>
        <i @click="favoriteRecipe()" class="d-flex selectable justify-content-end mb-2 glass mdi  mdi-star-outline"></i>
      </div>
    </div>
    <div class="d-flex justify-content-center ">
      <div data-bs-toggle="modal" data-bs-target="#selectedRecipeModal"
        class="d-flex justify-content-center elevation-5 glass px-2 selectable rounded text-center"
        @click="getRecipeById(recipeProp.id), getIngredientsByRecipeId(recipeProp.id)">
        <h3>{{ recipeProp.title }}</h3>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from 'vue';
import { Recipe } from '../models/Recipe.js';
import { recipesService } from '../services/RecipesService.js';
import Pop from '../utils/Pop.js';

export default {
  props: {
    recipeProp: { type: Recipe, required: true }
  },

  setup(props) {

    async function getRecipeById(recipeId) {
      try {
        await recipesService.getRecipeById(recipeId)
      } catch (error) {
        Pop.error(error.message)
      }
      this.getIngredientsByRecipeId(recipeId)
    }


    async function getIngredientsByRecipeId(recipeId) {


      try {
        await recipesService.getIngredientsByRecipeId(recipeId)
      } catch (error) {
        Pop.error(error.message)
      }
    }



    return {
      recipeImg: computed(() => `url(${props.recipeProp?.img})`),

      getRecipeById,
      getIngredientsByRecipeId

    }
  }
}
</script>


<style lang="scss" scoped>
.rec-card {
  background-image: v-bind(recipeImg);
  background-size: cover;
  background-position: center;
  height: 30vh;
  width: 45vh;
}

.glass {
  background: rgba(9, 9, 9, 0.826);
  border-radius: 16px;
  box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
  backdrop-filter: blur(4.3px);
  -webkit-backdrop-filter: blur(4.3px);
  border: 1px solid rgba(39, 37, 37, 0.21);
}

.font {
  font-family: 'Times New Roman', Times, serif;
  color: rgb(185, 136, 72);
}
</style>