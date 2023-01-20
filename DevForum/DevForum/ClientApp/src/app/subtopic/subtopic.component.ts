import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { UserService } from '../../services/user/user.service';

@Component({
  selector: 'app-subtopic',
  templateUrl: './subtopic.component.html',
  styleUrls: ['./subtopic.component.css']
})
export class SubtopicComponent implements OnInit {

  @Input() subtopics: any;
  isAdmin: boolean;
  @Output() subtopicItem = new EventEmitter<any>();
  @Output() subtopicItemId = new EventEmitter<any>();

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.IsAdmin().subscribe(data => {
      if (data)
        this.isAdmin = data;
    })
  }

  GetTopicItem = (e: Event) => {
    this.subtopicItem.emit(e);
  }
  DeleteTopic = (e: Event) => {
    this.subtopicItemId.emit(e);
  }
}
