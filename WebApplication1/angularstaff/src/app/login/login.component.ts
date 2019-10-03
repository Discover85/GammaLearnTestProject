import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Router } from "@angular/router"
import { UserService } from '../user.service';
import { HttpClient, HttpParams } from '@angular/common/http';
 
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.styl']
})
export class LoginComponent   {
  private userservice: UserService;

  constructor(private user: UserService, private http: HttpClient, private toastr: ToastrService, private router: Router) {
    this.userservice = user;

  }


  ngOnInit() {
    this.restForm();
  }
  public username = "";
  public password = "";
  restForm(form?: NgForm) {
    if (form != null) form.resetForm();
    this.username = "";
    this.password = "";
    this.userservice.userName = "";
    this.userservice.id = "";
    this.userservice.name = "";

  }
  readonly rootpath = "http://localhost:51700/api";
  private userAccount;
  onSubmit(username: string, password: string) {
    let params = new HttpParams().set('username', this.username).set('password', this.password);
    this.http.get(this.rootpath + '/Account/GetUser', { params: params }).subscribe((res: any[]) => {
      console.log(res);
      this.userAccount = res;
      if (this.userAccount == null)
        this.toastr.error("Please enter valid user detail", "Invalid");
      this.userservice.userName = this.username;
      this.userservice.id = this.userAccount.id;
      this.userservice.name= this.userAccount.title;

      if (this.userAccount.isTeacher) {
        this.toastr.success("Teacher,Welcome to portal", "Success");
        this.router.navigate(['./teacher']);
      }
      else {
        this.toastr.success("Student,Welcome to portal", "Success");
        this.router.navigate(['./student']);
      }
    });
   

  }

}
