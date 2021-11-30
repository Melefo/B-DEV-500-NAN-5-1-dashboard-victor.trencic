import { authHeader } from "@/state/index";

export const weather = {
    namespaced: true,
    actions: {
        async get({ commit }) {
            const res = await fetch("/api/services/weather", {
                method: "GET",
                headers: authHeader()
            });
            return await await res.json();
        },
    },
}
