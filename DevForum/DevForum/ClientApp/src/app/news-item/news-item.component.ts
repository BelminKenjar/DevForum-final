import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-news-item',
  templateUrl: './news-item.component.html',
  styleUrls: ['./news-item.component.css']
})
export class NewsItemComponent implements OnInit {

  @Input() newsItems: any
  @Input() isAdmin: boolean
  @Output() newsEvent = new EventEmitter<any>();

  constructor() { }

  ngOnInit() {
  }

  GetId = (id: any) => {
    this.newsEvent.emit(id);
  }

}
