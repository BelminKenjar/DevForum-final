import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-subtopic-form',
  templateUrl: './subtopic-form.component.html',
  styleUrls: ['./subtopic-form.component.css']
})
export class SubtopicFormComponent implements OnInit {

  @Input() public formGroup: any;
  @Input() public f: any;
  @Output() submit = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

}
