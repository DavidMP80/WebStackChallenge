var express = require('express');

var app = express();

var port = process.env.PORT || 3000;

app.get('/', function(req, res){
	res.Send('Welcome to my API!');
});

app.Listen(port, function(){
	console.log('Running on Port: ' + port);
})
