import { Injectable } from '@angular/core';
import { Issue, Sprint } from '../app';

@Injectable({
    providedIn: 'root'
})
export class SprintService {
    private url = 'https://localhost:7073/sprint/';
    private sprints: Sprint[] = [];
    private initialised = false;

    public async initialise() {
        await this.getSprints()
        .then((result) => {
            this.sprints = result.values.map((x: any): Sprint => {
            return {
                id: x.id,
                name: x.name,
                state: x.state,
                start: Date.parse(x.startDate),
                end: Date.parse(x.endDate),
                originBoardId: x.originBoardId,
                goal: x.goal,
                capacity: 240,
                points: 0,
                velocity: 0,
                issues: [],
                holidays: []
            };
            });

            return this.getBacklog();
        })
        .then((result) => {
            for (let issue of result.issues as Issue[]) {
                let sprint = this.sprints.find((x) => x.id === issue.fields?.customfield_10020[0]?.id);
                if (sprint) {
                    sprint.issues.push(issue);
                }
            }

            this.sprints = this.sprints.sort((a, b) => b.id - a.id);
            let count = this.sprints.length;
            for (let i = count - 1; i >= 0; i--) {
                let points = this.sprints[i].issues
                    .map((x) => x.fields.customfield_10016)
                    .reduce((a,b) => a+b, 0);
                this.sprints[i].points = points;

                let vel = 0;
                let lastIndex = Math.min(count - 1, i + 3);
                for (let j = lastIndex; j > i; j--) {
                    vel += this.sprints[j].points;
                }
                if (i < count - 1)
                    vel /= (lastIndex - i);
                this.sprints[i].velocity = vel;
            }

            return Promise.all([
                this.getHolidays('australian'),
                this.getHolidays('pakistan'),
                this.getHolidays('philippines')
            ]);
        })
        .then((result) => {
            for (let holidaysResponse of result) {
                for (let holiday of holidaysResponse.items) {
                    let startDate = Date.parse(holiday.start.date);
                    let sprint = this.sprints.find((x) => x.start <= startDate && x.end > startDate );
                    if (sprint) {
                        sprint.holidays.push({
                        name: holiday.summary,
                        startDate: holiday.start,
                        });
                        sprint.capacity -= 8;
                    }
                }
            }
        });
    }

    async getHolidays(region: string): Promise<any> {
        const response = await fetch(`${this.url}holidays?region=${region}`);
        return await response.json();
    }

    async getSprints(): Promise<any> {
        const response = await fetch(`${this.url}sprints`);
        return await response.json();
    }

    async getBacklog(): Promise<any> {
        const response = await fetch(`${this.url}backlog`);
        return await response.json();
    }

    public async getCachedSprints(): Promise<Sprint[]> {
        if (!this.initialised) {
            await this.initialise();
            this.initialised = true;
        }
        return this.sprints;
    }

    public async getSprintById(id: number): Promise<Sprint> {
        if (!this.initialised) {
            await this.initialise();
            this.initialised = true;
        }
        return this.sprints.find((x) => x.id === id) ?? {} as Sprint;
    }
}
