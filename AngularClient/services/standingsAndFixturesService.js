﻿angular
    .module('soccerLeagueTable')
    .factory('standingsAndFixturesService', ['$http', '$q', 'uxService', 'serviceUrl', function ($http, $q, uxService, serviceUrl) {
        var getStandingsAndFixtures = function () {
            var q = $q.defer();

            $http.get(serviceUrl + '/api/StandingsAndFixtures')
                .then(function (response) {
                    q.resolve(response.data);
                })
                .catch(function (response) {
                    uxService.handleError(response.data);
                    q.reject();
                });

            return q.promise;
        };

        return {
            getStandingsAndFixtures: getStandingsAndFixtures
        }
    }]);