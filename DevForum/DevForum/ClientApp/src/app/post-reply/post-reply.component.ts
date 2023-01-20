import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {UserService} from '../../services/user/user.service';

@Component({
  selector: 'app-post-reply',
  templateUrl: './post-reply.component.html',
  styleUrls: ['./post-reply.component.css']
})
export class PostReplyComponent implements OnInit {

  @Input() postReplies: any;
  isAdmin: boolean;
  @Output() postReplyItem = new EventEmitter<any>();
  @Output() postReplyItemId = new EventEmitter<any>();

  constructor(private userService: UserService) {
  }

  ngOnInit() {
    this.userService.IsAdmin().subscribe(data => {
      if (data) {
        this.isAdmin = data;
      }
    });
  }

  GetPostItem = (e: Event) => {
    this.postReplyItem.emit(e);
  }
  DeletePost = (e: Event) => {
    this.postReplyItemId.emit(e);
  }
}
