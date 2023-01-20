import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-post-reply-form',
  templateUrl: './post-reply-form.component.html',
  styleUrls: ['./post-reply-form.component.css']
})
export class PostReplyFormComponent implements OnInit {

  @Input() public formGroup: any;
  @Input() public f: any;
  @Output() submit = new EventEmitter();
  constructor() { }

  ngOnInit() {
  }

}
