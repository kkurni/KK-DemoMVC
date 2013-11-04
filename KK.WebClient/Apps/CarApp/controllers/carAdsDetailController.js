
appRoot.controller('CarAdsDetailController', ['$scope', '$filter', 'carAdsService', 'enquiryService', '$routeParams', '$location',
    function ($scope, $filter, carAdsService, enquiryService, $routeParams, $location) {
        
    $scope.id = $routeParams.id;
    $scope.model = {
        carAds : carAdsService.getDetail($scope.id)        
    };
        
    //use for ui
    $scope.getCarPriceTag = carAdsService.getCarPriceTag;
}]);