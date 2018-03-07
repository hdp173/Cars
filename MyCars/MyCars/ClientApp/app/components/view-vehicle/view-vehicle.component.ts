import { PhotoService } from './../../services/photo.service';
import { Component, OnInit, ElementRef, ViewChild, NgZone } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastyService } from 'ng2-toasty';
import { VehicleService } from '../../services/vehicle.service';
import { ProgressService, BrowserXhrWithProgress } from '../../services/progress.service';
import { BrowserXhr } from '@angular/http';

@Component({
  selector: 'view-vehicle',
  templateUrl: './view-vehicle.component.html' ,
  providers:  [
    { provide: BrowserXhr, useClass: BrowserXhrWithProgress },
    ProgressService
  ]
})
export class ViewVehicleComponent implements OnInit {
  @ViewChild('fileInput') fileInput: ElementRef;
  vehicle: any;
  vehicleId: number; 
  photos: any;
  progress: any;

  constructor(
    private zone: NgZone,
    private route: ActivatedRoute, 
    private router: Router,
    private toasty: ToastyService,
    private progressService: ProgressService,
    private photoService: PhotoService,
    private vehicleService: VehicleService) { 

    route.params.subscribe(p => {
      this.vehicleId = +p['id'];
      if (isNaN(this.vehicleId) || this.vehicleId <= 0) {
        router.navigate(['/vehicles']);
        return; 
      }
    });
  }

  ngOnInit() { 
    this.photoService.getPhotos(this.vehicleId)
    .subscribe(photos => this.photos = photos);

    this.vehicleService.getVehicle(this.vehicleId)
      .subscribe(
        v => this.vehicle = v,
        err => {
          if (err.status == 404) {
            this.router.navigate(['/vehicles']);
            return; 
          }
        });
  }

  delete() {
    if (confirm("Are you sure?")) {
      this.vehicleService.delete(this.vehicle.id)
        .subscribe(x => {
          this.router.navigate(['/vehicles']);
        },
        undefined,
        () => {this.progress = null}
      );
    }
  }

  uploadPhoto() {    
      this.progressService.startTracking()
      .subscribe(progress => {
        console.log(progress)
        this.zone.run(() => {
        this.progress = progress;
      });
    },
    undefined,
    () => { this.progress = null; });      
      
      var nativeElement: any = this.fileInput.nativeElement;
      var file = nativeElement.files[0];
       
      this.photoService.upload(this.vehicleId, file)
        .subscribe(photo => {
          this.photos.push(photo)
          nativeElement.value = '';
        },
          err => {
            this.toasty.error({
              title: 'Error',
              msg: err.text(),
              theme: 'bootstrap',
              showClose: true,
              timeout: 5000
            });
        });
  }
}
