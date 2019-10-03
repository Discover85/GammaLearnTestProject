import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserService as UserService } from '../user.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.styl']
})
export class StudentComponent implements OnInit {

  readonly rootpath = "http://localhost:51700/api";
  public list = [];
  private userservice: UserService;
  constructor(private user: UserService, private http: HttpClient, private router: Router) {
    this.userservice = user;
    this.http.get(this.rootpath + '/student/GetMyAssignments?studentId=' + this.userservice.id).subscribe((res: any[]) => {
      console.log(res);
      this.list = res;
    });
  }

  ngOnInit() {
    if (this.userservice.userName == "") this.router.navigate(['/login']);

  }

}
