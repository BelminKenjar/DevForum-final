import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { TopicService } from '../../services/topic/topic.service';

@Component({
  selector: 'app-topic',
  templateUrl: './topic.component.html',
  styleUrls: ['./topic.component.css']
})
export class TopicComponent implements OnInit {

  topics: any
  constructor(private topicService: TopicService, private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.GetTopics();
  }

  GetTopics = () => {
    this.topicService.GetTopics().subscribe(data => {
      if (data) {
        this.spinner.show();
        setTimeout(() => {
          this.topics = data
          this.spinner.hide();
        }, 400)
      }
    })
  }
}
