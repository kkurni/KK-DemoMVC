appRoot.factory('serverErrorInterceptor', ['$q', '$location',
	function ($q, $location) {
	    return {
	        request: function (config) {
	            
	            return $q.when(config);
	        },
	        response: function (response) {

	            return $q.when(response);
	        },
	        responseError: function (response) {	            
	            //navigate to api error
	            return $location.path("/car/apiError");
	        }
	    };
	}
]);