import VuexPersistence from 'vuex-persist'
import Vuex from 'vuex'
import Vue from 'vue'
import { user } from '@/state/user'
import { widget } from '@/state/widget'
import { about } from '@/state/about'
import { weather } from '@/state/weather'
import { crypto } from '@/state/crypto'
import { steam } from '@/state/steam'
import { youtube } from '@/state/youtube'
import { rss } from '@/state/rss'

Vue.use(Vuex)

const persistence = new VuexPersistence({
    storage: localStorage
})

export const store = new Vuex.Store({
    plugins: [persistence.plugin],
    modules: {
        user,
        widget,
        about,
        weather,
        crypto,
        steam,
        youtube,
        rss
    }
})

export function authHeader() : HeadersInit {
    if (store.getters["user/isLoggedIn"])
      return { 'Authorization': 'Bearer ' + store.getters["user/token"] };
    return {};
}
  