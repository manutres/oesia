import Vue from "vue";
import Router from "vue-router";
import Home from "./views/home.vue";
import Login from "./views/login.vue";
import Register from "@/views/register.vue";
import Crud from "@/views/crud.vue";
import CarScreen from "@/views/carsScreen.vue";
import LocationsScreen from "@/views/locationsScreen.vue";
import RoutesScreen from "@/views/routesScreen.vue";
import RoutesAvaibles from "@/views/routesAvaibles.vue";

Vue.use(Router);

const router = new Router({
  routes: [
    {
      path: "/",
      name: "home",
      component: Home
    },
    {
      path: "/login",
      name: "login",
      component: Login
    },
    {
      path: "/register",
      name: "register",
      component: Register
    },
    {
      path: "/crud",
      name: "crud",
      component: Crud
    },
    {
      path: "/cars",
      name: "cars",
      component: CarScreen
    },
    {
      path: "/locations",
      name: "locations",
      component: LocationsScreen
    },
    {
      path: "/routes",
      name: "routes",
      component: RoutesScreen
    },
    {
      path: "/ravaibles",
      name: "ravaibles",
      component: RoutesAvaibles
    }
  ]
});

router.beforeEach((to, from, next) => {
  // redirect to login page if not logged in and trying to access a restricted page
  const publicPages = ["/login", "/register"];
  const authRequired = !publicPages.includes(to.path);
  const loggedIn = localStorage.getItem("user_token");

  if (authRequired && !loggedIn) {
    return next({ name: "login" });
  }

  next();
});

export default router;
