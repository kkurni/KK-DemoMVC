
appRoot.controller('EnquiryFormController', ['$scope', '$filter', 'carAdsService', 'enquiryService', '$routeParams', '$location',
    function ($scope, $filter, carAdsService, enquiryService, $routeParams, $location) {
    
    $scope.enquiryModel = {};

    $scope.sendEnquiry = function () {
        if ($scope.enquiryForm && $scope.enquiryForm.$dirty) {
            
            if ($scope.enquiryForm.$valid) {
                
                //update carAds ID
                $scope.enquiryModel.carAdsId = ($scope.model && $scope.model.carAds) ? $scope.model.carAds.id : undefined;                

                //do stuff here
                var successHandler = function() {
                    $location.path("/car/enquiryConfirmation");
                };
                enquiryService.add($scope.enquiryModel, successHandler, undefined);
            }
            else {
                $scope.enquiryForm.showErrors();
            }
        }
    };
}]);