import { authHeader } from "@/state/index";
import { parseJwt } from "@/router/index"

export const user = {
    namespaced: true,
    state: {
        token: null,
    },
    mutations: {
        login(state, token) {
            state.token = token;
        }
    },
    actions: {
        async login({ commit }, json) {
            const res = await fetch("/api/user/login", {
                method: "POST",
                headers: {
                  "Content-Type": "application/json"
                },
                body: JSON.stringify(json)
              });
            const { token } = await res.json();
            commit('login', token);
        },
        async googleLogin({ commit }, code) {
            const res = await fetch("/api/user/login/google?" + new URLSearchParams({code: code}), {
                method: "POST"
              });
            const { token } = await res.json();
            commit('login', token);
        },
        async logout({ commit }) {
            commit('login', null);
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
        del({ commit }, id) {
            fetch("/api/user/delete?" + new URLSearchParams({ id: id }), {
                method: "DELETE",
                headers: authHeader()
            })
        },
        promote({ commit }, id) {
            fetch("/api/user/promote?" + new URLSearchParams({ id: id }), {
                method: "PATCH",
                headers: authHeader()
            })
        },
        async all({ commit }) {
            const res = await fetch("/api/user", {
                method: "GET",
                headers: authHeader()
            });
            return await res.json();
        }
    },
    getters: {
        isLoggedIn(state) : Boolean {
            return !!state.token;
        },
        isAdmin(state) : Boolean {
            return (!!state.token && parseJwt(state.token).role == "Admin")
        },
        token(state) {
            return state.token;
        }
    }
}
