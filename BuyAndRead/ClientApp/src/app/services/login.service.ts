import {Inject, Injectable} from "@angular/core";
import {Observable} from "rxjs";
import {Token} from "@angular/compiler";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {Operator} from "rxjs";

export const ACCESS_TOKEN_KEY = 'buyandread_access_token'

@Injectable({providedIn:'root'})

export class LoginService {/*

  constructor(
  private http: HttpClient,
  @Inject(AUTH_API_URL) private apiUrl: string,
  private jwtHelper: JwtHelperService,
  private router: Router,
  ) {}

  login(promocode: string): Observable<Token> {

  }

  isAuthenticated(): boolean {}

  logout(): void {}
*/
}
