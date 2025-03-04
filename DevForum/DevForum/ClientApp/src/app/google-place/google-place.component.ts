import { Component, OnInit } from '@angular/core';

declare const google: any;
@Component({
  selector: 'app-google-place',
  templateUrl: './google-place.component.html',
  styleUrls: ['./google-place.component.css']
})
export class GooglePlaceComponent implements OnInit {
  public latitude = 43.35556422551857;
  public longitude = 17.80951543291194;

  constructor() { }

  ngOnInit() {
  }
}
