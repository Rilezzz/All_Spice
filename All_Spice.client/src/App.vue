<template>
  <header class="text">
    <Navbar />
  </header>
  <main class="text background">
    <router-view />
  </main>
  <SelectedRecipeModal id="selectedRecipeModal">
  </SelectedRecipeModal>

  <footer class=" text-light text">
    🌶️ Made by: Riley Thomas
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import SelectedRecipeModal from './components/SelectedRecipeModal.vue'


export default {


  setup() {
    return {
      appState: computed(() => AppState),
    }
  },
  components: { Navbar, SelectedRecipeModal }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

.background {
  background-color: #fbfcfa;
}

:root {
  --main-height: calc(100vh - 32px - 64px);
}

.text {
  font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
  background-image: linear-gradient(rgb(35, 105, 26), rgb(52, 73, 60));
  box-shadow:
    inset 0 0 20px 7px #28382e,
    inset 0 2px 10px 2px #0b3118,
    2px 0 10px 2px #181515,
    0 3px 100px 5px #151e15;
}
</style>
