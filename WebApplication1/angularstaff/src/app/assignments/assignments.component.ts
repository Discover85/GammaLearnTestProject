import { Component, OnInit } from '@angular/core';
import { NgForm, Form } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Router, Route } from "@angular/router"
import { UserService } from '../user.service';
import { FileuploaderService } from '../fileuploader.service';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-assignments',
  templateUrl: './assignments.component.html',
  styleUrls: ['./assignments.component.styl']
})
export class AssignmentsComponent implements OnInit {

  constructor(private http: HttpClient, private router: Router, private userservice: UserService, private uploader: FileuploaderService) {
  }
  public title = "";
  handelFileInput(file: FileList) {
    this.fileToUpload = file.item(0);
  }

  restForm(form?: NgForm) {
    if (form != null) form.resetForm();
    this.title = "";

  }
  ngOnInit() {
    this.restForm();
  }
  readonly rootpath = "http://localhost:51700/api";
  fileToUpload: File = null;
  onSubmit(title: string, file) {
    this.uploader.postAssignment(title, this.fileToUpload, this.userservice.id).subscribe(data => {
      console.log('Done ');
      this.router.navigate(['/teacher']);
    });
    }
}



