import VuexPersistence from 'vuex-persist'
import Vuex from 'vuex'
import Vue from 'vue'
import { user } from '@/state/user'

Vue.use(Vuex)

const persistence = new VuexPersistence({
    storage: localStorage
})

export const store = new Vuex.Store({
    plugins: [persistence.plugin],
    modules: {
        user
    }
})