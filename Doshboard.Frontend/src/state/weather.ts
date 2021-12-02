import { authHeader } from "@/state/index";

export const weather = {
    namespaced: true,
    actions: {
        async getById({ commit }, id) {
            const res = await fetch("/api/services/weather/city_temperature?" + new URLSearchParams({ id: id }), {
                method: "GET",
                headers: authHeader()
            });
            return await res.json();
        },
        async update({ commit }, json) {
            const res = await fetch("/api/services/weather/city_temperature", {
                method: "PATCH",
                headers: Object.assign(authHeader(), {"Content-Type": "application/json"}),
                body: JSON.stringify(json)
            });
        },
    },
}
