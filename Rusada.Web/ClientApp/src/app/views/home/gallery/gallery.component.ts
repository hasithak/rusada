import { Component, OnInit } from '@angular/core';
import { AirplaneSighting } from '../../../models/airplane-sighting';
import { SightingServiceService } from '../../../services/sighting-service.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.css']
})
export class GalleryComponent implements OnInit {
  public sightings: AirplaneSighting[] = [];

  constructor(private sightingService: SightingServiceService) { }

  ngOnInit(): void {
    this.loadSightings();
  }

  private loadSightings() {
    this.sightingService.getList().subscribe(
      result => {
        this.sightings = result;
      },
      error => {
        console.error(error);
      });
  }

  deleteSighting(event: Event): void {
    let id = Number.parseInt((event.target as Element).id);
    this.sightingService.delete(id).subscribe(
      result => {
        this.loadSightings();
      },
      error => {
        console.error(error)
      });
  }

  confirmAndDeleteSighting(event: Event) {
    Swal.fire({
      title: 'Are you sure want to remove?',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, keep it'
    }).then((result) => {
      if (result.value) {
        this.deleteSighting(event);
      } else if (result.dismiss === Swal.DismissReason.cancel) {
      }
    });
  }

  getImage(sight: AirplaneSighting): string {
    return sight.medias && sight.medias[0] ? sight.medias[0] .fileName : 'placeholder.jpg';
  }
}
