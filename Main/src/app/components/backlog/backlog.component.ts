import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BacklogService } from 'src/app/services/backlog.service';

@Component({
  selector: 'app-backlog',
  templateUrl: './backlog.component.html',
  styleUrls: ['./backlog.component.css']
})
export class BacklogComponent implements OnInit {
    public backlogs: any = [];
    @Input() selectedSprint: any | undefined;

    constructor(public backlogService: BacklogService, public activeModal: NgbActiveModal) {}

    ngOnInit(): void {
        this.backlogs = this.selectedSprint.backlogs;
    }

    closeModal(): void {
        this.activeModal.close();
    }
}
