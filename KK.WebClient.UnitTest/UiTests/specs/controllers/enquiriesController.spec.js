describe('EnquiriesController', function () {

    var controller, $scope, $rootScope, enquiryService;

    beforeEach(module('main'));

    beforeEach(angular.mock.inject(function ($controller, _$rootScope_, _enquiryService_) {
        $rootScope = _$rootScope_;
        enquiryService = _enquiryService_;
        $scope = _$rootScope_.$new();                
    }));


    describe("onInit", function () {
        beforeEach(angular.mock.inject(function ($controller) {
            spyOn(enquiryService, 'getAllListing');
            controller = $controller('EnquiriesController', {
                $scope: $scope,
                enquiryService: enquiryService
            });                        
        }));

        it("should return call car service", function () {
            expect(enquiryService.getAllListing).toHaveBeenCalled();
        });
    });    
});