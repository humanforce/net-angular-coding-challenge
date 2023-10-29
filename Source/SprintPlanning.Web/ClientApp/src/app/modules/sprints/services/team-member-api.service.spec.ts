import { TestBed } from '@angular/core/testing';

import { TeamMemberApiService } from './team-member-api.service';

describe('TeamMemberApiService', () => {
  let service: TeamMemberApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TeamMemberApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
