import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { AuthService } from '../auth/auth.service';
import { Firestore, addDoc, collection, deleteDoc, doc, getDoc, getDocs, query, updateDoc, where } from '@angular/fire/firestore';
import { getStorage, ref } from '@firebase/storage';
import { deleteObject, uploadBytesResumable } from '@angular/fire/storage';
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
  }

  async getById(id: string) {
    let userDoc = await getDoc(doc(this.firestore, 'users', id));

    return userDoc.data();
  }

  async getByLoginId(id: string) {
    let userDocs = await getDocs(query(this.usersCollection, where('loginId', '==', id)));
    let user = userDocs.docs.map((user) => {
      return { ...user.data(), id: user.id };
    })[0];

    return user;
  }

  async getFilesById(id: string) {
    let trainingsCollection = collection(this.firestore, 'users', id, 'trainings');
    let trainings = (await getDocs(trainingsCollection)).docs.map((training) => {
      return { ...training.data(), id: training.id };
    });

    return trainings;
  }

  public async create(user: any) {
    let response: any = await this.authService.signupUser(user.mail);
    console.log(response);
    if (!response.success == false) {
      return response;
    }

    user.loginId = response.uid;
    await this.authService.sendRecoveryPassword(user.mail);
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

  public async deleteTraining(userId: string, trainingId: string) {
    let filesCollection = collection(this.firestore, 'users', userId, 'trainings');
    let trainingDoc = doc(filesCollection, trainingId);
    return await deleteDoc(trainingDoc);
  }

  public async deleteFileObject(id: string, fileName: string) {
    const filePath = `trainings/${id}/${fileName}`;
    const storageRef = ref(this.storage, filePath);

    return deleteObject(storageRef).then(() => {
      return {
        success: true,
        message: 'Arquivo excluido com sucesso'
      }
    }).catch((error) => {
      return {
        success: false,
        error: error
      }
    });
  }

  public generateFileHash(text: string) {
    return sha256(text);
  }
}
