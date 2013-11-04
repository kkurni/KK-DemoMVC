describe('carAdsEnumParser', function () {

    var service, rootScope;

    beforeEach(module('main'));

    beforeEach(angular.mock.inject(function (_carAdsEnumParser_, $rootScope) {
        service = _carAdsEnumParser_;
        rootScope = $rootScope;
    }));

    describe("priceTypeByKey(key)", function () {
        it("should return null on invalid", function () {
            expect(service.priceTypeByKey('unknown')).toBeNull();
        });

        it("should return POA", function () {
            expect(service.priceTypeByKey('POA').id).toEqual(0);
        });
        
        it("should return DAP", function () {
            expect(service.priceTypeByKey('DAP').id).toEqual(1);
        });
        
        it("should return EGC", function () {
            expect(service.priceTypeByKey('EGC').id).toEqual(2);
        });
    });
    
    describe("priceTypeById(Id)", function () {
        it("should return null on invalid", function () {
            expect(service.priceTypeById(99)).toBeNull();
        });

        it("should return POA", function () {
            expect(service.priceTypeById(0).key).toEqual('POA');
        });

        it("should return DAP", function () {
            expect(service.priceTypeById(1).key).toEqual('DAP');
        });

        it("should return EGC", function () {
            expect(service.priceTypeById(2).key).toEqual('EGC');
        });
    });

});