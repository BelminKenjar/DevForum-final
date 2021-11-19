import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerService } from 'ngx-spinner';
import { NewsService } from '../../services/news/news.service';
import { ProfileService } from '../../services/profile/profile.service';
import { UserService } from '../../services/user/user.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit {

  news: any;
  isAdmin: boolean = false;

  closeResult: string;
  modalOptions: {
    size: 'lg';
  }

  constructor(private spinnerService: NgxSpinnerService, private newsService: NewsService, private userService: UserService,
    private modalService: NgbModal, private formBuilder: FormBuilder, private profileService: ProfileService) { }

  newsForm = this.formBuilder.group({
    title: [null, Validators.required],
    content: [null, Validators.required]
  });

  ngOnInit() {
    this.GetNews();
    this.userService.IsAdmin().subscribe(data => {
      if (data)
        this.isAdmin = data;
    });
  }

  GetNews = () => {
    this.newsService.GetNews().subscribe(data => {
      if (data) {
        this.spinnerService.show();
        setTimeout(() => {
          console.log(data);
          this.news = data;
          console.log(data);
          this.spinnerService.hide();
        }, 400)
      }
    })
  }

  @Input() public newsItem;
  open(content: any, newsItem: any, isEmpty: boolean) {
    this.newsItem = newsItem;
    if (isEmpty) this.newsForm.reset();
    if (newsItem && !isEmpty) {
      this.newsForm.patchValue({
        title: newsItem.title,
        content: newsItem.content
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
    return this.newsForm.controls;
  }

  submit = (e: Event) => {
    this.onSubmit();
  };

  onSubmit = () => {
    this.profileService.GetUserProfile().subscribe(data => {
      if (data) {
        if (this.newsForm.valid) {
          let news = {
            Title: this.newsForm.get('title').value,
            Content: this.newsForm.get('content').value,
            ProfileId: data.id
          }
          console.log(this.newsItem)
          if (this.newsItem) {
            if (this.newsItem.id) {
              this.newsService.UpdateNews(this.newsItem.id, news).subscribe(data => data);
            }
          }
          else
            this.newsService.PostNews(news).subscribe(data => data);
          window.location.reload();
          console.log(news);
        }
      }
    });
  }

  DeleteNews = (e: Event) => {
    if (e) {
      if (confirm("Are you sure you want to delete the news?")) {
        this.newsService.DeleteNews(e).subscribe(data => data);
        window.location.reload();
      }
    }
  }

  GetNewsItem = (e: Event, content: any) => {
    if (e) {
      this.open(content, e, false);
    }
  }
}
