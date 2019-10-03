import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TestformComponent } from './testform/testform.component';
import { LeftcComponent } from './leftc/leftc.component';
import { RightcComponent } from './rightc/rightc.component';
import { LoginComponent } from './login/login.component';
import { TeacherComponent } from './teacher/teacher.component';
import { StudentComponent } from './student/student.component';
import { ErrorpageComponent } from './errorpage/errorpage.component';
import { AssignmentsComponent } from './assignments/assignments.component';
import { StudentreplyComponent } from './studentreply/studentreply.component';


const routes: Routes = [
  { path: 'testform', component: TestformComponent }
   , { path: 'student', component: StudentComponent }
  , { path: 'teacher', component: TeacherComponent }
  , { path: 'leftc', component: LeftcComponent }
  ,{ path: 'login', component: LoginComponent }
  ,{ path: 'assignments', component: AssignmentsComponent }
  ,{ path: 'studentreply', component:StudentreplyComponent }
  ,{ path: '**', component: ErrorpageComponent }
  , { path: '', redirectTo: '/login', pathMatch: 'full' }
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
