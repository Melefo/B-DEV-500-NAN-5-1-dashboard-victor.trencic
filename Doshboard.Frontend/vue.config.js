module.exports = {
    devServer: {
        proxy: {
            '^/api': {
                target: process.env.BACKEND_URL || "http://localhost:8080/",
                ws: true,
                pathRewrite: {
                    '^/api': ''
                }
            }
        },
        public: process.env.PUBLIC_URL,
        port: 80
    }
}