import {Component, OnInit} from '@angular/core';
import { FormBuilder } from '@angular/forms';
import {HttpService} from "./services/http.service";
import {Usercl} from "./usercl";
import {User} from "oidc-client";
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  providers: [HttpService]
})
export class AppComponent implements OnInit {
  title = 'app';

  usercl: User;
  constructor(private httpService: HttpService) {}

  ngOnInit(){

    this.httpService.getData().subscribe((data:any) => this.usercl=new User(data.Promocode));
  }
}
