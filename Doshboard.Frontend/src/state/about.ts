export const about = {
    namespaced: true,
    state: {
        content: null
    },
    mutations: {
        set(state, value) {
            state.content = value;
        }
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