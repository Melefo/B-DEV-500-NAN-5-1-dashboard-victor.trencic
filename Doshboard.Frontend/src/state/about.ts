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
            const { server } = await res.json();
            return server.services;
        }
    }
}