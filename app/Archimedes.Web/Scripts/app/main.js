requirejs.config({
    paths: {
        'text': '../text',
        'durandal':'../durandal',
        'plugins' : '../durandal/plugins',
        'transitions' : '../durandal/transitions',
        'knockout': '../knockout-3.2.0',
        'bootstrap': '../bootstrap',
        'jquery': '../jquery-2.1.1'
    },
    shim: {
        'bootstrap': {
            deps: ['jquery'],
            exports: 'jQuery'
       }
    }
});

define(['durandal/system', 'durandal/app', 'durandal/viewLocator', '../pace'],  function (system, app, viewLocator) {
    
    system.debug(true);

    app.title = 'Archimedes';

    app.configurePlugins({
        router:true,
        dialog: true
    });

    app.on('all').then(function (event) {
	    system.log("Event Published: " + event);
    });

    app.start().then(function() {
        //Replace 'viewmodels' in the moduleId with 'views' to locate the view.
        //Look for partial views in a 'views' folder in the root.
        viewLocator.useConvention();

        //Show the app by setting the root view model for our application with a transition.
        app.setRoot('viewmodels/shell');
    });
});