define(['plugins/http', 'jquery', 'durandal/system', 'durandal/app'], function (http, $, system, app) {
	var handleErrorResult = function (data, textStatus, jqXHR) {
		app.showMessage(data.message);
		system.log(data);
	}

	var handleError = function (jqXHR, textStatus, errorThrown) {
		app.showMessage('There was an unknown issue with the request!');
	}

	var makeRequest = function(path, method, payload, callback) {
		$.ajax(path, {
			type: method,
			dataType: "json",
			data: payload,
			error: handleError,
			statusCode: {

			},
			success: function (data, textStatus, jqXhr) {
				console.log("status: " + jqXhr.status);
				if (data.status == 'success') {
					system.log("Command Executed Successfully in " + data.data.ExecutionTime + "ms");
					callback(data.data);
				} else {
					handleErrorResult(data, textStatus, jqXhr);
				}
			},
			complete: function (data) {
				system.log("ajax request completed");
			}
		});
	}

	return {
		request: makeRequest
	};
});