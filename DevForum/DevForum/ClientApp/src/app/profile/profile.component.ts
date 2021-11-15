import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../../services/profile/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  currentProfile: any;
  constructor(private _profileService: ProfileService ) { }

  ngOnInit() {
    this.GetCurrentProfile();
  }

  GetCurrentProfile = () => {
    this._profileService.GetUserProfile().subscribe(data => {
      console.log(data);
      this.currentProfile = data;
/*      console.log(this.currentProfile);*/
    })
  };

}
