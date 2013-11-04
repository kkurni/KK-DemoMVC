appRoot.directive('kkError', [
	function() {

		return {
			restrict: 'EA',
			template: '<span class="validation" ng-show="displayErrors()" ng-animate="{ show: \'validation-show\'}">{{message}}</span>',
			replace: true,
			transclude: true,
			scope: true,
			compile: function(tElement, tAttrs, transclude) {

			    return {
			        post: function(scope, iElement, iAttrs) {

			            var form = iElement.inheritedData('$formController');

			            scope.displayErrors = function() {

			                if (form.$pristine) {
			                    return false;
			                }

			                var field = form[iAttrs.fieldName];

			                if (!field) {
			                    return false;
			                }

			                if (field.$pristine) {
			                    return false;
			                }

			                var hasError = field.$error[iAttrs.key];
			                return hasError;
			            };

			            transclude(scope, function(clone) {
			                scope.message = clone.html();
			            });
			        }
			    };
			}
		};
	}
]);