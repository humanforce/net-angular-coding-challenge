export interface Sprint {
    id: number;
    name: string;
    state: string;
    start: number;
    end: number;
    originBoardId: number;
    goal: string;
  
    points: number;
    capacity: number;
    velocity: number;
  
    issues: Issue[];
    holidays: Holiday[];
}
  
export interface Issue {
    fields: Fields;
}
  
export interface Fields {
    summary: string;
    customfield_10016: number;
    customfield_10020: Field[];
}
  
export interface Field {
    id: number;
}

export interface Holiday {
    name: string;
    startDate: Date;
}