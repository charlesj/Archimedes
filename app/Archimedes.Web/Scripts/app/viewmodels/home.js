define(['knockout', 'dataService', 'durandal/system', 'plugins/router'], function (ko, dataService, system, router) {
	var ctor = function () {
		
		var self = this;

		self.manuscripts = ko.observableArray([]);
		self.newTitle = ko.observable();
		self.newDescription = ko.observable();

		self.createManuscript = function () {
			dataService.request("/Manuscripts/Create", "POST", { title: self.newTitle(), description: self.newDescription }, function(data) {
				self.manuscripts.push(data.Result);
			});
			system.log("creating new manuscript");
		}

		dataService.request("/Manuscripts/GetAll", "GET", {}, function (data) {
			self.manuscripts(data.Result);
		});

		self.nav = function() {
			router.navigate('settings');
		}
	};



	return ctor;
});