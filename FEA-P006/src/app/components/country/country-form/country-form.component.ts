import { Component } from '@angular/core';
import { CountryService } from '../../../services/country/country.service';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-country-form',
  templateUrl: './country-form.component.html',
  styleUrl: './country-form.component.css'
})
export class CountryFormComponent {
  public formJson: any = undefined;
  public form;

  constructor(private service: CountryService, private formBuilder: FormBuilder) {
    this.form = formBuilder.group({});
  }

  ngOnInit() {
    this.getCountry();
  }

  getCountry(){
    this.service.getCountry().subscribe((country) => {
      const _country = Object.values(country)[0];
      this.formJson = this.service.countryToJson(_country);
      
      this.formJson.forEach((field: any) => {
        this.form.addControl(field.nome, this.formBuilder.control(''))
      });
    })
  }

  public onSubmit(){
    console.log(this.form.value);
  }
}
