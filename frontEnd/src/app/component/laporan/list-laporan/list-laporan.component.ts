import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../services/authentication/authentication.service';
import { Router } from '@angular/router';
import { LaporanHeader } from '../../models/LaporanHeader';
import { LaporanService } from '../../services/laporan/laporan.service';
import { User } from 'src/app/models/UserModel';
import { LevelUser } from '../../models/Types/LevelUser';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-list-laporan',
  templateUrl: './list-laporan.component.html'
})
export class ListLaporanComponent implements OnInit {
  laporanHeaders: LaporanHeader[];
  user: User;
  isNotAdmin: boolean = false;
  userLevel: LevelUser = new LevelUser;

  constructor(
    private router: Router,
    private authService: AuthenticationService,
    private laporanService: LaporanService,
    private modalService: NgbModal
  ) { 
    if (!this.authService.currentUserValue) { 
      this.router.navigate(['component/login']);
    } else 
    {
      if (this.authService.currentUserValue.level == this.userLevel.administrator) {
        this.isNotAdmin = true;
      }
    }
  }

  ngOnInit() {
    this.laporanService.getLaporans().subscribe((onSuccess: any[])=> {
      console.log(onSuccess);
      this.laporanHeaders = onSuccess;      
    });;

    this.user = this.authService.currentUserValue;
  }

  onTambahLaporan(){
    this.router.navigate(['component/laporan_baru']);
  }

  changeStatus(content){
    this.modalService.open(content, { centered: true });
  }

  changeStatusProcessing(laporanHeaderId, statusLaporan, index){
    this.laporanService.changeStatusLaporan(laporanHeaderId, statusLaporan).subscribe((onSuccess: LaporanHeader)=> {
      console.log(onSuccess);
      
      this.laporanHeaders[index] = onSuccess;      
    });;
  }

}
