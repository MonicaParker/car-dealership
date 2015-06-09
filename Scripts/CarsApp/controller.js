(function () {
    //View controllers
    angular.module("CarDealershipApplication").controller("CustomerViewController", function ($location) {
        this.move = function (id) {
            $location.path('dealerView/')
        };
    });

    //Search Controller
    angular.module("CarDealershipApplication").controller("SearchController", function ($resource) {
        var self = this;
        //fetch by model
        var Car = $resource('/api/cars', null, {
            getTesla: { method: 'GET', isArray: true, url: '/api/cars/GetTesla' },
            getRolls: { method: 'GET', isArray: true, url: '/api/cars/GetRolls' }
        });

        //fetch all cars
        self.cars = Car.query();

        self.getTesla = function () {
            self.cars = Car.getTesla();
        }
        self.getRolls = function () {
            self.cars = Car.getRolls();
        }

        self.fetch = function () {
            console.log("searching");
            var search = self.search.toLowerCase();
            self.cars = self.cars.filter(function (item) {
                return item.Title.toLowerCase().includes(search);

            });

            self.refresh = function () {
                self.cars = Car.query();
            }
        }

        //Add new car
        self.add = function () {
            var newCar = new Car({
                Title: self.newCar.title,
                Price: self.newCar.price,
                Picture: self.newCar.picture,
                BriefDescription: self.newCar.briefDescription,
                FullDescription: self.newCar.fullDescription,
                Type: self.newCar.type,
                GasMileage: self.newCar.gasMileage,
                Range: self.newCar.range,
                ChargeTime: self.newCar.chargeTime
            });
            newCar.$save(function (result) {
                self.cars.push(result);
            });
        }

        //Update existing car
        self.update = function (originalCar) {
            originalCar.Title = self.newCar.title,
            originalCar.Price = self.newCar.price,
            originalCar.Picture = self.newCar.picture,
            originalCar.BriefDescription = self.newCar.briefDescription,
            originalCar.FullDescription = self.newCar.fullDescription,
            originalCar.Type = self.newCar.type,
            originalCar.GasMileage = self.newCar.gasMileage,
            originalCar.Range = self.newCar.range,
            originalCar.ChargeTime = self.newCar.chargeTime
            originalCar.$save();
        }

        //Remove existing car
        self.remove = function (originalCar) {
            originalCar.$remove({ id: originalCar.Id }, function () {
                self.cars = self.cars.filter(function (car) {
                    return car.Id != originalCar.Id;
                });
            });
        };


    });

    

    //UI controllers
    angular.module('CarDealershipApplication').controller('DropdownCtrl', function ($scope, $log) {
        $scope.items = [
          'Rolls-Royce',
          'Tesla'
        ];

        $scope.status = {
            isopen: false
        };

        $scope.toggled = function (open) {
            $log.log('Dropdown is now: ', open);
        };

        $scope.toggleDropdown = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();
            $scope.status.isopen = !$scope.status.isopen;
        };
    });



    angular.module('CarDealershipApplication').controller('ModalCtrl', function ($scope, $modal, $log) {

        $scope.items = [];

        $scope.animationsEnabled = true;

        $scope.open = function (size) {

            var modalInstance = $modal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'customerView.html',
                controller: 'ModalCtrl',
                size: size,
                resolve: {
                    items: function () {
                        return $scope.items;
                    }
                }
            });
            modalInstance.result.then(function (selectedItem) {
                $scope.selected = selectedItem;
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };

        $scope.toggleAnimation = function () {
            $scope.animationsEnabled = !$scope.animationsEnabled;
        };

    });

    // Please note that $modalInstance represents a modal window (instance) dependency.
    // It is not the same as the $modal service used above.

    //angular.module('CarDealershipApplication').controller('ModalCtrl', function ($scope, $modalInstance, items) {

    //    $scope.items = items;
    //    $scope.selected = {
    //        item: $scope.items[0]
    //    };

    //    $scope.ok = function () {
    //        $modalInstance.close($scope.selected.item);
    //    };

    //    $scope.cancel = function () {
    //        $modalInstance.dismiss('cancel');
    //    };
    //});

    

})();