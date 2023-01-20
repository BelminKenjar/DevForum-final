import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-post-item',
  templateUrl: './post-item.component.html',
  styleUrls: ['./post-item.component.css']
})
export class PostItemComponent implements OnInit {

  @Input() posts: any;
  @Input() isAdmin: boolean;
  @Output() postItem = new EventEmitter<any>();
  @Output() postItemId = new EventEmitter<any>();
  constructor() { }

  ngOnInit() {
  }

  GetItem = (item: any) => {
    this.postItem.emit(item);
  }
  DeleteTopic = (id: any) => {
    this.postItemId.emit(id);
  }

}
