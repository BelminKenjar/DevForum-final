import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ProfileService } from '../../services/profile/profile.service';
import { SubtopicService } from '../../services/subtopic/subtopic.service';
import { PostService } from '../../services/post/post.service';
import { UserService } from '../../services/user/user.service';
import {any} from 'codelyzer/util/function';
import {getLocaleDateFormat} from '@angular/common';


@Component({
  selector: 'app-subtopic-details',
  templateUrl: './subtopic-details.component.html',
  styleUrls: ['./subtopic-details.component.css']
})
export class SubtopicDetailsComponent implements OnInit {

  posts: any;
  subtopic: any;
  isAdmin: boolean;
  profile: any;
  modalOptions = {
    size: 'lg'
  };
  closeResult: string;

  page = 1;
  limit = 5;
  total = 0;

  searchObject = {
    Name: ''
  };
  constructor(private route: ActivatedRoute,
              private postService: PostService,
              private subtopicService: SubtopicService,
              private userService: UserService,
              private formBuilder: FormBuilder, private modalService: NgbModal,
              private profileService: ProfileService) { }

  ngOnInit() {
    this.userService.IsAdmin().subscribe(data => {
      if (data)
        this.isAdmin = data;
    });
    this.profileService.GetUserProfile().subscribe(data => { this.profile = data; });
    let id = this.route.snapshot.params['id'];
    this.subtopicService.GetSubtopicById(id).subscribe(data => {
      this.subtopic = data;
    })
    this.GetPosts();
  }

  GetPosts = () => {
    let id = this.route.snapshot.params['id'];
    this.postService.GetPosts(id, this.page, this.limit, this.searchObject).subscribe(data => {
      this.posts = data['page']['data'];
      this.total = data['page'].total;
    });
  }

  postForm = this.formBuilder.group({
    Title: [null, Validators.required],
    Content: [null, Validators.required],
    // CreatedAt: [null, Validators.required],
    // EditedAt: [null, Validators.required],
    // LikeCount: [null, Validators.required],
    // ReplyCount: [null, Validators.required]
  });

  @Input() public postItem;
  open(content: any, postItem: any, isEmpty: boolean) {
    this.postItem = postItem;

    if (isEmpty) this.postForm.reset();
    if (postItem && !isEmpty) {
      this.postForm.patchValue({
        Title: postItem.Title,
        Content: postItem.Content

      });
    }
    this.modalService.open(content, this.modalOptions).result.then(
      (result) => {
        console.log(result);
        this.closeResult = `Closed with: ${result}`;
      },
      (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      }
    );
  }
  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return "by pressing ESC";
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return "by clicking on a backdrop";
    } else {
      return `with: ${reason}`;
    }
  }

  get f() {
    return this.postForm.controls;
  }

  submit = (e: Event) => {
    this.onSubmit();
  };

  onSubmit = () => {
    this.profileService.GetUserProfile().subscribe(data => {
      if (data) {
        if (this.postForm.valid) {
          let post = {
            Title: this.postForm.get('Title').value,
            Content: this.postForm.get('Content').value,
            ProfileId: data.id,
            SubTopicId: this.subtopic.id,



          }
          if (this.postItem) {
            if (this.postItem.id) {

              this.postService.UpdatePost(this.postItem.id, post).subscribe(data => data);
            }
          }
          else
            this.postService.PostPosts(post).subscribe(data => data);
          window.location.reload();
        }
      }
    });
  }

  DeletePost = (e: Event) => {
    if (e) {
      if (confirm("Are you sure you want to delete the post?")) {
        this.postService.DeletePost(e).subscribe(data => data);
        window.location.reload();
      }
    }
  }


  GetPostItem = (e: Event, content: any) => {
    if (e) {
      this.open(content, e, false);
    }
  }

  GoToPrevious = () => {
    this.page--;
    this.GetPosts();
  };
  GoToNext = () => {
    this.page++;
    this.GetPosts();
  };

  GoToPage = (n: number) => {
    this.page = n;
    this.GetPosts();
  };

  GetQueryValue = (e: Event) => {
    this.searchObject.Name = e.toString();
    this.GetPosts();
  }
}
