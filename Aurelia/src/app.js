export class App {
    configureRouter(config, router) {
        config.title = 'Identity Crisis';
        config.map([
            { route: ['', 'welcome'], name: 'welcome', moduleId: 'welcome', nav: true, title: 'Welcome' },
            { route: 'quote', name: 'quote', moduleId: 'quote', nav: true, title: 'Quote' },
            { route: 'callback', name: 'callback', moduleId: 'callback', nav: false, title: 'Authentication Callback' }
        ]);

        this.router = router;
    }
}
