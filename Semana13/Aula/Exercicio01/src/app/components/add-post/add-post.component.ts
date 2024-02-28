import { Component } from '@angular/core';
import { BlogService } from '../../services/blog.service';
import { FormControl, FormGroup } from '@angular/forms';
import { Post } from '../../interfaces/post';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrl: './add-post.component.css'
})
export class AddPostComponent {
  constructor(private service: BlogService, private router: Router){}

  addPostForm: FormGroup = new FormGroup({
    title: new FormControl(null),
    content: new FormControl(null)
  });

  public post(){
    let post: Post = {
      title: this.addPostForm.get("title")?.value,
      content: this.addPostForm.get("content")?.value,
      dateTime: new Date()
    }

    this.service.create(post).subscribe(_ => {
      this.router.navigate(['/']);
    });
  }
}
