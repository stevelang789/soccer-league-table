angular
    .module('soccerLeagueTable')
    .factory('uxService', ['$window', function ($window) {
        var handleError = function (data) {
            $window.alert(data.Message);
        };

        return {
            handleError: handleError
        }
    }]);