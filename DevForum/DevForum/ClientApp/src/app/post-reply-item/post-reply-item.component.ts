import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {ProfileService} from '../../services/profile/profile.service';

@Component({
  selector: 'app-post-reply-item',
  templateUrl: './post-reply-item.component.html',
  styleUrls: ['./post-reply-item.component.css']
})
export class PostReplyItemComponent implements OnInit {

  @Input() postReplies: any;
  @Input() isAdmin: boolean;
  @Output() postReplyItem = new EventEmitter<any>();
  @Output() postReplyItemId = new EventEmitter<any>();

  constructor() { }

  ngOnInit() {
  }

  GetItem = (item: any) => {
    this.postReplyItem.emit(item);
  }
  DeleteTopic = (id: any) => {
    this.postReplyItemId.emit(id);
  }
}
