import { authHeader } from "@/router";

export const user = {
    namespaced: true,
    state: {
        token: null,
        all: null,
        one: null
    },
    mutations: {
        login(state, token) {
            state.token = token;
        },
        all(state, users) {
            state.all = users;
        },
        one(state, user) {
            state.one = user;
        }
    },
    actions: {
        login({ commit }, json) {
            fetch("/api/user/login", {
                method: "POST",
                headers: {
                  "Content-Type": "application/json"
                },
                body: JSON.stringify(json)
              }).then(async res => {
                const { token } = await res.json();
                commit('login', token);
              })
        },
        register({ commit }, json) {
            fetch("/api/user/register", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                  },
                  body: JSON.stringify(json)
            })
        },
        delete({ commit }, id) {
            fetch("/api/user/delete" + new URLSearchParams({ id: id }), {
                method: "DELETE",
            })
        },
        all({ commit }) {
            fetch("/api/user", {
                method: "GET",
                headers: authHeader()
            }).then(async res => {
                const list = await res.json();
                commit('all', list);
            })
        },
        one({ commit }, user) {
            fetch("/api/user/" + user, {
                method: "GET",
                headers: authHeader()
            }).then(async res => {
                const user = await res.json();
                commit('one', user);
            })
        }
    },
    getters: {
        isLoggedIn(state) : Boolean {
            return !!state.token;
        },
        token(state) {
            return state.token;
        }
    }
}
