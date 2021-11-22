import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-subtopic',
  templateUrl: './subtopic.component.html',
  styleUrls: ['./subtopic.component.css']
})
export class SubtopicComponent implements OnInit {

  @Input() subtopics: any
  constructor() { }

  ngOnInit() {
  }

}
