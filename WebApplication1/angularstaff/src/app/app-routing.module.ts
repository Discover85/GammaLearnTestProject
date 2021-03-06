import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TestformComponent } from './testform/testform.component';
import { LoginComponent } from './login/login.component';
import { TeacherComponent } from './teacher/teacher.component';
import { StudentComponent } from './student/student.component';
import { ErrorpageComponent } from './errorpage/errorpage.component';
import { AssignmentsComponent } from './assignments/assignments.component';
import { StudentreplyComponent } from './studentreply/studentreply.component';
import { StudentNotificationsComponent } from './student-notifications/student-notifications.component';
import { TeacherNotificationComponent } from './teacher-notification/teacher-notification.component';


const routes: Routes = [
  { path: 'testform', component: TestformComponent }
   , { path: 'student', component: StudentComponent }
  , { path: 'teacher', component: TeacherComponent }
  ,{ path: 'login', component: LoginComponent }
  ,{ path: 'assignments', component: AssignmentsComponent }
  , { path: 'studentreply', component: StudentreplyComponent }
  , { path: 'studentNotifications', component: StudentNotificationsComponent }
  , { path: 'teacherNotification/:assignmentId', component: TeacherNotificationComponent }
  , { path: '**', component: LoginComponent }
  , { path: '', redirectTo: '/login', pathMatch: 'full' }
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
