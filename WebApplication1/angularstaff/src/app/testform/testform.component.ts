import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-testform',
  templateUrl: './testform.component.html',
  styleUrls: ['./testform.component.styl']
})
export class TestformComponent implements OnInit {

  constructor(private toastr:ToastrService) { }

  ngOnInit() {
  }
  public test_message() {
    this.toastr.success("The operation has been done successfully","Success");

  }
}
