var app = angular.module(APP_NAME);

app.controller(EDIT_COMPONENT_CONTROLLER, [
	'$scope', '$http', '$routeParams', '$location', function ($scope, $http, $routeParams, $location) {
		$scope.component = null;
		$scope.id = null;
		$scope.HeaderText = "Edit component";
		function getComponent(id) {
			$http.get("http://localhost:9000/api/components/?name=" + id)
				.success(function (result) {
					$scope.id = result.Name;
					$scope.component = result;
				});
		}

		$scope.updateComponent = function(component) {
			$http.put("http://localhost:9000/api/components?name=" + $scope.id, component)
				.success(function () {
					$location.path(VIEW_COMPONENTS_ROUTE);
				});
		}
		getComponent($routeParams.id);
	}]);