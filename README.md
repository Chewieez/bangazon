# Bangazon-API
The Bangazon-API provides users with access to information about the Bangazon organization. The company provides information from two domains:
* The **company** itself including Employees, Training Programs and Computer Equipment
* The Bangazon **App** including Customers, Products and Orders

**Access to this API is restricted to employees of Bangazon**

## Installation:

1. Clone or download the repo
1. Configure an environment variable for the database named: ```BANGAZON_API_DB```
1. In the terminal, navigate to the directory with the repo. Begin by installing the required packages.

    ```
    dotnet update
    ```
1. Next, run the command to generate the db
    ```
    dotnet ef database update
    ```
1. Next run the application
    ```
    dotnet run
    ```

# API Resources

## Department
Supports: GET, POST, PUT

### GET
- Example URL: 
 http://localhost:5000/api/Department
- Example Response:
```
[
  {
    "departmentId": 1,
    "name": "IT",
    "expenseBudget": 899000
  },
  {
    "departmentId": 2,
    "name": "Admin",
    "expenseBudget": 500000
  }
]
```
### GET Single Record
- Example URL:
http://localhost:5000/api/Department/1
- Example Response:
```
{
  "departmentId": 1,
  "name": "IT",
  "expenseBudget": 899000
}
```

### POST
- Example URL:
http://localhost:5000/api/Department
- Example POST Request:
```
{
  "name": "string",
  "expenseBudget": 0
}
```

### PUT
- Example URL:
http://localhost:5000/api/Department/1
- Example PUT Request:
```
{
  "departmentId": 0,
  "name": "string",
  "expenseBudget": 0
}
```

## Employee
Supports: GET, POST, PUT

### GET
- Example URL: 
 http://localhost:5000/api/Employee
- Example Response:
```
[
  {
    "employeeId": 1,
    "departmentId": 1,
    "firstName": "Kenneth",
    "lastName": "Allen",
    "startDate": "2017-06-11T00:00:00",
    "supervisor": false
  },
  {
    "employeeId": 2,
    "departmentId": 3,
    "firstName": "Sarah",
    "lastName": "Angell",
    "startDate": "2017-04-30T00:00:00",
    "supervisor": false
  }
]
```
### GET Single Record
- Example URL:
http://localhost:5000/api/Employee/1
- Example Response:
```
  {
    "employeeId": 1,
    "departmentId": 1,
    "firstName": "Kenneth",
    "lastName": "Allen",
    "startDate": "2017-06-11T00:00:00",
    "supervisor": false
  }
```

### POST
- Example URL:
http://localhost:5000/api/Employee
- Example POST Request:
```
{
    "departmentId": 1,
    "firstName": "Sandy",
    "lastName": "Williams",
    "startDate": "2/2/2018",
    "supervisor": false
}
```

### PUT
- Example URL:
http://localhost:5000/api/Employee/1
- Example PUT Request:
```
{
    "employeeId": 1,
    "departmentId": 1,
    "firstName": "Sandy",
    "lastName": "Blake Williams",
    "startDate": "2/2/2018",
    "supervisor": true
}
```

## Training Program
Supports: GET, POST, PUT, DELETE (future start dates only)

### GET
- Example URL: 
 http://localhost:5000/api/TrainingProgram
- Example Response:
```
[
  {
    "trainingProgramId": 34,
    "name": "IT Security Training",
    "startDate": "2017-03-19T00:00:00",
    "endDate": "2017-03-23T00:00:00",
    "maxAttendance": 25
  },
  {
    "trainingProgramId": 35,
    "name": "Operating Systems Concepts",
    "startDate": "2017-02-26T00:00:00",
    "endDate": "2017-03-02T00:00:00",
    "maxAttendance": 25
  }
]
```
### GET Single Record
- Example URL:
http://localhost:5000/api/TrainingProgram/34
- Example Response:
```
  {
    "trainingProgramId": 34,
    "name": "IT Security Training",
    "startDate": "2017-03-19T00:00:00",
    "endDate": "2017-03-23T00:00:00",
    "maxAttendance": 25
  }
```

### POST
- Example URL:
http://localhost:5000/api/TrainingProgram
- Example POST Request:
```
{
    "name": "Sales and Accounting",
    "startDate": "2017-03-19T00:00:00",
    "endDate": "2017-03-23T00:00:00",
    "maxAttendance": 10
}
```

### PUT
- Example URL:
http://localhost:5000/api/TrainingProgram/34
- Example PUT Request:
```
{
    "trainingProgramId": 34,
    "name": "IT Security Training",
    "startDate": "2017-03-19T00:00:00",
    "endDate": "2017-03-23T00:00:00",
    "maxAttendance": 30
}
```

### DELETE (Only for future dates)
- Example URL:
http://localhost:5000/api/TrainingProgram/57
- Example DELETE Response:
```
{
  "trainingProgramId": 57,
  "name": "Sales and Accounting",
  "startDate": "2018-02-20T00:00:00",
  "endDate": "2018-02-21T00:00:00",
  "maxAttendance": 10
}
```

## Computer Resources
Supports: GET, POST, PUT, DELETE

## Order
Supports: GET, POST, PUT, DELETE

## Product
Supports: GET, POST, PUT, DELETE

## Customer
Supports: GET, POST, PUT

## Product Category
Supports: GET, POST, PUT, DELETE

## Payment Type
Supports: GET, POST, PUT, DELETE
