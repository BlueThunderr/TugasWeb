import { Component, OnInit } from '@angular/core';
import { User } from '../models/user';
import { Router } from '@angular/router';
import { UserService } from '../services/user/user.service';
import { AuthenticationService } from '../services/authentication/authentication.service';
import { Subscription } from 'rxjs';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  currentUser: User;
  user: User;
  currentUserSubscription: Subscription;
  error: string;

  constructor(
    private userService: UserService,
    private router: Router,
    private authService: AuthenticationService
    ) {
      if (this.authService.currentUserValue) { 
        this.router.navigate(['component/list_laporan']);    
      }
    }

  ngOnInit() {

    this.error = '';

    this.user = new User;
  }

  onLogin(){
    this.authService.login(this.user.userName, this.user.password).subscribe((onSuccess: any[])=> {
      // console.log(onSuccess);
      console.log("login");
      this.router.navigate(['component/list_laporan']);
    }, error  => {
      console.log(error);
      this.error = "Username atau password salah!";   
      console.log(this.error);     
    });
  }

}
