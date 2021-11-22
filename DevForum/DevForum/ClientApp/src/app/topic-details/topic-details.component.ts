import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SubtopicService } from '../../services/subtopic/subtopic.service';
import { TopicService } from '../../services/topic/topic.service';

@Component({
  selector: 'app-topic-details',
  templateUrl: './topic-details.component.html',
  styleUrls: ['./topic-details.component.css']
})
export class TopicDetailsComponent implements OnInit {

  subtopics: any
  topic: any
  constructor(private route: ActivatedRoute, private subtopicService: SubtopicService, private topicService: TopicService) { }

  ngOnInit() {
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
}
