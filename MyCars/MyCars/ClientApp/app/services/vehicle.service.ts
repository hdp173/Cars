import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import { SaveVehicle } from '../models/vehicle';
import { AuthHttp } from 'angular2-jwt/angular2-jwt';

@Injectable()
export class VehicleService {

  constructor(private http: Http, private authHttp: AuthHttp) { }

  getMakes() {
    return this.http.get('/api/makes')
    .map(res => res.json());
  }

  getFeatures() {
    return this.http.get('/api/features')
    .map(res => res.json());
  }

  create(vehicle: any) {
    console.log(this.authHttp);
    return this.authHttp.post('/api/vehicles', vehicle)
    .map(res => res.json());
  }

  getVehicle(id: number) {
    return this.http.get('/api/vehicles/' + id)
    .map(res => res.json());
  }

  getVehicles(filter: any) {
    return this.http.get('/api/vehicles/' + '?' + this.toQueryString(filter))
      .map(res => res.json());
  }

  toQueryString(obj: any) {
    var parts = [];
    for (var property in obj) {
      var value = obj[property];
      if (value != null && value != undefined) 
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
    }

    return parts.join('&');
  }

  update(vehicle: SaveVehicle) {
    return this.authHttp.put('/api/vehicles/' + vehicle.id, vehicle)
    .map(res => res.json());
  }

  delete(id: number) {
    return this.authHttp.delete('/api/vehicles/' + id)
    .map(res => res.json());
  }
}
