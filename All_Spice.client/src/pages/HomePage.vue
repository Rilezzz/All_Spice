<template>
  <div class=" d-flex flex-column align-items-center justify-content-start m-2">
    <div class="col-12 col-md-11 d-flex align-items-center p-1 bg-black home-card rounded elevation-3 mt-3">
      <div class="p-4 font">
        <h1>ALL SPICE <img src="https://clipground.com/images/chili-cook-off-clipart-19.png" alt="" height="45"></h1>
      </div>
      <div class="col-5 col-md-3 elevation-3 fs-5 search text-light text-center p-1 ">
        <input v-model="filterBy" class="rounded m-2 w-75" placeholder="Search Recipes" type="search" id="" name="q" />
      </div>
    </div>
  </div>
  <div class="row justify-content-center m-4">
    <div class="col-11 col-md-3 my-4 mx-3" v-for="recipe in recipes " :key="recipe.id">
      <RecipeComponent :recipeProp="recipe" />
    </div>
  </div>
</template>

<script>
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js'
import { computed, onMounted, ref } from 'vue';
import { AppState } from '../AppState.js';
import RecipeComponent from '../components/RecipeComponent.vue';
export default {
  setup() {
    const filterBy = ref('');
    async function getRecipes() {
      try {
        await recipesService.getRecipes();
      }
      catch (error) {
        Pop.error(error.message);
      }
    }
    onMounted(() => {
      getRecipes();
    });
    return {
      account: computed(() => AppState.account),
      filterBy,
      recipes: computed(() => {
        if (filterBy.value == "") {
          return AppState.recipes;
        }
        else {
          return AppState.recipes.filter(recipe => recipe.title.toLowerCase().includes(filterBy.value.toLowerCase()));
        }
      })
    };
  },
  components: { RecipeComponent }
}
</script>

<style scoped lang="scss">
.home-card {
  height: 25dvh;
  background-image: url(https://www.freeiconspng.com/uploads/spices-for-recipe-png-13.png);
  background-position: right;
  background-repeat: no-repeat;
  background-size: contain;
  box-shadow: 5px 5px 5px rgba(106, 177, 138, 0.628);
  border: 3px double rgb(61, 95, 67);

  .font {
    font-family: fantasy;
    color: rgb(137, 97, 45);
  }

  .card-shadow {
    box-shadow: 5px 5px 5px rgba(106, 177, 138, 0.628);
    border: 3px double rgb(61, 95, 67);

  }
}
</style>
