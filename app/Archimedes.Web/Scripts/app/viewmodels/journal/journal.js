define(['plugins/http', 'durandal/app', 'knockout', 'durandal/system', 'components/componentRegistry', 'dataService'], function (http, app, ko, system, components, dataService) {

	var ctor = function () {

		var self = this;

		self.entries = ko.observableArray([]);

		dataService.request("/Journal/Entries", "GET", {}, function (data) {
			self.entries(data.Result);
		});
	};

	return ctor;
});