var express = require("express"),
    bodyParser = require("body-parser"),
    ping = require('ping');

var app = express();

var port = process.env.port || 3000;

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

app.get('/', function (req, res) {
    res.send('ei què passa');
});

app.post('/', function (req, res) {
    res.send(req.body);
})

var performanceRouter = require('./routes/performanceRouter')();

app.use('/api/performance', performanceRouter);

var pingTest = express.Router();
pingTest.route('/pingTest')
    .get(function (req, res) {

        var hosts = ['192.168.1.1', 'google.com', 'yahoo.com'];
        hosts.forEach(function (host) {
            ping.sys.probe(host, function (isAlive) {
                var msg = isAlive ? 'host ' + host + ' is alive' : 'host ' + host + ' is dead';
                console.log(msg);
            });
        });

    });

app.use(pingTest);

app.listen(port, function () {
    console.log('Service is running');
})
