import { authHeader } from "@/state/index";

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
        token(state) {
            return state.token;
        }
    }
}
