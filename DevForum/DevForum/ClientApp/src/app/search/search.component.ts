import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  @Output() query = new EventEmitter<any>();

  constructor() { }

  ngOnInit() {
  }

  GetValue = (value: any) => {
    this.query.emit(value);
  }
}
