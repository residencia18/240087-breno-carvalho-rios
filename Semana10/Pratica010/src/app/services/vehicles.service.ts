import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VehiclesService {
  private vehiclesListSubject = new Subject<any[]>();
  private selectedCategorySubject = new Subject<any[]>();
  private selectedVehicleSubject = new Subject<any>();
  private selectedPropertySubject = new Subject<string>();
  private cartItemsSubject = new Subject<any[]>();

  private vehiclesList: any[] = [];
  private filteredVehicles: any[] = [];
  private vehicle: any = {};

  vehiclesList$ = this.vehiclesListSubject.asObservable();
  selectedCategory$ = this.selectedCategorySubject.asObservable();
  selectedVehicle$ = this.selectedVehicleSubject.asObservable();
  selectedProperty$ = this.selectedPropertySubject.asObservable();
  cartItems$ = this.cartItemsSubject.asObservable();

  constructor(private http: HttpClient) {
    this.http.get('../assets/data/vehicles.json').subscribe(res => {
      this.vehiclesList = res as any[];
      this.vehiclesListSubject.next(this.vehiclesList);
    });
  }

  selectCategory(category: string) {
    this.filteredVehicles = this.vehiclesList[category as keyof typeof this.vehiclesList] as typeof this.vehiclesList;

    this.selectedCategorySubject.next(this.filteredVehicles);
  }

  selectVehicle(vehicle: any) {
    this.vehicle = vehicle;

    const _properties = Object.keys(this.vehicle).map(key => {
      return { "label": key, "value": this.vehicle[key] }
    });

    this.selectedVehicleSubject.next(_properties);
  }

  selectProperty(property: string) {
    this.selectedPropertySubject.next(property);
  }

  addToCart() {
    this.cartItemsSubject.next(this.vehicle);
  }
}
