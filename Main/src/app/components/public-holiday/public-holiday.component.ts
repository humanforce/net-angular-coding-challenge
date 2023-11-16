import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { PublicHolidayService } from 'src/app/services/public-holiday.service';

@Component({
    selector: 'app-public-holiday',
    templateUrl: './public-holiday.component.html',
    styleUrls: ['./public-holiday.component.css']
})
export class PublicHolidayComponent implements OnInit {
    @Input() countryName: string | undefined;
    @Input() publicHolidays: any;

    constructor(public publicHolidayService: PublicHolidayService, public activeModal: NgbActiveModal) { }

    ngOnInit(): void {}

    closeModal(): void {
        this.activeModal.close();
    }
}
