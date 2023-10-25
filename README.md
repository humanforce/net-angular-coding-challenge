# Table of Contents
1. [Scenario](#scenario)
2. [Technology](#technology)
3. [APIs](#apis)
4. [Requirements](#requirements)
5. [Timeframe](#timeframe)
6. [Submission](#submission)
7. [Evaluation](#evaluation)
8. [Interview](#interview)

# Scenario

As a full stack developer, your task is to create a Single Page Application that enables effective planning for a remote team.

The Awesome Squad has three engineers living in different countries: Australia, Pakistan and The Philippines.

- Each team member takes time off according to their country's public holidays.
- The work is distributed across 2-week sprints.
- Tickets' estimations are based in Story Points (`customfield_10016`).
- The following Mock Data is provided in the `Data` folder
  - Sprints (JIRA API)
  - Backlog (JIRA API)
  - Team Members
  - Public Holidays (Google Calendar API)

# Technology

- Frontend: Angular
- Backend: .NET/C#

You can use any IDE, libraries and storage.

## APIs
> [!NOTE]  
> API information provided is for reference purposes only. The objective is to design a flexible solution that allows seamless switching between mock data and real services.

### Google Calendar API

**Requests:**
- `GET` https://www.googleapis.com/calendar/v3/calendars/en.australian%23holiday%40group.v.calendar.google.com/events?key=
- `GET` https://www.googleapis.com/calendar/v3/calendars/en.philippines%23holiday%40group.v.calendar.google.com/events?key=
- `GET` https://www.googleapis.com/calendar/v3/calendars/en.pk%23holiday%40group.v.calendar.google.com/events?key=


### JIRA API

#### Authentication

`Authorization: Basic` Base64(user@humanforce.com:[key](https://id.atlassian.com/manage-profile/security/api-tokens))

#### Sprints
**Request:** `GET` https://hf-sandbox.atlassian.net/rest/agile/latest/board/1/sprint

#### Search
**Request:** `POST` https://hf-sandbox.atlassian.net/rest/api/2/search

**Body:**
```json
{
    "jql": "Sprint='SCRUM'",
    "maxResults": 1000,
    "startAt": 0
}
```


# Requirements

For each Sprint:
1. Display team's velocity based on the past 3 sprints.
2. Display public holidays.
3. Display team's capacity.
4. Display a list of tickets.

# Timeframe
- You have one week to complete the challenge and we recommend investing a maximum of 4 hours.

# Submission
- Once you have completed the challenge, please submit your solution.
- Ensure that you include any necessary documentation or instructions required to run your code.

# Evaluation
- After the submission, our hiring team will review your solution thoroughly.
- We will assess your code quality, problem-solving approach, and adherence to best coding practices.

# Interview
During the technical interview you will be asked to:

- Showcase your solution (running and working on your own laptop)
- Bring a list of questions/assumptions/concerns/opinions for discussion (architecture, design and code related topics).
- Make small changes in your application



