import {Component, NgModule} from '@angular/core';
import { Guid } from "guid-typescript";
import { HttpClient } from '@angular/common/http';
import {NgForm} from "@angular/forms";
import {Router} from "@angular/router";

@Component({
  selector: 'app-home',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  invalidLogin: boolean;



  constructor(private router: Router, private http: HttpClient) { }

  login(form: NgForm) {
    const credentials = {
    'Promocode': form.value.Promocode
    }

    this.http.post("http://localhost:5001/api/auth/login", credentials)
      .subscribe(response => {
        const token = (<any>response).token;
        localStorage.setItem("jwt", token);
        this.invalidLogin = false;
        this.router.navigate(["/"]);
      }, err => {
        this.invalidLogin = true;
      })


    }





}
