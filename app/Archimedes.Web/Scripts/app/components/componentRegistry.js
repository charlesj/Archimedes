define(['knockout'], function (ko) {

	ko.components.register('editor', {
		viewModel: { require: 'components/editor/editor' },
		template: { require: 'text!components/editor/editorTemplate.html' }
	});
});

