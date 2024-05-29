import { Component } from '@angular/core';
import { UserService } from '../../services/user/user.service';
import { AuthService } from '../../services/auth/auth.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { InitialsPipe } from '../../pipes/initials.pipe';

@Component({
  selector: 'app-user-profile',
  standalone: true,
  imports: [CommonModule, InitialsPipe],
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.css'
})
export class UserProfileComponent {
  public user: any = {};
  constructor(private userService: UserService, private auth: AuthService, private router: Router) {

  }

  async ngOnInit() {
    let loggedUser = this.auth.getUser();

    if (!loggedUser) {
      this.router.navigate(['/auth/login']);
      return;
    }

    this.user = await this.userService.getByLoginId(loggedUser.uid);
  }
}
