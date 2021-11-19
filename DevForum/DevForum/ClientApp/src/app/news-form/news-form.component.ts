import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-news-form',
  templateUrl: './news-form.component.html',
  styleUrls: ['./news-form.component.css']
})
export class NewsFormComponent implements OnInit {

  @Input() public formGroup: any;
  @Input() public f: any;
  @Output() submit = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

}
