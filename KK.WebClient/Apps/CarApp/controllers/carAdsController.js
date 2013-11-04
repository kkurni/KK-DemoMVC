
appRoot.controller('CarAdsController', ['$scope', '$filter', 'carAdsService',
    function ($scope, $filter, carAdsService) {

    $scope.model = {};
    //get data    
    $scope.model.carAdsList = carAdsService.getAllListing();

    $scope.getCarPriceTag = carAdsService.getCarPriceTag;
}]);