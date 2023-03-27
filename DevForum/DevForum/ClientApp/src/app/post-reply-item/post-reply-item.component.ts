import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {ProfileService} from '../../services/profile/profile.service';
import {PostReplyLikeService} from '../../services/postReplyLike/post-reply-like.service';

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
  profile: any;

  constructor(private profileService: ProfileService,
              private postReplyLikeService: PostReplyLikeService ) { }

  ngOnInit() {
    this.profileService.GetUserProfile().subscribe((x: any) => { this.profile = x; });
  }

  GetItem = (item: any) => {
    this.postReplyItem.emit(item);
  }
  DeletePostReply = (id: any) => {
    this.postReplyItemId.emit(id);
  }

  PostReplyLike(postReplyId: number) {
    let model;
    let profileId;
    profileId = this.profile.id;
    model = {postReplyId, profileId};
    this.postReplyLikeService.InsertPostReplyLike(model).subscribe(data => data);
    // return location.reload();
  }
}
