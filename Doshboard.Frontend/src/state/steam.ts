import { authHeader } from "@/state/index";

export const steam = {
    namespaced: true,
    actions: {
        async getById({ commit }, id) {
            const res = await fetch("/api/services/steam/game_info?" + new URLSearchParams({ id: id }), {
                method: "GET",
                headers: authHeader()
            });
            return await res.json();
        },
        async update({ commit }, {id, name}) {
            const res = await fetch("/api/services/steam/game_info?" + new URLSearchParams({ id: id, name: name }), {
                method: "PATCH",
                headers: authHeader(),
            });
        },
    },
}
