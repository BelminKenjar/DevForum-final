import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-topic-item',
  templateUrl: './topic-item.component.html',
  styleUrls: ['./topic-item.component.css']
})
export class TopicItemComponent implements OnInit {

  @Input() topics: any
  constructor() { }

  ngOnInit() {
  }

}
