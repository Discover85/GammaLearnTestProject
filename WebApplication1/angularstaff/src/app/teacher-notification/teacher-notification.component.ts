import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router'
import { HttpClient } from '@angular/common/http';
import { UserService } from '../user.service';

@Component({
  selector: 'app-teacher-notification',
  templateUrl: './teacher-notification.component.html',
  styleUrls: ['./teacher-notification.component.styl']
})
export class TeacherNotificationComponent implements OnInit {
  public list = [];
  readonly rootpath = "http://localhost:51700/api";



  constructor(private route: ActivatedRoute, private http: HttpClient, private userservice: UserService) { }

  ngOnInit() {
      this.route.params.subscribe(params => {
        //alert();
        this.http.get(this.rootpath + '/teacher/GetMyNotifications?assignmentId=' + params['assignmentId'] + '&&personId=' + this.userservice.id).subscribe((res: any[]) => {
           this.list = res;
        });
    });

    
  }

}
