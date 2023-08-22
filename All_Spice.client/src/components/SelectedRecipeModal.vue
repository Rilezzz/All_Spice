<template>
  <div class="modal fade" tabindex="-1" aria-labelledby="selectedRecipeModal" aria-hidden="true">
    <div class="modal-dialog modal-xl modal-dialog-centered">
      <div v-if="recipe" class="modal-content back">
        <div class="modal-header header-font header-background">
          <h1 class="modal-title fs-2" id="selectedRecipeModal">
            {{ recipe.title }}
          </h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body body-font">

          <div class="row justify-content-around">
            <div class="col-11 col-md-5 img rounded p-0">
            </div>
            <div class="col-6 col-md-3 glass">
              <h4>Instructions: </h4>
              <li>{{ recipe.instructions }}</li>
            </div>
            <div v-for="i in ingredients" :key="i.id" class="col-6 col-md-3 glass">
              <li>{{ i.quantity }}, {{ i.name }}</li>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';

export default {
  setup() {
    return {
      recipe: computed(() => AppState.selectedRecipe),
      ingredients: computed(() => AppState.ingredients),
      recipeImg: computed(() => `url(${AppState.selectedRecipe?.img})`)

    }
  },
}
</script>


<style lang="scss" scoped>
.header-font {
  font-family: 'Times New Roman', Times, serif;
  color: rgb(255, 255, 255);
}

.body-font {
  font-family: 'Times New Roman', Times, serif;
  color: rgb(231, 228, 226);
}

.header-background {
  background-image: linear-gradient(rgb(35, 105, 26), rgb(52, 73, 60));
  box-shadow:
    inset 0 0 20px 7px #28382e,
    inset 0 2px 10px 2px #0b3118,
    2px 0 3px 1px #181515,
    0 1px 15px 3px #151e15;


}

.back {
  background-color: #d6d1afe4;
  backdrop-filter: blur(4.3px);


}

.img {
  height: 40vh;
  width: 35vh;
  background-image: v-bind(recipeImg);
  background-size: cover;
  background-position: center;

}

.glass {
  background: rgba(9, 9, 9, 0.826);
  border-radius: 16px;
  box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
  backdrop-filter: blur(4.3px);
  -webkit-backdrop-filter: blur(4.3px);
  border: 1px solid rgba(39, 37, 37, 0.21);
}
</style>