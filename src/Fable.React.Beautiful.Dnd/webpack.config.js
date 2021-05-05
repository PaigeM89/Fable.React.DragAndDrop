const path = require('path');
const ReactRefreshWebpackPlugin = require('@pmmmwh/react-refresh-webpack-plugin');
var HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
  //entry: './src/index.js',
  mode: "development",
  entry: './TestComponent.fs.js',
  // output: {
  //   filename: 'main.js',
  //   path: path.resolve(__dirname, 'dist'),
  // },
  output: {
    path: path.join(__dirname, "./"),
    filename: "output-script.js",
  },
  devServer: {
      publicPath: "/",
      contentBase: "./",
      port: 8090,
  },
  module: {
      rules: [{
          test: /\.fs(x|proj)?$/,
          use: "fable-loader"
      }]
  },
  plugins: [
    new HtmlWebpackPlugin({
      filename: 'index.html',
      template: resolve("./index.html"),
      hash: true
    })
  ]
};


function resolve(filePath) {
  return path.isAbsolute(filePath) ? filePath : path.join(__dirname, filePath);
}
