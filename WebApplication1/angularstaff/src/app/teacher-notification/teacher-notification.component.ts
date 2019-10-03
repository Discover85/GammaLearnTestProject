import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router'
@Component({
  selector: 'app-teacher-notification',
  templateUrl: './teacher-notification.component.html',
  styleUrls: ['./teacher-notification.component.styl']
})
export class TeacherNotificationComponent implements OnInit {

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
      this.route.params.subscribe(params => {
        //alert(params['assignmentId']);
        //this.http.get(this.rootpath + '/teacher/GetMyNotifications?assignmentId=' + assignmentId + '&&studentId=' + this.userservice.id).subscribe((res: any[]) => {
        //  //this.list = res;
        //});
    });

    
  }

}
