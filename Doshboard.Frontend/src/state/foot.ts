import { authHeader } from "@/state/index";

export const foot = {
    namespaced: true,
    actions: {
        async getAllCompetitions({ commit }) {
            const res = await fetch("/api/services/foot/competition", {
                method: "GET",
                headers: authHeader()
            });
            return await res.json();
        },
        async getMatchByCompetitions({ commit }, id) {
            const res = await fetch("/api/services/foot/match" + new URLSearchParams({ id: id }), { //user id here : same as a getById
                method: "GET",
                headers: authHeader()
            });
            return await res.json();
        },
        async update({ commit }, json) {
            const res = await fetch("/api/services/foot/update", {
                method: "PATCH",
                headers: Object.assign(authHeader(), {"Content-Type": "application/json"}),
                body: JSON.stringify(json)
            });
        },
    },
}
