var app = angular.module(APP_NAME);

app.controller(ABOUT_CONTROLLER, [
	'$scope', '$http', function ($scope, $http) {
		var vm = this;
		vm.components = null;
	}
]);