import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile-stats',
  templateUrl: './profile-stats.component.html',
  styleUrls: ['./profile-stats.component.css']
})
export class ProfileStatsComponent implements OnInit {

  @Input() profileStats: any;
  constructor() { }

  ngOnInit() {
  }

}
