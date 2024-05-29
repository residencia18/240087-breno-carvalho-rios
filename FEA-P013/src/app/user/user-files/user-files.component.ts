import { Component } from '@angular/core';
import { UserService } from '../../services/user/user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { getAuth } from '@angular/fire/auth';
import { CommonModule } from '@angular/common';
import { TableModule } from 'primeng/table';
import { AuthService } from '../../services/auth/auth.service';
import { InitialsPipe } from '../../pipes/initials.pipe';

@Component({
  selector: 'app-user-files',
  standalone: true,
  imports: [CommonModule, TableModule, InitialsPipe],
  templateUrl: './user-files.component.html',
  styleUrl: './user-files.component.css'
})
export class UserFilesComponent {
  public user: any = {};
  private _files: any[] = [];

  public files: any[] = [];

  constructor(private userService: UserService, private auth: AuthService, private route: ActivatedRoute, private router: Router) {

  }

  async ngOnInit() {
    let loggedUser = this.auth.getUser();

    if (!loggedUser) {
      this.router.navigate(['/auth/login']);
      return;
    }

    this.user = await this.userService.getByLoginId(loggedUser.uid);
    this._files = await this.userService.getFilesById(this.user.id);
    this.files = this._files;
  }
}
