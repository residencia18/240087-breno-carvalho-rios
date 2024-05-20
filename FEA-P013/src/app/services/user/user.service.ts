import { Injectable } from '@angular/core';
import { firstValueFrom, map } from 'rxjs';
import { AuthService } from '../auth/auth.service';
import { Firestore, addDoc, collection, getDocs, getFirestore, query } from '@angular/fire/firestore';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private usersCollection = collection(this.firestore, 'users');

  constructor(private firestore: Firestore, private authService: AuthService) { }

  async getAll() {
    return (await getDocs(query(this.usersCollection))).docs.map((users) => users.data());
  }

  public async create(user: any) {
    let users = collection(this.firestore, 'users');
    let newUser = await firstValueFrom(this.authService.signupUser(user.mail));
    user.id = newUser.localId;
    return await addDoc(users, user);
  }
}
