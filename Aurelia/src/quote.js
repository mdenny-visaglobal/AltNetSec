import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-http-client';
import {OidcTokenManager} from 'oidc-token-manager';
import {Configure} from 'aurelia-configuration';

@inject(HttpClient, Configure)
export class Quote {

  heading = 'Quote';

  randomQuote = '';
  errorMessage = '';

  constructor(http, config) {
    this.http = http;
    this.config = config;
    this.manager = new OidcTokenManager(this.config.get("authSettings"));        
  };

  activate() {
      var client = new HttpClient()
      .configure(x => {
          x.withBaseUrl("http://localhost:7820");
          x.withHeader("Authorization", "Bearer " + this.manager.access_token);
      })
    return client
    .get("/")
    .then(response => {
      this.randomQuote = response.content;
    }).catch(error => {
      this.errorMessage = 'Error getting quote. Status code: ' + error.statusCode 
        + ", Status Text: " + error.statusText
        + ", Response: " + JSON.stringify(error.response);
    });
  };
}

// import {inject} from 'aurelia-framework';
// import {HttpClient} from 'aurelia-http-client';
// 
// @inject(HttpClient)
// export class Quote {
// 
//   heading = 'Quote';
// 
//   randomQuote = '';
//   errorMessage = '';
// 
//   constructor(http) {
//     this.http = http;
//   };
// 
//   activate() {
//       var client = new HttpClient()
//       .configure(x => {
//           x.withBaseUrl("http://localhost:7820");
//       })
//     return client
//     .get("/")
//     .then(response => {
//       this.randomQuote = response.content;
//     }).catch(error => {
//       this.errorMessage = 'Error getting quote. Status code: ' + error.statusCode 
//         + ", Status Text: " + error.statusText
//         + ", Response: " + JSON.stringify(error.response);
//     });
//   };
// }