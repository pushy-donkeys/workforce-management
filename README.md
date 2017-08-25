# Workforce Management

This application allows a user to perform various actions for Employees, Computers, Departments, and Training Programs. The user can create, edit, delete, and view lists and details. These actions are all performed in the browser.


## Installing Core Technologies

### Visual Studio
Microsoft Visual Studio is an integrated development environment (IDE) from Microsoft. It is used to develop computer programs for Microsoft Windows, as well as web sites, web apps, web services and mobile apps.


### Visual Studio Code
Visual Studio Code is Microsoft's cross-platform editor that we'll be using during orientation for writing C# and building .NET applications. Make sure you add the C# extension immediately after installation completes.


### OSX
[Install .NET Core] (https://www.microsoft.com/net/core#macos)
Create and run an ASP.NET application using .NET Core
(https://docs.asp.net/en/latest/getting-started.html)
Review .NET Core Documentation
(https://docs.microsoft.com/en-us/dotnet/)

### How to Run
After cloning the repo, run in your console:
```
Update-Database
```
Then run the program and begin to test each categories functionality in the browser.

### Employees
- An HR employee should be able to view employees. When the employee clicks on the Employees item in the navigation bar all current employees should be listed with the following information
```
First name and last name
Department
```
- The user can then click 'Create New link'. A form for will be displayed on which the following information can be entered:
```
First name
Last name
Employment start date
Select a department from a drop down
```
- When a user clicks on details of an employee, the following should be displayed:
```
First name and last name
Department
Currently assigned computer
Training programs they have attended, or plan on attending
```

- When a user clicks on the Edit link they should be able to:
```
Edit the last name of the employee
Or change the department to which the employee is assigned
Or change the computer assigned to the employee
Or add/remove training programs for the employee to attend in the future
```

### Departments
-  When a user clicks on the Departments section in the navigation bar all current departments should be listed

- When a user clicks on the Create New link in the department section, a form should be presented in which the new department name can be entered.

- When user clicks on a department a view should be presented with the department name as a header. A list of employees currently assigned to that department should be listed.
 
### Computers
- When a user clicks on the Computers item in the navigation bar they should see a list of all computers.
Each item should be a hyperlink that can be clicked to view the details.

- Given a user is viewing all computers
When the user clicks the Create New link in the computer section they should be presented with a form in which the following information can be entered:
```
Computer manufacturer
Computer make
Purchase date
```

- When the user is viewing a single computer and clicks the Delete link they should be presented with a screen to verify that it should be deleted. If the user chooses Yes from that screen, the computer should be deleted only if it is has never been assigned to an employee.

### Training Programs
- When a user wants to view all training programs they can click on the 'Training Programs' item in the nav bar. The user will then see a list of all training programs that have not yet taken place.

- When the user is viewing all training programs and clicks the Create New link, they should be presented with a form in which the following information can be entered:
```
Name
Description
Start day
End day
Maximum number of attendees
```

- When a user is viewing the list of training programs and clicks on a training program they should see all details of that training program. They should also see any employees that are currently attending the program.




## Collaboraters
* Dylan
* Kyle
* Kevin
* Pete
* Ryan
