import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User } from '../../../models/User';
import { createUserWithEmailAndPassword, getAuth, onAuthStateChanged, sendPasswordResetEmail, signInWithEmailAndPassword } from '@angular/fire/auth';
import { FirebaseApp } from '@angular/fire/app';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly auth = getAuth(this.app);

  usuario = new BehaviorSubject<User>(new User('', '', '', new Date()));

  constructor(private http: HttpClient, private app: FirebaseApp) {
    onAuthStateChanged(this.auth, (user) => {
      if (user) {
        this.auth.updateCurrentUser(user);
      }
    });
  }

  async loginUser(email: string, password: string) {
    return signInWithEmailAndPassword(this.auth, email, password).then((userCredential) => {
      return { success: true }
    }).catch((error) => {
      return {
        success: false,
        error: error
      }
    });
  }

  async signupUser(email: string) {
    let password = this.generateRandomPassword();
    return createUserWithEmailAndPassword(this.auth, email, password).then((userCredential) => {
      console.log('Usuário criado com sucesso');
      return userCredential.user;
    }).catch((error) => {
      return {
        success: false,
        error: error
      }
    });
  }

  getUser() {
    return this.auth.currentUser;
  }

  async sendRecoveryPassword(email: string) {
    return await sendPasswordResetEmail(this.auth, email);
  }

  logout() {
    this.auth.signOut();
  }

  generateRandomPassword() {
    return Math.random().toString(36).slice(-8);
  }
}
