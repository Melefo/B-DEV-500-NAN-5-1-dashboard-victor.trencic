import { authHeader } from "@/state/index";

export const crypto = {
    namespaced: true,
    actions: {
        async getById({ commit }, id) {
            const res = await fetch("/api/services/crypto/realtime_crypto?" + new URLSearchParams({ id: id }), {
                method: "GET",
                headers: authHeader()
            });
            return await res.json();
        },
        async update({ commit }, json) {
            const res = await fetch("/api/services/crypto/realtime_crypto", {
                method: "PATCH",
                headers: Object.assign(authHeader(), {"Content-Type": "application/json"}),
                body: JSON.stringify(json)
            });
        },
    },
}
