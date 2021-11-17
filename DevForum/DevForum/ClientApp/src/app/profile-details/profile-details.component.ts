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

  constructor(private modalService: NgbModal, private formBuilder: FormBuilder, private profileService: ProfileService) { }

  ngOnInit() {
  }

  //modal
  @Input() details: any
  openMyModal(content: any, details: any) {
    if (details != null) {
    this.details = details;
    this.detailsForm.patchValue({
      age: details.age,
      city: details.city,
      country: details.country,
      githubUrl: details.githubUrl,
      facebookUrl: details.facebookUrl,
      linkedinUrl: details.linkedinUrl,
      websiteUrl: details.website,
      twitterUrl: details.twitterUrl
    })
    }
    this.modalService.open(content, this.modalOptions).result.then(
      (result) => {
        console.log(result);
        this.closeResult = `Closed with: ${result}`;
      },
      (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      }
    );
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return "by pressing ESC";
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return "by clicking on a backdrop";
    } else {
      return `with: ${reason}`;
    }
  }

  //edit details form
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
    if (this.details == null) {
      console.log("null");
    }
    if (this.details != null) {
      this.profileService.UpdateProfileDetails(this.details.id, updateDetails).subscribe(data => {
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





