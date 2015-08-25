define(['knockout', 'dataService', 'durandal/system', 'plugins/dialog', 'require', 'viewmodels/createManuscript', 'durandal/app'], function (ko, dataService, system, dialog, require, create, app) {
	var ctor = function () {
		
		var self = this;

		self.manuscripts = ko.observableArray([]);

		//dataService.request("/Manuscripts/GetAll", "GET", {}, function (data) {
		//	self.manuscripts(data.Result);
		//});

		self.createManuscript = function() {
			dialog.show(new create());
		};

		app.on('manuscript.new').then(function (manuscript) {
			self.manuscripts.push(manuscript);
		});
	};



	return ctor;
});