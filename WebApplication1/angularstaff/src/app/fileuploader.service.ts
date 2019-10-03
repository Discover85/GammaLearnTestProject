import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class FileuploaderService {
  readonly rootpath = "http://localhost:51700/api";

  constructor(private http: HttpClient) { }
  postAssignment(title: string, file: File,teacherId) {
    const fd: FormData = new FormData();
    fd.append('file', file, file.name);
    fd.append('title', title);
    fd.append('teacherId', teacherId);
    return this.http.post(this.rootpath + '/Teacher/CreateAssignment', fd);
  }
  replytoassignment(title: string, file: File, studentId) {
    const fd: FormData = new FormData();
    fd.append('file', file, file.name);
    fd.append('title', title);
    fd.append('studentId', studentId);
    return this.http.post(this.rootpath + '/Student/ActionOnAssignment', fd);
  }
}
