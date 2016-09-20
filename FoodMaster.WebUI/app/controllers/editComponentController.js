var app = angular.module(APP_NAME);

app.controller(EDIT_COMPONENT_CONTROLLER, [
	'$scope', '$http', '$routeParams', '$location', function ($scope, $http, $routeParams, $location) {
		$scope.component = null;
		$scope.id = null;
		

		function getComponent(id) {
			$http.get("http://localhost:9000/api/components/?name=" + id)
				.success(function (result) {
					$scope.id = result.Name;
					$scope.component = result;
				});
		}

		$scope.updateComponent = function (component) {
			if ($scope.id !== undefined) {
				$http.put("http://localhost:9000/api/components?name=" + $scope.id, component)
					.success(function () {
						$location.path(VIEW_COMPONENTS_ROUTE);
					});
			} else {
				$http.post("http://localhost:9000/api/components", component)
				.success(function () {
					$location.path(VIEW_COMPONENTS_ROUTE);
				});
			}
		}

		function initializeCreateNew() {
			$scope.HeaderText = "Add component";
			createTypes();

			$scope.component = {};
			$scope.component.Type = $scope.Types[0];
		}

		function initializeEdit(id) {
			$scope.HeaderText = "Edit component";
			createTypes();
			getComponent(id);
		}

		function createTypes() {
			$scope.Types = new Array();
			$scope.Types.push('100gr');
			$scope.Types.push('St');
		}

		if ($routeParams.id != undefined) {
			initializeEdit($routeParams.id);
		} else {
			initializeCreateNew();
		}
	}]);