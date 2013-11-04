describe('EnquiryFormController', function () {

    var controller, $scope, $rootScope, enquiryService;

    beforeEach(module('main'));

    beforeEach(angular.mock.inject(function ($controller, _$rootScope_, _enquiryService_) {
        $rootScope = _$rootScope_;
        enquiryService = _enquiryService_;
        $scope = _$rootScope_.$new();

        controller = $controller('EnquiryFormController', {
            $scope: $scope,           
        });
    }));

    describe("sendEnquiry", function () {
        
        it("should call enquire service when valid model", function () {
            //arrange
            spyOn(enquiryService, 'add');
            $scope.enquiryForm = {                
                $dirty: true,
                $valid:true,                
            };
            //act
            $scope.sendEnquiry();
            //assert
            expect(enquiryService.add).toHaveBeenCalled();
        });
        
        it("should not call enquire service when invalid model", function () {
            //arrange
            spyOn(enquiryService, 'add');
            $scope.enquiryForm = {                
                $dirty: true,
                $valid: false,
                showErrors: function() {
                }
            };
            //act
            $scope.sendEnquiry();
            //assert
            expect(enquiryService.add).not.toHaveBeenCalled();
        });
        
        it("should call showErrors when invalid model", function () {
            //arrange
            spyOn(enquiryService, 'add');
            $scope.enquiryForm = {
                $dirty: true,
                $valid: false,
                showErrors: function () {
                }
            };
            spyOn($scope.enquiryForm, 'showErrors');
            //act
            $scope.sendEnquiry();
            //assert
            expect($scope.enquiryForm.showErrors).toHaveBeenCalled();
        });    
    });
});