angular
    .module('soccerLeagueTable')
    .controller('standingsAndFixturesController', ['$scope', 'standingsAndFixturesService', function ($scope, standingsAndFixturesService) {
        $scope.standings = {};
        $scope.standingsOptions = {
            data: 'standings',
            columnDefs: [
                { field: 'TeamName', displayName: 'Team', width: 200 },
                { field: 'Played', displayName: 'P' },
                { field: 'Won', displayName: 'W' },
                { field: 'Drew', displayName: 'D' },
                { field: 'Lost', displayName: 'L' },
                { field: 'GoalsFor', displayName: 'GF' },
                { field: 'GoalsAgainst', displayName: 'GA' },
                { field: 'GoalDifference', displayName: 'GD' },
                { field: 'Points', displayName: 'Pts' }
            ]
        };
        standingsAndFixturesService.getStandingsAndFixtures()
            .then(function (data) {
                if (data != null) {
                    $scope.standings = data.Standings;
                }
            });
    }]);