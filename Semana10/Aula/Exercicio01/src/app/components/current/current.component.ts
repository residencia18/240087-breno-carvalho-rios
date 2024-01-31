import { Component } from '@angular/core';
import { CounterService } from '../../services/counter.service';

@Component({
  selector: 'app-current',
  templateUrl: './current.component.html',
  styleUrl: './current.component.css'
})
export class CurrentComponent {
  currentNumber: number = 1;

  constructor(private counterService: CounterService) { }

  ngOnInit() {
    this.countNumbers();
  }

  countNumbers() {
    this.counterService.getNumbers().subscribe((number) => {
      this.currentNumber = number;
    });
  }
}
