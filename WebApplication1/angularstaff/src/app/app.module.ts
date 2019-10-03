import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
 

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
 import { ToastrModule } from 'ngx-toastr';

import { TestformComponent } from './testform/testform.component';
import { LeftcComponent } from './leftc/leftc.component';
import { RightcComponent } from './rightc/rightc.component';
import { LoginComponent } from './login/login.component';
import {FormsModule } from '@angular/forms';
import { StudentComponent } from './student/student.component';
import { TeacherComponent } from './teacher/teacher.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ErrorpageComponent } from './errorpage/errorpage.component';
import { AssignmentsComponent } from './assignments/assignments.component';
import { StudentreplyComponent } from './studentreply/studentreply.component';

@NgModule({
  declarations: [
    AppComponent,
    TestformComponent,
    LeftcComponent,
    RightcComponent,
    LoginComponent,
    StudentComponent,
    TeacherComponent,
    ErrorpageComponent,
    AssignmentsComponent,
    StudentreplyComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ToastrModule.forRoot({
      timeOut: 2000,
      positionClass: 'toast-bottom-center',
      preventDuplicates: true,
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
