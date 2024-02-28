import { Injectable } from '@angular/core';
import { Post } from '../interfaces/post';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BlogService {
  constructor(private http: HttpClient) { }

  public create(post: Post) {
    return this.http.post("https://aula13-frontend-default-rtdb.firebaseio.com/posts.json", post);
  }

  public update(id: string, post: Post) {
    return this.http.put(`https://aula13-frontend-default-rtdb.firebaseio.com/posts/${id}.json`, post);
  }

  public delete(id: string) {
    return this.http.delete(`https://aula13-frontend-default-rtdb.firebaseio.com/posts/${id}.json`);
  }

  public get(id: string) {
    return this.http.get(`https://aula13-frontend-default-rtdb.firebaseio.com/posts/${id}.json`);
  }

  public getAll() {
    return this.http.get("https://aula13-frontend-default-rtdb.firebaseio.com/posts.json");
  }
}
