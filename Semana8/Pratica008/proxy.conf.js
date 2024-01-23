const PROXY_CONFIG = [
    {
        context: [
            '/api.php',
        ],
        target: "https://en.wikipedia.org/w/",
        secure: "false",
        changeOrigin: true,
        pathRewrite: {
            "^/": ""
        }
    }
];

module.exports = PROXY_CONFIG;
