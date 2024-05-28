import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { AuthService } from '../auth/auth.service';
import { Firestore, addDoc, collection, deleteDoc, doc, getDoc, getDocs, query, updateDoc } from '@angular/fire/firestore';
import { getStorage, ref } from '@firebase/storage';
import { uploadBytesResumable } from '@angular/fire/storage';
import { sha256 } from 'js-sha256';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private usersCollection = collection(this.firestore, 'users');

  private readonly storage = getStorage();

  constructor(private firestore: Firestore, private authService: AuthService) { }

  async getAll() {
    let users = (await getDocs(query(this.usersCollection))).docs.map(async (user) => {
      let trainings = collection(this.firestore, 'users', user.id, 'trainings');
      let trainingsDocs = (await getDocs(trainings)).docs;
      return { ...user.data(), id: user.id, trainings: trainingsDocs.map(doc => doc.data()) };
    });

    return Promise.all(users);
    // let users = (await getDocs(query(this.usersCollection))).docs.map((user) => {
    //   return { ...user.data(), id: user.id };
    // });

    // users.forEach((user: any) => {
    //   let trainings = collection(this.firestore, 'users', user.id, 'trainings');
    //   getDocs(trainings).then((querySnapshot) => {
    //     user.trainings = querySnapshot.docs.map((doc) => doc.data());
    //   });
    // });

    // return users;
  }

  async getById(id: string) {
    let userDoc = await getDoc(doc(this.firestore, 'users', id));

    return userDoc.data();
  }

  async getFilesById(id: string) {
    let trainingsCollection = collection(this.firestore, 'users', id, 'trainings');
    let trainings = (await getDocs(trainingsCollection)).docs.map((training) => {
      return { ...training.data(), id: training.id };
    });

    return trainings;
  }

  public async create(user: any) {
    let newUser;
    try {
      newUser = await firstValueFrom(this.authService.signupUser(user.mail));
    } catch (e) {
      return {
        success: false,
        error: e
      };
    }
    user.loginId = newUser.localId;
    this.authService.sendRecoveryPassword(user.mail).subscribe(
      () => {
        console.log('Email para redefinição de senha enviado');
      },
    );
    return await addDoc(this.usersCollection, user);
  }

  public async update(id: string, user: any) {
    let userDoc = doc(this.usersCollection, id);
    return await updateDoc(userDoc, user);
  }

  public async delete(id: string) {
    let userDoc = doc(this.usersCollection, id);
    return await deleteDoc(userDoc);
  }

  public async createTraining(userId: string, file: any) {
    let filesCollection = collection(this.firestore, 'users', userId, 'trainings');

    await addDoc(filesCollection, file);
  }

  public uploadFile(id: string, file: any) {
    const hashedName = this.generateFileHash(`${file.name}_${new Date().getTime()}_${id}`);
    const filePath = `trainings/${id}/${hashedName}`;
    const storageRef = ref(this.storage, filePath);

    return uploadBytesResumable(storageRef, file);
  }

  public generateFileHash(text: string) {
    return sha256(text);
  }
}
