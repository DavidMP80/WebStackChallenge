var express = require('express'),
    ping = require('ping');

//var requestModel = require('./models/request/requestTimeModel');

var route = function () {
    var performanceRouter = express.Router();
    
    function doPing(host, callback) {

        var time = 14;
        ping.promise.probe(host)
            .then(function (res) {

                console.log(res.host + ': ' + res.time)
                callback(res.time);
                //time = res.time;
            })
        
        return time;
    }

    performanceRouter.route('/')
        .post(function (req, res) {

            var host = req.body.url;
            var reps = req.body.repetition;

            var response = {
                url: host,
                repetitions: reps,
                times: []
            };
            
            for (var i = 0; i < reps; i++)
            {
                var time = doPing(host, function (time) {

                    response.times.push(time);                    
                    console.log(JSON.stringify(response));                   
                });

                response.times.push(time);
            }

            console.log('-------------final: ' + JSON.stringify(response));
            res.send(response);
            
        });

    return performanceRouter;
};

module.exports = route;