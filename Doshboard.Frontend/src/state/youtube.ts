import { authHeader } from "@/state/index";

export const youtube = {
    namespaced: true,
    actions: {
        async getById({ commit }, id) {
            const res = await fetch("/api/services/youtube/video?" + new URLSearchParams({ id: id }), {
                method: "GET",
                headers: authHeader()
            });
            return await res.json();
        },
        async getUserVideos({ commit }) {
            const res = await fetch("/api/services/youtube/uservideos", {
                method: "GET",
                headers: authHeader()
            });
            return await res.json();
        },
        async update({ commit }, { id, videoId }) {
            const res = await fetch("/api/services/youtube/video?" + new URLSearchParams({ id: id, videoId: videoId }), {
                method: "PATCH",
                headers: authHeader(),
            });
        },
    },
}
