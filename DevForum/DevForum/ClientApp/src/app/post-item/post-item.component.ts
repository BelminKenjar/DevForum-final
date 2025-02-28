import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {PostLikeService} from '../../services/postLike/post-like.service';
import {ProfileService} from '../../services/profile/profile.service';
import {PostService} from '../../services/post/post.service';
import {error} from 'protractor';



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
  profile: any;
  logged: boolean;
  constructor(private postLikeService: PostLikeService,
              private profileService: ProfileService,
              ) { }

  ngOnInit() {
    this.profileService.GetUserProfile().subscribe((x: any) => {
      this.profile = x;
      if(x)
        this.logged = true;
    });
  }

  GetItem = (item: any) => {
    this.postItem.emit(item);
  }
  DeleteTopic = (id: any) => {
    this.postItemId.emit(id);
  }
  PostLike(postid: number) {
    let model;
    let profileId;
    profileId = this.profile.id;
    model = {postid, profileId};
    this.postLikeService.PostPostLike(model).subscribe(data => data);
    // return location.reload();
  }
}
