import Vue from "vue";
import Router from "vue-router";
import Home from "./views/home.vue";
import Login from "./views/login.vue";
import Register from "@/views/register.vue";
import Crud from "@/views/crud.vue";

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
    }
  ]
});

router.beforeEach((to, from, next) => {
  // redirect to login page if not logged in and trying to access a restricted page
  const publicPages = ["/login", "/register"];
  const authRequired = !publicPages.includes(to.path);
  const loggedIn = localStorage.getItem("user");

  if (authRequired && !loggedIn) {
    return next({ name: "login" });
  }

  next();
});

export default router;
