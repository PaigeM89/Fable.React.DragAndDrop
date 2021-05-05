const path = require('path');

module.exports = {
  //entry: './src/index.js',
  mode: "development",
  entry: './Fable.Dragula.fsproj',
  // output: {
  //   filename: 'main.js',
  //   path: path.resolve(__dirname, 'dist'),
  // },
  output: {
    path: path.join(__dirname, "./public"),
    filename: "script.js",
  },
  devServer: {
      publicPath: "/",
      contentBase: "./public",
      port: 8080,
  },
  module: {
      rules: [{
          test: /\.fs(x|proj)?$/,
          use: "fable-loader"
      }]
  }
};