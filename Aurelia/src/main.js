import 'bootstrap';

export function configure(aurelia) {
  aurelia.use
    .standardConfiguration()
    .developmentLogging()
    .plugin("aurelia-configuration");
    
  aurelia.start().then(() => aurelia.setRoot());
}
