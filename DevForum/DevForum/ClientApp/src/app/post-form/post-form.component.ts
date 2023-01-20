import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-post-form',
  templateUrl: './post-form.component.html',
  styleUrls: ['./post-form.component.css']
})
export class PostFormComponent implements OnInit {

  @Input() public formGroup: any;
  @Input() public f: any;
  @Output() submit = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

}
