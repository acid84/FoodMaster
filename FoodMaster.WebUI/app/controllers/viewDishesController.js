var app = angular.module(APP_NAME);

app.controller(VIEW_DISHES_CONTROLLER, ['$scope', '$http', '$location', function ($scope, $http, $location) {

	$scope.dishes = null;

	$scope.getDishes = function () {
		$http.get("http://localhost:9000/api/dishes")
			.success(function (result) {
				$scope.dishes = result;
			});
	}

	$scope.deleteDish = function (dish) {
		$http.delete("http://localhost:9000/api/dishes?name=" + dish.Name)
			.success(function () {
				refreshDishes();
			});
	}

	function refreshDishes() {
		$scope.dishes = {};
		$scope.getDishes();
	}

	refreshDishes();
}
]);
