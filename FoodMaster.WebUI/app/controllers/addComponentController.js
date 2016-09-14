var app = angular.module(APP_NAME);

app.controller(ADD_COMPONENT_CONTROLLER, [
	'$scope', '$http', '$routeParams', '$location', function ($scope, $http, $routeParams, $location) {
		$scope.component = {};
		$scope.StoreButtonValue = "Save";
		$scope.HeaderText = "Add component";

		$scope.updateComponent = function (component) {
			$http.post("http://localhost:9000/api/components", component)
				.success(function () {
					$location.path(VIEW_COMPONENTS_ROUTE);
				});
		}
	}]);