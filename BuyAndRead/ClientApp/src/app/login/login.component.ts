import {Component, NgModule} from '@angular/core';
import { FormControl } from '@angular/forms';
import { Guid } from "guid-typescript";
//import {GuardService} from "../guard.service";
import { HttpClientModule } from '@angular/common/http';
import {HttpService} from "../services/http.service";
import {User} from "oidc-client";




@Component({
  selector: 'app-home',
  templateUrl: './login.component.html',
  providers: [HttpService]
})
export class LoginComponent {
 // promocode = '';

  /*public guidValue: string;
  constructor(  public Id?: number,
                public Promocode?: string )
  {
  }
  */
  usercl: User;
  constructor(private httpService: HttpService) {}

  public codeField: Guid;

  public getInput()
  {
    let codeField = (document.getElementById("pcode") as HTMLInputElement).value;
    return codeField;

    //this.httpService.getData().subscribe((data:any) => this.usercl=new User(data.Promocode));
  }

  public loginReq()
  {
    let codeField = (document.getElementById("pcode") as HTMLInputElement).value;
  }
  public codeGenReq()
  {

  }


}
