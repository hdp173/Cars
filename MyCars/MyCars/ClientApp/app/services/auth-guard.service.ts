import { AuthService } from './auth.service';
import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router/src/interfaces';
import { Router } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate{
    constructor(private auth: AuthService,
                private router: Router)     
    {

    }

    canActivate() {
        if(this.auth.isAuthenticated())    
            return true;

        //this.router.navigate(['/home']);
        return false;
    }
}