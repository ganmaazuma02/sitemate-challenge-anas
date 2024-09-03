import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {IssueService} from '../../services/issue.service';
import {Issue} from '../../models/issue';

@Component({
  selector: 'app-issue-list',
  templateUrl: './issue-list.component.html',
  styleUrl: './issue-list.component.scss'
})
export class IssueListComponent implements OnInit {
  issueList: Issue[] = [];
  @ViewChild('issueTitle') issueTitleInputRef: ElementRef<HTMLInputElement> = null!;
  @ViewChild('issueDescription') issueDescriptionInputRef: ElementRef<HTMLInputElement> = null!;

  constructor(private issueService: IssueService) { }

  ngOnInit(): void {
    //call API to get all
    this.loadIssues();
  }

  loadIssues() {
    this.issueService.getAllIssues().subscribe(issues => this.issueList = issues);
  }

  createIssue(title: string, description: string): void {
    if (title.trim() !== '') {
      const newIssue: Issue = {
        id: 0,
        title: title.trim(),
        description: description,
      };
      this.issueService.createIssue(newIssue).subscribe(res => {
        this.issueTitleInputRef.nativeElement.value = '';
        this.issueDescriptionInputRef.nativeElement.value = '';
        this.loadIssues();
      });

    }
  }

  deleteIssue(id: number): void {
    this.issueService.deleteIssue(id).subscribe(res => {
      this.issueList = this.issueList.filter(item => item.id !== id);
    })
  }

  updateIssue(id: number, title: string, description: string): void {
    const issue: Issue = {
      id: id,
      title: title,
      description: description
    }
    this.issueService.updateIssue(issue).subscribe(res => {
      
    })
  }

}
