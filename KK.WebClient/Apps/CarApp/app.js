// Main configuration file. Sets up AngularJS module and routes and any other config objects

var appRoot = angular.module('main', ['ngRoute', 'ngGrid', 'ngResource']);     //Define the main module

appRoot
    .config(['$routeProvider', '$httpProvider', '$locationProvider', function ($routeProvider, $httpProvider, $locationProvider) {
        
        //set interceptors
        $httpProvider.interceptors.push('serverErrorInterceptor');
        //this will set the routing using / instead of # by default
        $locationProvider.html5Mode(true);

        //Setup routes to load partial templates from server. TemplateUrl is the location for the server view (Razor .cshtml view)
        $routeProvider
            .when('/', { templateUrl: '/apps/carApp/views/main.html', controller: 'MainController' })
            .when('/car/ads', { templateUrl: '/apps/carApp/views/carAds.html', controller: 'CarAdsController' })
            .when('/car/detail/:id', { templateUrl: '/apps/carApp/views/carAdsDetail.html', controller: 'CarAdsDetailController' })
            .when('/car/enquiries', { templateUrl: '/apps/carApp/views/enquiries.html', controller: 'EnquiriesController' })
            .when('/car/enquiryConfirmation', { templateUrl: '/apps/carApp/views/enquiryConfirmation.html', controller: 'EnquiryConfirmationController' })
            .when('/car/apiError', { templateUrl: '/apps/carApp/views/apiError.html', controller: 'ApiErrorController' })
            .otherwise({ redirectTo: '/' });
        
    }])
    //this is the root controller
    .controller('RootController', ['$scope', '$route', '$routeParams', '$location', function ($scope, $route, $routeParams, $location) {
        $scope.$on('$routeChangeSuccess', function (e, current, previous) {
            //this activeViewPath to detect the locations which use in _layout
            $scope.activeViewPath = $location.path();            
        });
    }]);
