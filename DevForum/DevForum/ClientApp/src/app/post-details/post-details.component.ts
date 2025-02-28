import {Component, Input, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {PostService} from '../../services/post/post.service';
import {SubtopicService} from '../../services/subtopic/subtopic.service';
import {UserService} from '../../services/user/user.service';
import {FormBuilder, Validators} from '@angular/forms';
import {ModalDismissReasons, NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {ProfileService} from '../../services/profile/profile.service';
import {PostReplyService} from '../../services/postReply/post-reply.service';
import {Message} from '@angular/compiler/src/i18n/i18n_ast';

@Component({
  selector: 'app-post-details',
  templateUrl: './post-details.component.html',
  styleUrls: ['./post-details.component.css']
})
export class PostDetailsComponent implements OnInit {

  postReplies: any;
  post: any;
  isAdmin: boolean;
  isUser: any;
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
             private postReplyService: PostReplyService,
             private userService: UserService,
             private formBuilder: FormBuilder, private modalService: NgbModal,
             private profileService: ProfileService) { }

  ngOnInit() {
    this.userService.IsAdmin().subscribe(data => {
      if (data)
        this.isAdmin = data;
    });
    this.profileService.GetUserProfile().subscribe(data => {
      if (data)
        this.isUser = data;
    });
    let id = this.route.snapshot.params['id'];
    this.postService.GetPostById(id).subscribe(data => {
      this.post = data;
    });
    this.GetPostReply();

  }

  GetPostReply = () => {
    let id = this.route.snapshot.params['id'];
    this.postReplyService.GetPostReply(id, this.page, this.limit, this.searchObject).subscribe(data => {
      this.postReplies = data['page']['data'];
      this.total = data['page'].total;
    });
  }
  postReplyForm = this.formBuilder.group({
    Content: [null, Validators.required],
    // CreatedAt: [null, Validators.required],
    // EditedAt: [null, Validators.required],
    // LikeCount: [null, Validators.required],
    // ReplyCount: [null, Validators.required]
  });

  @Input() public postReplyItem;
  open(content: any, postReplyItem: any, isEmpty: boolean) {
    this.postReplyItem = postReplyItem;

    if (isEmpty) this.postReplyForm.reset();
    if (postReplyItem && !isEmpty) {
      this.postReplyForm.patchValue({
        Content: postReplyItem.Content
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
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
  get f() {
    return this.postReplyForm.controls;
  }
  submit = (e: Event) => {
    this.onSubmit();
  }
  onSubmit = () => {
    this.profileService.GetUserProfile().subscribe(data => {
      if (data) {
        if (this.postReplyForm.valid) {
          let postReply = {
            Content: this.postReplyForm.get('Content').value,
            ProfileId: data.id,
            PostId: this.post.id,
          };
          if (this.postReplyItem) {
            if (this.postReplyItem.id) {

              this.postReplyService.UpdatePostReply(this.postReplyItem.id, postReply).subscribe(data => data);
            }
          }
          else
            this.postReplyService.PostPostReply(postReply).subscribe(data => data);
          window.location.reload();
        }
      }
    });
  }
  DeletePostReply = (e: Event) => {
    if (e) {
      if (confirm('Are you sure you want to delete the post?')) {
        this.postReplyService.DeletePostReply(e).subscribe(data => data);
        window.location.reload();
      }
    }
  }

  GetPostReplyItem = (e: Event, content: any) => {
    if (e) {
      this.open(content, e, false);
    }
  }
  GoToPrevious = () => {
    this.page--;
    this.GetPostReply();
  }
  GoToNext = () => {
    this.page++;
    this.GetPostReply();
  }
  GoToPage = (n: number) => {
    this.page = n;
    this.GetPostReply();
  }
  GetQueryValue = (e: Event) => {
    this.searchObject.Name = e.toString();
    this.GetPostReply();
  }
}
