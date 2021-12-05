export const about = {
    namespaced: true,
    state: {
    },
    mutations: {
    },
    actions: {
        async get({ commit }) {
            const res = await fetch("/api/about.json", {
                method: "GET"
            });
            if (res.status == 500)
                return { success: false, error: "Backend unavailable" };
            const { server } = await res.json();
            return { success: true, data: server.services };
        }
    }
}