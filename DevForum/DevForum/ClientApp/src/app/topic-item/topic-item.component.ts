import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-topic-item',
  templateUrl: './topic-item.component.html',
  styleUrls: ['./topic-item.component.css']
})
export class TopicItemComponent implements OnInit {

  @Input() topics: any
  @Input() isAdmin: boolean
  @Output() topicItem = new EventEmitter<any>();
  constructor() { }

  ngOnInit() {
  }

  GetItem = (item: any) => {
    this.topicItem.emit(item);
  }

}
