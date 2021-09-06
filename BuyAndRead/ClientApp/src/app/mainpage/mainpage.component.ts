import { Component } from '@angular/core';
import {Router} from "@angular/router";
import {JwtHelperService} from '@auth0/angular-jwt';

@Component({
  selector: 'app-counter-component',
  templateUrl: './mainpage.component.html'
})
export class MainpageComponent {

  constructor(private router: Router, private jwtHelper: JwtHelperService) {
  }

  isUserAuthenticated() {
    const token: string = localStorage.getItem("jwt");
    if (token && this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else {
      return false;
    }
  }

  logOut() {
    localStorage.removeItem("jwt");
  }


}
