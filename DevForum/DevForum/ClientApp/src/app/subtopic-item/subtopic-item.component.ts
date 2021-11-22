import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-subtopic-item',
  templateUrl: './subtopic-item.component.html',
  styleUrls: ['./subtopic-item.component.css']
})
export class SubtopicItemComponent implements OnInit {

  @Input() subtopics: any
  @Input() isAdmin: boolean
  @Output() subtopicItem = new EventEmitter<any>();
  @Output() subtopicItemId = new EventEmitter<any>();
  constructor() { }

  ngOnInit() {
  }

  GetItem = (item: any) => {
    this.subtopicItem.emit(item);
  }
  DeleteTopic = (id: any) => {
    this.subtopicItemId.emit(id);
  }
}
