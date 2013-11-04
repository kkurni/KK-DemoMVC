
appRoot.controller('EnquiriesController', ['$scope', 'enquiryService',
    function ($scope,  enquiryService) {

    $scope.model = {};
    //get data    
    $scope.model.enquiries = enquiryService.getAllListing();

}]);