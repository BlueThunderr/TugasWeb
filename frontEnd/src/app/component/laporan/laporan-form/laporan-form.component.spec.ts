import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LaporanFormComponent } from './laporan-form.component';

describe('LaporanFormComponent', () => {
  let component: LaporanFormComponent;
  let fixture: ComponentFixture<LaporanFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LaporanFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LaporanFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
