appRoot.factory('carAdsService', ['$resource','$filter', 'carAdsEnumParser',
	function ($resource, $filter, carAdsEnumParser) {

	    var carAdsResource = $resource("/api/carAds", {}, {
	        get: {
	            method: 'GET',
	            isArray: true
	        },
	        getDetail: {
	            method: 'GET',
	            params: {
	                id: '{id}'
	            },
	        },
	    });

	    var getCarPriceTag = function (carListed) {
	        if (!carListed) {
	            return "";
	        }
	        
	        var priceType = carAdsEnumParser.priceTypeById(carListed.priceType);
	        var priceTag = priceType.key + " (" + priceType.description + ")";

	        //to make sure if it is POA , it will change it to 0
	        if (priceType.key === 'POA') {
	            return priceTag;
	        } else {
	            return "$" + $filter('number')(carListed.price) + " " + priceTag;
	        }
	    };

	    
	    //Wrapping in a service so that the interface to putJob is cleaner
	    var service = {	        
	        getAllListing: function (successHandler, errorHandler) {
	            return carAdsResource.get({}, {}, successHandler, errorHandler);
	        },
	        getDetail: function (id, successHandler, errorHandler) {
	            return carAdsResource.getDetail({ id: id }, {}, successHandler, errorHandler);
	        },
	        getCarPriceTag: getCarPriceTag
	    };

	    return service;
	}
]);