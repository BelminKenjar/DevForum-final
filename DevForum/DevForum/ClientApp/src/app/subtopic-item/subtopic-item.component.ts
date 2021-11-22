import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-subtopic-item',
  templateUrl: './subtopic-item.component.html',
  styleUrls: ['./subtopic-item.component.css']
})
export class SubtopicItemComponent implements OnInit {

  @Input() subtopics: any
  constructor() { }

  ngOnInit() {
  }

}
