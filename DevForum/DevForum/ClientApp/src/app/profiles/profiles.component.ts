import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ProfileService } from '../../services/profile/profile.service';

@Component({
  selector: 'app-profiles',
  templateUrl: './profiles.component.html',
  styleUrls: ['./profiles.component.css']
})
export class ProfilesComponent implements OnInit {

  profiles: any
  page: number = 1;
  limit = 6;
  total: number = 0;

  constructor(private _profileService: ProfileService, private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.GetProfiles();
  }

  GetProfiles = () => {
    this._profileService.GetAllProfiles(this.page, this.limit).subscribe(data => {
      if (data) {
        this.spinner.show();
        setTimeout(() => {
          this.profiles = data['page']['data'];
          this.total = data['page'].total;
          this.spinner.hide();
        }, 300)
      }
    });
  }

  GoToPrevious = () => {
    this.page--;
    this.GetProfiles();
  };
  GoToNext = () => {
    this.page++;
    this.GetProfiles();
  };

  GoToPage = (n: number) => {
    this.page = n;
    this.GetProfiles();
  };
}
