import { authHeader } from "@/state/index";

export const steam = {
    namespaced: true,
    actions: {
        async getById({ commit }, id) {
            const res = await fetch("/api/services/steam/game_info?" + new URLSearchParams({ id: id }), {
                method: "GET",
                headers: authHeader()
            });
            const json = await res.json();
            if (!res.ok)
                return { success: false, json: json.error }
            return { success: true, json }
        },
        async update({ commit }, json) {
            const res = await fetch("/api/services/steam/game_info", {
                method: "PATCH",
                headers: Object.assign(authHeader(), {"Content-Type": "application/json"}),
                body: JSON.stringify(json)
            });
            let errors = null;
            if (!res.ok)
            {
                const { error } = await res.json();
                errors = error;
            }
            return { error: errors };
        },
    },
}
