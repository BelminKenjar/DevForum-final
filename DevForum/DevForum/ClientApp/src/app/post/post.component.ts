import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { UserService } from '../../services/user/user.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

  @Input() posts: any;
  isAdmin: boolean;
  @Output() postItem = new EventEmitter<any>();
  @Output() postItemId = new EventEmitter<any>();

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.IsAdmin().subscribe(data => {
      if (data) {
        this.isAdmin = data;
      }
    });
  }

  GetSubTopicItem = (e: Event) => {
    this.postItem.emit(e);
  }
  DeleteSubTopic = (e: Event) => {
    this.postItemId.emit(e);
  }
}
