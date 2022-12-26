import { Component, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http';
import {URL} from '../../models/url.model'
import {UrlService} from "../services/url.service";


@Component({
  selector: 'app-short-urltable',
  templateUrl: './short-urltable.component.html'
})
export class ShortURLTableComponent {
  public urls: URL[] = [];
  addUrlRequest:URL={
    id : 0,
    long:'',
    short:'',
    createdBy:'',
    createdDate:'2019-01-06T17:16:40'
}

  constructor(private urlService: UrlService) {
  }
  ngOnInit():void{
    this.urlService
      .getUrls()
      .subscribe((result: URL[])=>(this.urls = result));
  }
  addUrl(){
    this.urlService.addUrl(this.addUrlRequest)
      .subscribe();

  }
}



