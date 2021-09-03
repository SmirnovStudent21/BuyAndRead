import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import {LoginComponent} from "./login/login.component";
import {MainpageComponent} from "./mainpage/mainpage.component";
import {JwtModule} from '@auth0/angular-jwt';
import {WildcardComponent} from "./wildcard/wildcard.component";
import {environment} from "../environments/environment";
import {ACCESS_TOKEN_KEY} from "./services/login.service";

export function tokenGetter()
{
  return localStorage.getItem(ACCESS_TOKEN_KEY);
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    MainpageComponent,
    LoginComponent,
    WildcardComponent
    /*FetchDataComponent*/
  ],
    imports: [
        BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            {path: 'login', component: LoginComponent},
            {path: 'main', component: MainpageComponent},
            {path: '', redirectTo: '/login', pathMatch: 'full'},
            {path: '**', component: WildcardComponent}
            /*{path: 'fetch-data', component: FetchDataComponent}, */
        ]),
        ReactiveFormsModule,
        JwtModule.forRoot({
          config: {
            tokenGetter,
            allowedDomains: environment.tokenWhiteListedDomains
          }
        })
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
