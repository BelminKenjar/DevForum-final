import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import { NewsService } from '../../services/news/news.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit {

  news: any;
  constructor(private spinnerService: NgxSpinnerService, private newsService: NewsService, private authorizeService: AuthorizeService) { }

  ngOnInit() {
    this.GetNews();
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
