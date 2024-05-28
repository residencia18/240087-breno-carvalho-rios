import { Component } from '@angular/core';
import { UserService } from '../../services/user/user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { getAuth } from '@angular/fire/auth';
import { CommonModule } from '@angular/common';
import { TableModule } from 'primeng/table';

@Component({
  selector: 'app-user-files',
  standalone: true,
  imports: [CommonModule, TableModule],
  templateUrl: './user-files.component.html',
  styleUrl: './user-files.component.css'
})
export class UserFilesComponent {
  public readonly id = this.route.snapshot.paramMap.get('id');

  public user: any = {};
  private _files: any[] = [];

  public files: any[] = [];

  private auth = getAuth();

  constructor(private userService: UserService, private route: ActivatedRoute, private router: Router) {
    console.log(this.auth.currentUser);
  }

  async ngOnInit() {
    if (!this.id) {
      // this.router.navigate(['/admin/users']);
      return;
    }

    this.user = await this.userService.getById(this.id);
    this._files = await this.userService.getFilesById(this.id);

    this.files = this._files;
  }
}
