import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { UserService } from '../../services/user/user.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-user-files',
  standalone: true,
  imports: [CommonModule, ButtonModule, TableModule],
  templateUrl: './user-files.component.html',
  styleUrl: './user-files.component.css'
})
export class UserFilesComponent {
  public readonly id = this.route.snapshot.paramMap.get('id');

  public user: any = {};
  private _files: any[] = [];

  public files: any[] = [];


  constructor(private userService: UserService, private route: ActivatedRoute, private router: Router) { }

  async ngOnInit() {
    if (!this.id) {
      this.router.navigate(['/admin/users']);
      return;
    }

    this.user = await this.userService.getById(this.id);
    this._files = await this.userService.getFilesById(this.id);

    this.files = this._files;
  }
}
