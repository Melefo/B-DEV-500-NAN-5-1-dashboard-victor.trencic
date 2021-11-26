import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Home from '@/views/Home.vue'
import Login from '@/views/Login.vue'
import Dashboard from '@/views/Dashboard.vue'
import Admin from '@/views/Admin.vue'
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
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

router.beforeEach((to, from, next) => {
  if (to.meta && to.meta.onlyUser && !store.getters["user/isLoggedIn"])
    return next('/login');
  if (to.meta && to.meta.onlyGuest && store.getters["user/isLoggedIn"])
    return next('/');

  next();
})

export default router
