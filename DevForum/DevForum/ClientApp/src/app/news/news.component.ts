import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { NewsService } from '../../services/news/news.service';
import { UserService } from '../../services/user/user.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit {

  news: any;
  isAdmin: boolean = false;
  constructor(private spinnerService: NgxSpinnerService, private newsService: NewsService, private userService: UserService) { }

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
          this.spinnerService.hide();
        }, 400)
      }
    })
  }

}
