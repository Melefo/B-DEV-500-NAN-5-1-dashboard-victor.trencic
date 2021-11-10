module.exports = {
    devServer: {
        proxy: {
            '^/weatherforecast': {
                target: process.env.BACKEND_URL
            }
        },
        public: process.env.PUBLIC_URL,
        port: 80
    }
}