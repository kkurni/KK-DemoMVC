appRoot.factory('enquiryService', ['$resource','$filter',
	function ($resource) {

	    var enquiryResource = $resource("/api/enquiry", {}, {
	        get: {
	            method: 'GET',
	            isArray: true
	        },
	        add: {
	            method: 'POST'
	        },
	    });

	    
	    //Wrapping in a service so that the interface to putJob is cleaner
	    var service = {	        
	        getAllListing: function (successHandler, errorHandler) {
	            return enquiryResource.get({}, {}, successHandler, errorHandler);
	        },
	        add: function (detail, successHandler, errorHandler) {
	            return enquiryResource.add({}, detail, successHandler, errorHandler);
	        }
	    };

	    return service;
	}
]);