var app = angular.module(APP_NAME);

app.controller(VIEW_COMPONENTS_CONTROLLER, [
	'$scope', '$http', '$location', function ($scope, $http, $location) {
		
		$scope.components = null;

		$scope.getComponents = function () {
			$http.get("http://localhost:9000/api/components")
				.success(function (result) {
					$scope.components = result;
				});
		}

		$scope.deleteComponent = function (component) {
			$http.delete("http://localhost:9000/api/components?name=" + component.Name)
				.success(function() {
					refreshComponents();
				});
		}

		function refreshComponents() {
			$scope.components = {};
			$scope.getComponents();
		}

		refreshComponents();
	}
]);