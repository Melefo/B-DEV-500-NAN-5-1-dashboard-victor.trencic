import Vue from 'vue'
import App from './App.vue'
import router from './router'
import { store } from './state/index'
import GAuth from 'vue-google-oauth2'
import vuescrool from 'vuescroll'
import DefaultLayout from './layouts/DefaultLayout.vue'
import DashboardLayout from './layouts/DashboardLayout.vue'

Vue.use(GAuth, {
    clientId: process.env.Google__ClientId
})

Vue.config.productionTip = false

Vue.use(vuescrool, {
  ops: {
    bar: {
      background: 'linear-gradient(#6700FF4C, #1DE5E24C)'
    },
    scrollPanel: {
      scrollingX: false,
      scrollingY: true,
    },
  },
  name: 'scroll'
})

Vue.component('default-layout', DefaultLayout)
Vue.component('dashboard-layout', DashboardLayout)

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
