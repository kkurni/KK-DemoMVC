describe('enquiryService', function () {

    var service, rootScope, url, $httpBackend;

    beforeEach(module('main'));

    beforeEach(angular.mock.inject(function (_enquiryService_, $rootScope, _$httpBackend_) {        
        rootScope = $rootScope;
        $httpBackend = _$httpBackend_;
        url = '/api/enquiry';
        
        service = _enquiryService_;
    }));

    

    describe('on Get action', function () {
        describe('on Success', function () {
            it('should call get', function () {
                $httpBackend.expectGET(url).respond(200);
                service.getAllListing();
                $httpBackend.flush();
            });
        });
    });
    
    describe('on Add action', function () {
        describe('on Success', function () {
            it('should call get', function () {
                $httpBackend.expectPOST(url).respond(200);
                service.add({});
                $httpBackend.flush();
            });
        });
    });
    
});