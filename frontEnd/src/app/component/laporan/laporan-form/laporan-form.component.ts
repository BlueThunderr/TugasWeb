import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { LaporanHeader } from '../../../models/LaporanHeaderModel';
import { LaporanService } from '../../services/laporan/laporan.service';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../services/authentication/authentication.service';
import { StatusLaporan } from '../../models/Types/StatusLaporan';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-laporan-form',
  templateUrl: './laporan-form.component.html'
})
export class LaporanFormComponent implements OnInit {
  laporanForm: FormGroup;
  laporan: LaporanHeader;
  statusLaporan: StatusLaporan;

  constructor(
    private formBuilder: FormBuilder, 
    private laporanService: LaporanService,
    private router: Router,
    private authService: AuthenticationService
  ) { 
    if (!this.authService.currentUserValue) { 
      this.router.navigate(['component/login']);    
    }
  }

  get f() { return this.laporanForm.controls; }

  ngOnInit() {
    this.laporanForm = this.formBuilder.group({
      judulLaporan: ['', Validators.required],
      keterangan: ['', Validators.required]
    });

    this.statusLaporan = new StatusLaporan;    
    this.laporan = new LaporanHeader;

    // this.laporan.laporanHeaderId = Guid.create();
    this.laporan.userId = this.authService.currentUserValue.userId;
  }

  onSubmit(){
    if(this.laporanForm.valid){
      this.laporanService.postLaporan(this.laporan).subscribe((onSuccess: any[])=> {
        console.log(onSuccess);
        this.router.navigate(['/component/login']);
      });
    }
  }

}
