import { authHeader } from "@/state/index";

export const rss = {
    namespaced: true,
    actions: {
        async getById({ commit }, id) {
            const res = await fetch("/api/services/rss/rss_feed?" + new URLSearchParams({ id: id }), {
                method: "GET",
                headers: authHeader()
            });
            return await res.json();
        },
        async update({ commit }, json) {
            const res = await fetch("/api/services/rss/rss_feed", {
                method: "PATCH",
                headers: Object.assign(authHeader(), {"Content-Type": "application/json"}),
                body: JSON.stringify(json)
            });
        },
    },
}
