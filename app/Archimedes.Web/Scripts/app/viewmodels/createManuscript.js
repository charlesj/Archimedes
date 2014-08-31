define(['dataService', 'durandal/system', 'knockout', 'durandal/app', 'plugins/dialog'], function (dataService, system, ko, app, dialog) {
	var viewModel = function() {
		self.newTitle = ko.observable();
		self.newDescription = ko.observable();

		self.createManuscript = function() {
			dataService.request("/Manuscripts/Create", "POST", { title: self.newTitle(), description: self.newDescription }, function(data) {
				app.trigger('manuscript.new', data.Result);
			});
			system.log("creating new manuscript");
			dialog.close(this);
		}

		self.cancel = function() {
			dialog.close(this);
		};
	};

	return viewModel;
});