import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerService } from 'ngx-spinner';
import { ProfileService } from '../../services/profile/profile.service';
import { TopicService } from '../../services/topic/topic.service';
import { UserService } from '../../services/user/user.service';

@Component({
  selector: 'app-topic',
  templateUrl: './topic.component.html',
  styleUrls: ['./topic.component.css']
})
export class TopicComponent implements OnInit {

  topics: any
  isAdmin: boolean
  closeResult: string;
  logo: any
  modalOptions = {
    size: 'md'
  }

  page: number = 1;
  limit = 4;
  total: number = 0;

  searchObject = {
    Title: ''
  }
  constructor(private topicService: TopicService,
    private spinner: NgxSpinnerService,
    private userService: UserService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    private profileService: ProfileService) { }

  ngOnInit() {
    this.userService.IsAdmin().subscribe(data => {
      if (data)
        this.isAdmin = data;
    });
    this.GetTopics();
  }

  GetTopics = () => {
    this.topicService.GetTopics(this.page, this.limit, this.searchObject).subscribe(data => {
      if (data) {
        this.spinner.show();
        setTimeout(() => {
          this.topics = data['page']['data'];
          this.total = data['page'].total
          this.spinner.hide();
        }, 300)
      }
    })
  }

  topicForm = this.formBuilder.group({
    title: [null, Validators.required],
    description: [null, Validators.required],
    logo: [null]
  })

  @Input() public topic;
  open(content: any, topic: any, isEmpty: boolean) {
    this.topic = topic;
    if (isEmpty) this.topicForm.reset();
    if (topic && !isEmpty) {
      this.logo = topic.logo
      this.topicForm.patchValue({
        title: topic.title,
        description: topic.description,
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
    return this.topicForm.controls;
  }

  submit = (e: Event) => {
    this.onSubmit();
  };

  onSubmit = () => {
    this.profileService.GetUserProfile().subscribe(data => {
      if (data) {
        if (this.topicForm.valid) {
          let topic = {
            Title: this.topicForm.get('title').value,
            Description: this.topicForm.get('description').value,
            Logo: this.logo,
            ProfileId: data.id
          }
          if (this.topic) {
            if (this.topic.id) {
              this.topicService.UpdateTopic(this.topic.id, topic).subscribe(data => data);
            }
          }
          else
            this.topicService.PostTopic(topic).subscribe(data => data);
          window.location.reload();
        }
      }
    });
    console.log("ok");
  }

  GetLogo = (e: Event) => {
    this.logo = e;
  }

  GetTopicItem = (e: Event, content: any) => {
    console.log(e);
    if (e)
      this.open(content, e, false);
  }

  DeleteTopic = (e: Event) => {
    if (confirm("Are you sure you want to delete topic?")) {
      this.topicService.DeleteTopic(e).subscribe(data => data);
      window.location.reload();
    }
  }

  GoToPrevious = () => {
    this.page--;
    this.GetTopics();
  };
  GoToNext = () => {
    this.page++;
    this.GetTopics();
  };

  GoToPage = (n: number) => {
    this.page = n;
    this.GetTopics();
  };

  GetQueryValue = (e: Event) => {
    this.searchObject.Title = e.toString();
    this.GetTopics();
  }
}
