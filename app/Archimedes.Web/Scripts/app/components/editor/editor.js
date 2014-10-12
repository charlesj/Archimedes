define(['knockout', 'screenfull', 'jquery'], function(ko, screenfull, $) {

	var ctor = function(content) {
		var self = this;
		self.content = content;
		self.wordCount = ko.observable(0);

		content.subscribe(function(newVal) {
			s = s.replace(/(^\s*)|(\s*$)/gi, "");//exclude  start and end white-space
			s = s.replace(/[ ]{2,}/gi, " ");//2 or more space to 1
			s = s.replace(/\n /, "\n"); // exclude newline with a start spacing
			self.wordCount(s.split(' ').length);
		});

		this.goFullscreen = function() {
			var target = $('#editorContent')[0]; // Get DOM element from jQuery collection

			if (screenfull.enabled) {
				screenfull.request(target);
			}
		}
	}

	return {
		viewModel: ctor
	};
});