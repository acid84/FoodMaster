var app = angular.module(APP_NAME);

app.config(['$routeProvider', function ($routeProvider) {
		$routeProvider.
			when(VIEW_COMPONENTS_ROUTE, {
				templateUrl: VIEW_COMPONENTS_VIEW,
				controller: VIEW_COMPONENTS_CONTROLLER
			}).
			when(ABOUT_ROUTE, {
				templateUrl: ABOUT_VIEW,
				controller: ABOUT_CONTROLLER
			})
			.when(EDIT_COMPONENT_ROUTE, {
				templateUrl: EDIT_COMPONENT_VIEW,
				controller: EDIT_COMPONENT_CONTROLLER
			})
			.when(ADD_COMPONENT_ROUTE, {
				templateUrl: ADD_COMPONENT_VIEW,
				controller: ADD_COMPONENT_CONTROLLER
			})
			.when(ADD_DISH_ROUTE, {
				templateUrl: ADD_DISH_VIEW,
				controller: ADD_DISH_CONTROLLER
			})
			.when(VIEW_DISHES_ROUTE, {
				templateUrl: VIEW_DISHES_VIEW,
				controller: VIEW_DISHES_CONTROLLER
			});
	}
]);