define(['plugins/http', 'durandal/app', 'knockout', 'durandal/system', 'dataService'], function (http, app, ko, system, dataService) {

	var ctor = function () {

		var self = this;

		self.entries = ko.observableArray([]);

		dataService.request("/Journal/Entries", "GET", {}, function (data) {
			self.entries(data.Result);
		});
	};

	return ctor;
});