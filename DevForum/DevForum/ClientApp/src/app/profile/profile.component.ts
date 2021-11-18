import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import { ProfileService } from '../../services/profile/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  currentProfile: any;
  isEdit: boolean = false;
  constructor(private _profileService: ProfileService, private spinner: NgxSpinnerService, private _authorizeService: AuthorizeService) { }

  ngOnInit() {
    this.GetCurrentProfile();
  }

  GetCurrentProfile = async () => {
    await this._profileService.GetUserProfile().subscribe(data => {
      if (data) {

        this.spinner.show();
        setTimeout(() => {
          this.currentProfile = data;
          this.spinner.hide();
        }, 600)
      }
    })
  };

  IsEdit = () => {
    if (this.isEdit == true)
      this.isEdit = false;
    else this.isEdit = true;
  }

  FileInputChange = async (e: Event) => {
    const file = e.target['files'][0]
    const byteFile = await this.getAsByteArray(file);
    let bytes = Array.from(byteFile);
    let updateProfile = {
      FirstName: this.currentProfile.firstName,
      LastName: this.currentProfile.lastName,
      Image: bytes
    }
    this._profileService.UpdateProfile(this.currentProfile.id, updateProfile).subscribe(data => {
      if (data)
        window.location.reload();
    })
  }

  async getAsByteArray(file) {
    return new Uint8Array(await this.readFile(file))
  }

  readFile(file): Promise<any> {
    return new Promise((resolve, reject) => {
      // Create file reader
      let reader = new FileReader()

      // Register event listeners
      reader.addEventListener("loadend", e => resolve(reader.result))
      reader.addEventListener("error", reject)

      // Read file
      reader.readAsArrayBuffer(file)
    })
  }

  DeleteAccount = () => {
    if (confirm("Are you sure you want to delete your profile?")) {
      const state = {
        returnUrl: '/'
      }
      this._profileService.DeleteAccount(this.currentProfile.applicationUserId).subscribe(data => console.log(data));
      this._authorizeService.signOut(state);
      console.log("ok");
    }
  }
}
