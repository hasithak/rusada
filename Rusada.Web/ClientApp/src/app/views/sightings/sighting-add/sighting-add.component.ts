import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AsyncValidatorFn, ValidatorFn, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AirplaneSighting } from '../../../models/airplane-sighting';
import { SightingServiceService } from '../../../services/sighting-service.service'

@Component({
  selector: 'app-sighting-add',
  templateUrl: './sighting-add.component.html',
  styleUrls: ['./sighting-add.component.css']
})
export class SightingAddComponent implements OnInit {
  images: string[] = [];
  now = new Date();
  formSubmit = false;

  sightingForm = new FormGroup({
    make: new FormControl('', [Validators.required, Validators.maxLength(128)]),
    model: new FormControl('', [Validators.required, Validators.maxLength(128)]),
    registration: new FormControl('', [Validators.required]),
    location: new FormControl(),
    dateandTime: new FormControl(this.datePipe.transform(this.now, 'yyyy-MM-dd HH:mm'), [Validators.required, this.isValidDate()]),
    file: new FormControl('', [Validators.required]),
    fileSource: new FormControl('', [Validators.required])
  })

  constructor(private aircraftSightingService: SightingServiceService,
    private router: Router,
    private datePipe: DatePipe) { }

  ngOnInit(): void {
  }

  isValidDate(): ValidatorFn {
    let now = new Date();
    return (control: AbstractControl): { [key: string]: any } | null => {
      const invalid = control.value > now;
      return invalid ? { 'invalidEntry': { value: control.value } } : null;
    }
  }

  onSubmit(event: Event): void {
    this.formSubmit = true;

    var form = document.getElementById('sightingAddForm') as HTMLFormElement;

    form.classList.add('was-validated');

    if (form.checkValidity() === false) {
      event.preventDefault();
      event.stopPropagation();

      return;
    }

    let sighting: AirplaneSighting = {
      id: 0,
      make: this.formValue.make.value,
      model: this.formValue.model.value,
      registration: this.formValue.registration.value,
      location: this.formValue.location.value,
      dateandTime: new Date(),
      mediaContent: this.images,
      medias: null
    };

    this.aircraftSightingService.add(sighting).subscribe(
      result => {
        this.router.navigate(['/']);
      },
      error => {
        console.error(error);
      });
  }

  get formValue() {
    return this.sightingForm.controls;
  }

  onFileChange(event: any) {
    if (event.target.files && event.target.files[0]) {
      var filesAmount = event.target.files.length;
      for (let i = 0; i < filesAmount; i++) {
        var reader = new FileReader();
        reader.onload = (event: any) => {
          // Push Base64 string
          this.images.push(event.target.result);
          this.patchValues();
        }
        reader.readAsDataURL(event.target.files[i]);
      }
    }
  }

  patchValues() {
    this.sightingForm.patchValue({
      //this.formValue.fileSource: this.images
    });
  }

  removeImage(url: any) {
    console.log(this.images, url);
    this.images = this.images.filter(img => (img != url));
    this.patchValues();
  }
}
