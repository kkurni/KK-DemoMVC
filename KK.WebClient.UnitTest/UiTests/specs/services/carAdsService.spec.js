describe('carAdsService', function () {

    var service, rootScope, url, $httpBackend;

    beforeEach(module('main'));

    beforeEach(angular.mock.inject(function (_carAdsService_, $rootScope, _$httpBackend_) {        
        rootScope = $rootScope;
        $httpBackend = _$httpBackend_;
        url = '/api/carAds';
        
        service = _carAdsService_;
    }));

    describe("getCarPriceTag", function () {
        it("should return POA when price type is 0", function () {
            expect(service.getCarPriceTag({
                priceType: 0,
                price:100
            })).toEqual('POA (Price on Application)');
        });
        
        it("should return DAP when price type is 1", function () {
            expect(service.getCarPriceTag({
                priceType: 1,
                price : 100
            })).toEqual('$100 DAP (Driveaway Price)');
        });
        
        it("should return EGC when price type is 2", function () {
            expect(service.getCarPriceTag({
                priceType: 2,
                price: 100
            })).toEqual('$100 EGC (Excluding Government Charges)');
        });
    });
    
    describe("get", function () {
        it("should ", function () {
            expect(service.getCarPriceTag({
                priceType: 0,
                price: 100
            })).toEqual('POA (Price on Application)');
        });
    });
    

    describe('on Get action', function () {
        describe('on Success', function () {
            it('should call get', function () {
                $httpBackend.expectGET(url).respond(200);
                service.getAllListing();
                $httpBackend.flush();
            });
        });
    });
    
    describe('on Getdetail action', function () {
        describe('on Success', function () {
            it('should call get', function () {
                $httpBackend.expectGET(url+ "?id=1").respond(200);
                service.getDetail(1);
                $httpBackend.flush();
            });
        });
    });
    
});