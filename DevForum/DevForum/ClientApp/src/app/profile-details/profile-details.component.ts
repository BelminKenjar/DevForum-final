import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NgbModal, NgbModalOptions, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { ProfileService } from '../../services/profile/profile.service';

@Component({
  selector: 'app-profile-details',
  templateUrl: './profile-details.component.html',
  styleUrls: ['./profile-details.component.css']
})
export class ProfileDetailsComponent implements OnInit {

  @Input() profileDetails: any
  @Input() profileId: any
  modalOptions: NgbModalOptions = {
    size: "md",
  };
  closeResult: string;

  detailsForm = this.formBuilder.group({
    age: [''],
    city: [''],
    country: [''],
    githubUrl: [''],
    twitterUrl: [''],
    facebookUrl: [''],
    websiteUrl: [''],
    linkedinUrl: ['']
  })

  constructor(private modalService: NgbModal, private formBuilder: FormBuilder, private profileService: ProfileService) { }

  ngOnInit() {
    if (this.profileDetails != null) {
      //this.details = details;
      this.detailsForm.patchValue({
        age: this.profileDetails.age,
        city: this.profileDetails.city,
        country: this.profileDetails.country,
        githubUrl: this.profileDetails.githubUrl,
        facebookUrl: this.profileDetails.facebookUrl,
        linkedinUrl: this.profileDetails.linkedinUrl,
        websiteUrl: this.profileDetails.website,
        twitterUrl: this.profileDetails.twitterUrl
      })
    }
  }

  onSubmit = () => {
    let updateDetails = {
      Age: parseInt(this.detailsForm.get('age').value),
      City: this.detailsForm.get('city').value,
      Country: this.detailsForm.get('country').value,
      GithubUrl: this.detailsForm.get('githubUrl').value,
      TwitterUrl: this.detailsForm.get('twitterUrl').value,
      FacebookUrl: this.detailsForm.get('facebookUrl').value,
      Website: this.detailsForm.get('websiteUrl').value,
      LinkedinUrl: this.detailsForm.get('linkedinUrl').value,
      ProfileId: this.profileId
    }
    if (this.profileDetails != null) {
      this.profileService.UpdateProfileDetails(this.profileDetails.id, updateDetails).subscribe(data => {
        if (data)
          window.location.reload();
      })
    }
    else {
      updateDetails.Age = 0;
      this.profileService.InsertProfileDetails(updateDetails).subscribe(data => {
        if (data)
          window.location.reload();
      })
    }
  }
}
