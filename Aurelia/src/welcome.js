import {inject} from 'aurelia-framework';
import {OidcTokenManager} from 'oidc-token-manager';
import {Configure} from 'aurelia-configuration';

@inject(Configure)
export class Welcome {
    heading = 'Access Tokens';
    isAuthenticated = false;
    
    constructor(config) {
        this.config = config;
        this.manager = new OidcTokenManager(this.config.get("authSettings"));
        
        this.tokenText = this.manager.access_token
            ? this.manager.access_token
            : "No token";
        
        this.manager.addOnTokenObtained(function () {
            this.tokenText = this.manager.access_token;
        });
    };

}

// export class Welcome {
//     heading = 'Access Tokens Disabled';
// }