import { Component, OnInit } from '@angular/core';
import { HttpClient } from 'selenium-webdriver/http';
import { Router } from '@angular/router';
import { UserService } from '../user.service';
import { FileuploaderService } from '../fileuploader.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-studentreply',
  templateUrl: './studentreply.component.html',
  styleUrls: ['./studentreply.component.styl']
})
export class StudentreplyComponent implements OnInit {

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
      this.router.navigate(['/student']);
    });
  }

}
