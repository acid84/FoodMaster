var app = angular.module(APP_NAME);

app.controller(VIEW_DISHES_CONTROLLER, ['$scope', '$http', '$location', 'NgTableParams', function ($scope, $http, $location, NgTableParams) {

	$scope.dishes = null;

	$scope.getDishes = function () {
		$http.get("http://localhost:9000/api/dishes")
			.success(function (result) {
				$scope.dishes = result;
				$scope.tableParams = new NgTableParams({ count: $scope.dishes.length }, { dataset: $scope.dishes, counts: [] });
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
