import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {URL} from "../../models/url.model";


@Injectable({
  providedIn: 'root'
})
export class UrlService {
  public urls: URL[] = [];
  constructor(private http:HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public getUrls(): Observable<URL[]>{
   return  this.http.get<URL[]>(this.baseUrl + 'url');
  }
  public addUrl(addUrlRequest: URL): Observable<URL>{
   return  this.http.post<URL>(this.baseUrl + 'url', addUrlRequest);

  }
}
