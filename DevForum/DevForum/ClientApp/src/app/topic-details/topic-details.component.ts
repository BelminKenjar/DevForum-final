import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ProfileService } from '../../services/profile/profile.service';
import { SubtopicService } from '../../services/subtopic/subtopic.service';
import { TopicService } from '../../services/topic/topic.service';
import { UserService } from '../../services/user/user.service';

@Component({
  selector: 'app-topic-details',
  templateUrl: './topic-details.component.html',
  styleUrls: ['./topic-details.component.css']
})
export class TopicDetailsComponent implements OnInit {

  subtopics: any
  topic: any
  isAdmin: boolean
  modalOptions = {
    size: 'lg'
  }
  closeResult: string

  constructor(private route: ActivatedRoute,
    private subtopicService: SubtopicService,
    private topicService: TopicService,
    private userService: UserService,
    private formBuilder: FormBuilder, private modalService: NgbModal,
    private profileService: ProfileService) { }

  ngOnInit() {
    this.userService.IsAdmin().subscribe(data => {
      if (data)
        this.isAdmin = data;
    })
    let id = this.route.snapshot.params['id'];
    this.topicService.GetTopicById(id).subscribe(data => {
      this.topic = data;
    })
    this.GetSubtopics();
  }

  GetSubtopics = () => {
    let id = this.route.snapshot.params['id'];
    this.subtopicService.GetSubtopics(id, 1, 10).subscribe(data => {
      this.subtopics = data['page']['data'];
      console.log(this.subtopics);
    });
  }

  subtopicForm = this.formBuilder.group({
    name: [null, Validators.required],
    description: [null, Validators.required]
  })

  @Input() public subtopicItem;
  open(content: any, subtopicItem: any, isEmpty: boolean) {
    this.subtopicItem = subtopicItem;
    if (isEmpty) this.subtopicForm.reset();
    if (subtopicItem && !isEmpty) {
      this.subtopicForm.patchValue({
        name: subtopicItem.name,
        description: subtopicItem.description
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
    return this.subtopicForm.controls;
  }

  submit = (e: Event) => {
    this.onSubmit();
  };

  onSubmit = () => {
    this.profileService.GetUserProfile().subscribe(data => {
      if (data) {
        if (this.subtopicForm.valid) {
          let subtopic = {
            Name: this.subtopicForm.get('name').value,
            Description: this.subtopicForm.get('description').value,
            ProfileId: data.id,
            TopicId: this.topic.id
          }
          if (this.subtopicItem) { 
            if (this.subtopicItem.id) {
              this.subtopicService.UpdateSubtopic(this.subtopicItem.id, subtopic).subscribe(data => data);
            }
          }
          else
            this.subtopicService.PostSubtopic(subtopic).subscribe(data => data);
          window.location.reload();
        }
      }
    });
  }

  DeleteSubtopic = (e: Event) => {
    if (e) {
      if (confirm("Are you sure you want to delete the subtopic?")) {
        this.subtopicService.DeleteSubtopic(e).subscribe(data => data);
        window.location.reload();
      }
    }
  }

  GetSubtopicItem = (e: Event, content: any) => {
    if (e) {
      this.open(content, e, false);
    }
  }

  //GoToPrevious = () => {
  //  this.page--;
  //  this.GetNews();
  //};
  //GoToNext = () => {
  //  this.page++;
  //  this.GetNews();
  //};

  //GoToPage = (n: number) => {
  //  this.page = n;
  //  this.GetNews();
  //};
}
