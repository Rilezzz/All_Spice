<template>
  <nav class="navbar navbar-expand-lg  px-3">
    <div class="collapse navbar-collapse" id="navbarText">
      <Login />
      <ul class="navbar-nav me-auto">
        <li>
          <!-- <router-link :to="{ name: 'About' }" class="btn text-success lighten-30 selectable text-uppercase">
            About
          </router-link> -->
        </li>
      </ul>
    </div>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }" title="All Spice Home">
      <div class="d-flex flex-column align-items-center">
        <img alt="logo" src="https://clipground.com/images/chili-cook-off-clipart-19.png" height="45" />
      </div>
    </router-link>
  </nav>
</template>

<script>
import Login from './Login.vue';
export default {
  setup() {
    return {}
  },
  components: { Login }
}
</script>

<style scoped>
.navbar {
  background-image: linear-gradient(rgb(35, 105, 26), rgb(52, 73, 60));
  box-shadow:
    inset 0 0 20px 7px #28382e,
    inset 0 2px 10px 2px #0b3118,
    2px 0 3px 1px #181515,
    0 1px 15px 3px #151e15;
}

nav {
  background-color: #527360;
}

a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
