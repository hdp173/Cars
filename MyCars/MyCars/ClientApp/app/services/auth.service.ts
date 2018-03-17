import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import 'rxjs/add/operator/filter';
import * as auth0 from 'auth0-js';

@Injectable()
export class AuthService {
  userProfile: any;

  auth0 = new auth0.WebAuth({
    clientID: 'vpGfLPA_uNDfGzRS-CkkhFDrQ4J6POib',
    domain: 'mycars.auth0.com',
    responseType: 'token id_token',
    audience: 'https://api.mycars.com',
    redirectUri: 'http://mycarspro.azurewebsites.net',
    scope: 'openid email'
  });

  constructor(public router: Router) {}

  public getProfile(): void {
    const accessToken = localStorage.getItem('access_token');
    if (!accessToken) {
      throw new Error('Access Token must exist to fetch profile');
    }
  
    const self = this;
    this.auth0.client.userInfo(accessToken, (err, profile) => {      
      if (profile) {                
        self.userProfile = profile;
        localStorage.setItem("profile",JSON.stringify(profile));    
      }
    });
  }

  public login(): void {    
    this.auth0.authorize();
  }

  public handleAuthentication(): void {
    this.auth0.parseHash((err, authResult) => {
      if (authResult && authResult.accessToken && authResult.idToken) {
        window.location.hash = '';
        this.setSession(authResult);
        this.router.navigate(['/home']);
      } else if (err) {
        this.router.navigate(['/home']);
      }
    });
  }

  private setSession(authResult: any): void {
    // Set the time that the Access Token will expire at        
    const expiresAt = JSON.stringify((authResult.expiresIn * 1000) + new Date().getTime());
    localStorage.setItem('access_token', authResult.accessToken);
    localStorage.setItem('id_token', authResult.idToken);
    localStorage.setItem('token', authResult.accessToken);
    localStorage.setItem('expires_at', expiresAt);
    
    this.getProfile();         
  }

  public logout(): void {
    // Remove tokens and expiry time from localStorage
    localStorage.removeItem('access_token');
    localStorage.removeItem('id_token');
    localStorage.removeItem('expires_at');
    localStorage.removeItem('profile');
    localStorage.removeItem('token');
    this.userProfile = null;
    // Go back to the home route
    this.router.navigate(['/']);
  }

  public isAuthenticated(): boolean {
    // Check whether the current time is past the
    // Access Token's expiry time
    const expiresAt = JSON.parse(localStorage.getItem('expires_at') || new Date().getTime().toString());
    return new Date().getTime() < expiresAt;
  }

}