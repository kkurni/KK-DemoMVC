appRoot.factory('carAdsEnumParser', ['carAdsEnum', '$filter',
    function (carAdsEnum, $filter) {

        var filterEnum = function (enumCollection, key, value) {
            if (key != undefined && key != null) {
                var result = $filter('filter')(enumCollection, function (item) {
                    return item[key] == value;
                });

                if (result && result.length) {
                    return result[0];
                }
            }

            return null;
        };

        var filterByEnumKey = function (enumCollection, keyValue) {
            return filterEnum(enumCollection, "key", keyValue);
        };
        
        var filterByEnumId = function (enumCollection, keyValue) {
            return filterEnum(enumCollection, "id", keyValue);
        };

        var priceTypeByKey = function (key) {
            return filterByEnumKey(carAdsEnum.priceType, key);
        };
        
        var priceTypeById = function (id) {
            return filterByEnumId(carAdsEnum.priceType, id);
        };
        
        return {
            priceTypeByKey: priceTypeByKey,
            priceTypeById: priceTypeById
        };
    }
]);