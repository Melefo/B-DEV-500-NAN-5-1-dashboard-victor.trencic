import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Home from '@/views/Home.vue'
import Login from '@/views/Login.vue'
import Dashboard from '@/views/Dashboard.vue'
import Admin from '@/views/Admin.vue'
import Widgets from '@/views/Widgets.vue'
import { store } from '@/state/index'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'Home',
    component: Home,
  },
  {
    path: '/dashboard',
    name: 'Dashboard',
    component: Dashboard,
    meta: { onlyUser: true }
  },
  {
    path: '/admin',
    name: 'Admin',
    component: Admin,
    meta: { onlyUser: true }
  },
  {
    path: '/login',
    name: 'Login',
    component: Login,
    meta: { onlyGuest: true }
  },
  {
    path: '/widgets',
    name: 'Widgets',
    component: Widgets,
    meta: { onlyUser: true }
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

function parseJwt (token) {
  const base64Url = token.split('.')[1];
  const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
  const jsonPayload = decodeURIComponent(atob(base64).split("").map(function(c) {
      return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
  }).join(''));

  return JSON.parse(jsonPayload);
}

router.beforeEach((to, from, next) => {
  if (store.getters["user/isLoggedIn"]) {
    const jwtPayload = parseJwt(store.getters["user/token"]);
    if (jwtPayload.exp < Date.now() / 1000) {
        store.dispatch("user/logout");
    }
  }

  if (to.meta && to.meta.onlyUser && !store.getters["user/isLoggedIn"])
    return next('/login');
  if (to.meta && to.meta.onlyGuest && store.getters["user/isLoggedIn"])
    return next('/');

  next();
})

export default router
