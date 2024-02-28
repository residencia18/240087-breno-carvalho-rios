import { Component } from '@angular/core';
import { BlogService } from '../../services/blog.service';
import { NavigationStart, Router } from '@angular/router';
import { Post } from '../../interfaces/post';

@Component({
  selector: 'app-posts-list',
  templateUrl: './posts-list.component.html',
  styleUrl: './posts-list.component.css'
})
export class PostsListComponent {
  constructor(private service: BlogService, private router: Router) { }

  ngOnInit() {
    this.getAll();
  }

  public posts: Post[] = []

  public delete(id: string) {
    this.service.delete(id).subscribe(_ => {
        this.getAll();
    });
  }

  public getAll() {
    this.service.getAll().subscribe(posts => {
      this.posts = Object.entries(posts).map(entry => {
        let post: Post = {
          id: entry[0],
          title: entry[1].title,
          content: entry[1].content,
          dateTime: new Date()
        }
        return post;
      }).reverse();
    });
  }
}
