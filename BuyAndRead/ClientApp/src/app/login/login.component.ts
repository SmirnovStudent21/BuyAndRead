import {Component, NgModule} from '@angular/core';
import { FormControl } from '@angular/forms';
import { Guid } from "guid-typescript";
//import {GuardService} from "../guard.service";
import { HttpClientModule } from '@angular/common/http';




@Component({
  selector: 'app-home',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  promocode = '';



  constructor() {}

  public codeField: Guid;

  public getInput()
  {
    let codeField = (document.getElementById("pcode") as HTMLInputElement).value;
    return codeField;


  }

  public loginReq()
  {
    let codeField = (document.getElementById("pcode") as HTMLInputElement).value;
  }
  public codeGenReq()
  {

  }


}
