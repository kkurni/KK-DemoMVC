describe('CarAdsDetailController', function () {

    var controller, $scope, $rootScope, carAdsService;

    beforeEach(module('main'));

    beforeEach(angular.mock.inject(function ($controller, _$rootScope_, _carAdsService_) {
        $rootScope = _$rootScope_;
        carAdsService = _carAdsService_;
        $scope = _$rootScope_.$new();
        
        controller = $controller('CarAdsDetailController', {
            $scope: $scope,           
        });
    }));


    describe("onInit", function () {
        beforeEach(angular.mock.inject(function ($controller) {
            spyOn(carAdsService, 'getDetail');
            controller = $controller('CarAdsDetailController', {
                $scope: $scope,
                carAdsService: carAdsService
            });
                        
        }));

        it("should return call car service", function () {
            expect(carAdsService.getDetail).toHaveBeenCalled();
        });
    });
});