import { CanActivateFn } from '@angular/router';

export const guardaGuard: CanActivateFn = (route, state) => {
  const number = Math.random() * (100 - 1) + 1;

  if(number < 50){
    console.log(`${Math.floor(number)} - Você não foi escolhido`);
  }
  
  return (number >= 50);
};
