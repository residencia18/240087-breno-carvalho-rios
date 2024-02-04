import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { DropdownModule } from 'primeng/dropdown';
import { ButtonModule } from 'primeng/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ObjectsComponent } from './components/objects/objects.component';
import { ClassesComponent } from './components/classes/classes.component';
import { PropertiesComponent } from './components/properties/properties.component';
import { VehicleDisplayComponent } from './components/vehicle-display/vehicle-display.component';
import { CartComponent } from './components/cart/cart.component';
import { BeStrongDirective } from './directives/be-strong/be-strong.directive';
import { UnderlinedDirective } from './directives/underlined/underlined.directive';
import { PropertyValueComponent } from './components/vehicle-display/property-value/property-value.component';

@NgModule({
    declarations: [
        AppComponent,
        ObjectsComponent,
        ClassesComponent,
        PropertiesComponent,
        VehicleDisplayComponent,
        CartComponent,
        PropertyValueComponent,
        BeStrongDirective,
        UnderlinedDirective,
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        DropdownModule,
        ButtonModule,
        BrowserAnimationsModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
