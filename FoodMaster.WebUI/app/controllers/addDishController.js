var app = angular.module(APP_NAME);

app.controller(ADD_DISH_CONTROLLER, ['$scope', '$http', '$location', function ($scope, $http, $location) {
	$scope.components = [];
	
	$scope.court = {};
	$scope.court.components = [];

	$scope.getComponents = function () {
		$http.get("http://localhost:9000/api/components")
			.success(function (result) {
				$scope.components = result;
			});
	}

	$scope.addComponent = function (component) {
		// For some reason we get a json object back from selected item. We need to convert it to a real object.
		var componentObject = JSON.parse(component);
		$scope.court.components.push(componentObject);
	}

	$scope.save = function() {
		$http.post("http://localhost:9000/api/dishes", $scope.court)
	.success(function () {
		$location.path(VIEW_DISHES_ROUTE);
	});
	}


	$scope.getComponents();
}
]);