import { authHeader } from "@/state/index";

export const weather = {
    namespaced: true,
    actions: {
        async getById({ commit }, id) {
            const res = await fetch("/api/services/weather/city_temperature?" + new URLSearchParams({ id: id }), {
                method: "GET",
                headers: authHeader()
            });
            return await await res.json();
        },
    },
}
