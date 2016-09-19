var app = angular.module(APP_NAME);

app.controller(VIEW_COMPONENTS_CONTROLLER, [
	'$scope', '$http', '$location', '$window', 'NgTableParams', function ($scope, $http, $location, $window, NgTableParams) {
		$scope.components = null

		$scope.getComponents = function () {
			$http.get("http://localhost:9000/api/components")
				.success(function (result) {
					for (i = 0; i < result.length; i++) {
						var component = result[i];
						$scope.components.push(CreateComponentViewModel(component))
					}

					$scope.tableParams = new NgTableParams({ count: $scope.components.length}, { dataset: $scope.components, counts: [] });
				});
		}

		$scope.createNew = function () {
			$location.path("addcomponent");
		}

		function CreateComponentViewModel(component) {
			return {
				Name: component.Name,
				Carbs: component.NutritionValue.Carbs,
				Fat: component.NutritionValue.Fat,
				Fiber: component.NutritionValue.Fiber,
				Kcal: component.NutritionValue.Kcal
			}
		}
		$scope.deleteComponent = function (component) {
			var deleteMessage = "Do you want to delete " + component.Name + "?";
			var sure = $window.confirm(deleteMessage);

			if (sure) {
				$http.delete("http://localhost:9000/api/components?name=" + component.Name)
				.success(function () {
					refreshComponents();
				});
			}
		}

		function refreshComponents() {
			$scope.components = new Array();
			$scope.getComponents();
		}

		refreshComponents();
	}
]);