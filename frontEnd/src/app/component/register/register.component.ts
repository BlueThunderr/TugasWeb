import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router'
import { User } from '../../models/UserModel';
import { UserService } from '../services/user/user.service';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;
  user: User;
  error: string;
  errorFromApi: string;

  constructor(
    private formBuilder: FormBuilder, 
    private userService: UserService,
    private router: Router
   ) { }

  ngOnInit() { 
    this.error = '';
    this.errorFromApi = '';

    this.user = {
      userName:'',
      password:'',
      confirmPassword:'',
      email:'',
      firstName:'',
      lastName:'',
      level:'1'
    }

    this.registerForm = this.formBuilder.group({
      userName: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(10)]],
      password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(12)]],
      confirmPassword: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(12)]],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  };

  get f() { return this.registerForm.controls; }

  onSubmit(){
    if(this.registerForm.valid){
      this.userService.postUser(this.user).subscribe((onSuccess: any[])=> {
        console.log(onSuccess);
        this.router.navigate(['/component/login']);
      }, error  => {
        console.log(error);
        this.errorFromApi = error.error;        
      });
    }    
  };

  onConfirmPassword(password, confirmPassword){
    if(password!=confirmPassword){
      this.error= "Password tidak sama!"
    }else{
      this.error = '';
    }
  };

  

}
