appRoot.directive('kkForm', [
    function () {

        var markInvalidFieldsAsDirty = function (formCtrl) {
            angular.forEach(formCtrl.$error, function (validationFailure) {

                angular.forEach(validationFailure, function (fieldOrForm) {

                    if (angular.isFunction(fieldOrForm.$addControl)) {
                        markInvalidFieldsAsDirty(fieldOrForm);
                    } else {
                        //mark field as dirty
                        fieldOrForm.$setViewValue(fieldOrForm.$viewValue);
                    }
                });
            });
        };

        return {
            restrict: 'A',
            require: 'form',
            link: function (scope, element, attributes, formCtrl) {

                formCtrl.showErrors = function () {

                    markInvalidFieldsAsDirty(formCtrl);

                    formCtrl.$setDirty();
                };

                formCtrl.$reset = function () {
                    element[0].reset();
                    formCtrl.$setPristine();
                };
            }
        };
    }
]);