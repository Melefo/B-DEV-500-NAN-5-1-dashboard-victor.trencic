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
        },
        async new({ commit }, type) {
            const res = await fetch("/api/widget?" + new URLSearchParams({ type: type }), {
                method: "POST",
                headers: authHeader()
            });
        },
        async delete({ commit }, id) {
            const res = await fetch("/api/widget?" + new URLSearchParams({ id: id }), {
                method: "DELETE",
                headers: authHeader()
            });
        },
        async update({ commit }, { id, x, y}) {
            const res = await fetch("/api/widget/update?" + new URLSearchParams({ id: id, x: x, y: y}),{
                method: "PATCH",
                headers: authHeader(),
            });
        }
    },
    getters: {

    }
}