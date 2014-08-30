define(['plugins/http', 'durandal/app', 'knockout', 'durandal/system'], function (http, app, ko, system) {

	return {
		currentTheme: ko.observable('Light'),
		availableThemes: ko.observableArray(['Light', 'Dark']),
		activate: function () {
		},
		select: function (item) {
			system.log(item);
		},
		canDeactivate: function () {
			return true;
		}
	};
});