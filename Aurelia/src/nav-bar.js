import {bindable} from 'aurelia-framework';
import {inject} from 'aurelia-framework';
import {OidcTokenManager} from 'oidc-token-manager'
import {Configure} from 'aurelia-configuration';

@inject(Configure)
export class NavBar {
    
    _isAuthenticated = false;
    @bindable router = null;
   constructor(config) {
       this.config = config;
        this.manager = new OidcTokenManager(this.config.get("authSettings"));

        this.manager.addOnTokenObtained(function () {
            console.log("Access token: " + this.manager.access_token);
            console.log("Expires in:" + this.manager.expires_in);
        });
    };

    login() {
        console.log("Logging in");
        this.manager.redirectForToken();
    }

    logout() {
        console.log("Logging out");
        this.manager.redirectForLogout();
    }

    get isAuthenticated() {
        return this.manager.access_token && !this.manager.expired;
    };
}

// import {bindable} from 'aurelia-framework';
// 
// export class NavBar { 
//     @bindable router = null;
// }
