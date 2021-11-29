import VuexPersistence from 'vuex-persist'
import Vuex from 'vuex'
import Vue from 'vue'
import { user } from '@/state/user'
import { weather } from '@/state/weather'

Vue.use(Vuex)

const persistence = new VuexPersistence({
    storage: localStorage
})

export const store = new Vuex.Store({
    plugins: [persistence.plugin],
    modules: {
        user,
        weather
    }
})

export function authHeader() : HeadersInit {
    if (store.getters["user/isLoggedIn"])
      return { 'Authorization': 'Bearer ' + store.getters["user/token"] };
    return {};
  }
  