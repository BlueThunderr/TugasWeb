import { Component, AfterViewInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import {
  NgbModal,
  ModalDismissReasons,
  NgbPanelChangeEvent,
  NgbCarouselConfig
} from '@ng-bootstrap/ng-bootstrap';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from 'src/app/component/models/user';
import { AuthenticationService } from 'src/app/component/services/authentication/authentication.service';
declare var $: any;

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html'
})
export class NavigationComponent implements AfterViewInit {
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  public showSearch = false;

  constructor(
    private modalService: NgbModal,
    private router: Router,
    private authService: AuthenticationService,
    private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
}

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  onLogout(){
    this.authService.logout();
  }

  ngAfterViewInit() {}

  
}
