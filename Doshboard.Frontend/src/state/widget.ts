import { authHeader } from "@/state/index";

export const widget = {
    namespaced: true,
    state: {

    },
    mutations: {

    },
    actions: {
        async get({ commit }) {
            const res = await fetch("/api/widget", {
                method: "GET",
                headers: authHeader()
            });
            return await res.json();
        }
    },
    getters: {

    }
}