import Vue from 'vue'
import App from './App.vue'
import router from './router'
import { store } from './state/index'
import GAuth from 'vue-google-oauth2'

Vue.use(GAuth, {
    clientId: process.env.Goole__ClientId || '280847036120-6finfco2oc5tuqu4ikq4erscmlt65i9j.apps.googleusercontent.com'
})


Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
