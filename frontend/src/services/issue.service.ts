import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Issue} from '../models/issue';

@Injectable({
  providedIn: 'root'
})
export class IssueService {

  //apiHost = environment.apiHost;

  constructor(private http: HttpClient) {

  }

  getAllIssues(): Observable<Issue[]> {
    return this.http.get<Issue[]>(`http://localhost:5261/api/issues/`)
  }
  createIssue(issue: Issue): Observable<any>{
    return this.http.post(`http://localhost:5261/api/issues/`, issue)
  }

  deleteIssue(id: number): Observable<any>{
    return this.http.delete(`http://localhost:5261/api/issues/${id}`)
  }

  updateIssue(issue: Issue): Observable<any>{
    return this.http.put(`http://localhost:5261/api/issues/`, issue)
  }
}
