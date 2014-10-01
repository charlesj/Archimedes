define(['plugins/http', 'jquery', 'durandal/system', 'durandal/app', 'dataService'], function (http, $, system, app, dataService) {
	system.log('loading data service');

	var login = function(username, password) {
		dataService.request("/Security/Login", "POST", { username: username, password: password }, function (data) {
			securityToken = data.token;
		});
	};

	var logout = function() {
		dataService.request("/Security/Logout", "POST", {}, function (data) {
			securityToken = null;
		});
	};

	return {
		confirmLogin: function(callback) {
			dataService.request("/Security/TestAuthorization", "GET", {}, function(data) {
				system.log("user is logged in");
				callback();
			});
		},
		login: login,
		logout: logout
	};
});