(function () {

    angular.module("CarDealershipApplication", ['ngResource', 'ui.bootstrap','ngRoute', 'angularUtils.directives.dirPagination']).config(function ($routeProvider, $locationProvider) {
        $routeProvider
        .when('/', {
            templateUrl: '/ngViews/customerView.html',
            controller: 'CustomerViewController',
            controllerAs: 'main'
        })
        .when('/dealerView', {
            templateUrl: '/ngViews/dealerView.html',
            controller: 'DealerViewController',
            controllerAs: 'main'
        })
        .otherwise({
            templateUrl: '/ngViews/notFound.html'
        });
        $locationProvider.html5Mode(true);
    })



})();