import Vue from 'vue'
import App from './App.vue'
import router from './router'
import { store } from './state/index'
import vuescrool from 'vuescroll'

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

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
