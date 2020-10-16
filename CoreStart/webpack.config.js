const webpack = require('webpack');
const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');

const config = {
    entry: './client/js/index.js',
    output: {
        path: path.resolve(__dirname, 'wwwroot/js/'),
        filename: 'bundle.js'
    },
    plugins: [new MiniCssExtractPlugin({
            filename: '../css/mainly.css'
    })
    ],
    module: {
        rules: [
            {
                test: /\.s[ac]ss$/i,
                use: [
                    {
                        loader: MiniCssExtractPlugin.loader
                    },
                    'css-loader',
                    'sass-loader'
                ]
            }
        ]
    }
};

module.exports = config;