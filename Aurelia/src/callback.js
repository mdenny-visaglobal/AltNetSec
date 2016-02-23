import {OidcTokenManager} from 'oidc-token-manager';

export class Callback {
    
    constructor() {
        this.settings = {
            client_id: 'js',
            authority: "https://localhost:44304/core"
        };
        this.manager = new OidcTokenManager(this.settings);

        var hash = window.location.hash;
        var queryString = hash.slice(hash.indexOf('?')+1);
        
        this.manager.processTokenCallbackAsync(queryString).then(function () {
            window.location.replace("/");
        }, function (error) {
            console.error("Problem Getting Token : " + (error.message || error));
        });
    };
}