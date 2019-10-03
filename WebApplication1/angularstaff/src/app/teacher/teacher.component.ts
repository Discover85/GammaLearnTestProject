import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { UserService } from '../user.service';

@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrls: ['./teacher.component.styl']
})
export class TeacherComponent {
  readonly rootpath = "http://localhost:51700/api";

  public allItems= [];
  public list = [];
  public userservice: UserService;
  constructor(private user: UserService, private http: HttpClient, private router: Router) {
    this.userservice = user;
    this.http.get(this.rootpath + '/teacher/getActivities?teacherId=' + this.userservice.id).subscribe((res: any[]) => {
      console.log(res);
      this.allItems = res;
      this.list = this.allItems;
    });
  }
  public forecasts: WeatherForecast[];

  searchbyassignment(title: string) {
    this.list = this.allItems.filter(it => {
      title = title.toLowerCase();
      return it.assignment.toLowerCase().includes(title);
    }); 

    
  }

 searchbycreatedate(title: string) {
    this.list = this.allItems.filter(it => {
      return it.createdate.includes(title);
    }); 

    
  }


  ngOnInit() {
    if (this.userservice.userName == "") this.router.navigate(['/login']);

  }


}
interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
