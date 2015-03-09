angular
    .module('soccerLeagueTable')
    .controller('standingsAndFixturesController', ['$scope', 'standingsAndFixturesService', function ($scope, standingsAndFixturesService) {
        $scope.standings = {};
        $scope.fixtures = {};
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
        $scope.fixturesOptions = {
            data: 'fixtures',
            enableCellSelection: true,
            enableRowSelection: false,
            enableCellEditOnFocus: true,
            columnDefs: [
                { field: 'Date', displayName: 'Date', cellFilter: 'date', width: 135, enableCellEdit: false },
                { field: 'HomeTeam.Name', displayName: 'Home', width: 150, enableCellEdit: false },
                { field: 'AwayTeam.Name', displayName: 'Away', width: 150, enableCellEdit: false },
                { field: 'IsCompleted', displayName: 'Played' },
                { field: 'HomeTeamScore', displayName: 'H. Score' },
                { field: 'AwayTeamScore', displayName: 'A. Score' }
            ]
        };
        standingsAndFixturesService.getStandingsAndFixtures()
            .then(function (data) {
                if (data != null) {
                    $scope.standings = data.Standings;
                    $scope.fixtures = data.Fixtures;
                }
            });

        $scope.save = function () {
            console.log($scope.fixtures);
            standingsAndFixturesService.updateFixtures($scope.fixtures)
                .then(function (data) {
                    if (data != null) {
                        $scope.standings = data;
                    }
                });
        };
    }]);