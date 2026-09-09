var express = require('express');
var path = require('path');
var app = express();
app.listen(6080); // http://127.0.0.1:6080/
app.use("/", express.static(path.join(process.cwd(), "www_root")));   // http://127.0.0.1:6080/version.txt

app.get("/uploadData", function (req, res) { // http://127.0.0.1:6080/uploadData
    console.log(req.query);
    res.send("WebRequest!");  //返回字符串给unity
}
);