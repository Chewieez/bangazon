# Bangazon-API
The Bangazon-API provides users with access to information about the Bangazon organization. The company provides information from two categories:
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
This method will return an array containing all of the Department records in the database
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
Place the DepartmentId at the end of the url to retrieve just that record.

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
This method handles post requests, which adds a
record to the database. When executing the POST request, do not
include the DepartmentId in the body of the request. The database will
assign a unique DepartmentId automatically.

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
This method handles put requests for the Department. Users need to 
provide a DepartmentId at the end of the url and send a full Department 
object to complete the update.

If successful, the return value will match the body of your PUT request. Requires that the DepartmentId of the record to be erased be placed at the end of the URL.
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

<br>

## Employee
Supports: GET, POST, PUT

### GET
This method will return an array containing all of the Employee records in the database
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
Place the EmployeeId at the end of the url to retrieve just that record.

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
This method handles post requests, which adds a
record to the database. When executing the POST request, do not
include the EmployeeId in the body of the request. The database will
assign a unique EmployeeId automatically.
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
This method handles put requests for the Employee. Users need to 
provide a EmployeeId at the end of the url and send a full Employee 
object to complete the update.
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
<br>

## Training Program
Supports: GET, POST, PUT, DELETE (future start dates only)


### GET
This method will return an array containing all of the TrainingProgram records in the database
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
Place the TrainingProgramId at the end of the url to retrieve just that record.
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
This method handles post requests, which adds a
record to the database. When executing the POST request, do not
include the TrainingProgramId in the body of the request. The database will
assign a unique TrainingProgramId automatically.
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
This method handles put requests for the TrainingProgram. Users need to 
provide a TrainingProgramId at the end of the url and send a full TrainingProgram 
object to complete the update.
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
This method handles DELETE requests for the TrainingProgram records. Requires that the TrainingProgramId of the record to be erased be placed at the end of the URL.

You are only allowed to delete Training Programs that have a start Date in the future. 

If successful, the object deleted will be returned.
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

<br>

## Computer Resources
Supports: GET, POST, PUT, DELETE

### GET
This method will return an array containing all of the Computer records in the database.
- Example URL: 
 http://localhost:5000/api/Computer
- Example Response:
```
[   
    {
        "computerId": 1,
        "name": "Microsoft Surface Laptop",
        "serialNumber": "11202",
        "purchaseDate": "2017-01-23T00:00:00",
        "decommissionDate": null
    },
    {
        "computerId": 2,
        "name": "Dell Inspiron 7000",
        "serialNumber": "33319",
        "purchaseDate": "2017-05-21T00:00:00",
        "decommissionDate": null
    }
]
```
### GET Single Record
Place the ComputerId at the end of the url to retrieve just that Computer record. 

- Example URL:
http://localhost:5000/api/Computer/1
- Example Response:
```
{
    "computerId": 1,
    "name": "Microsoft Surface Laptop",
    "serialNumber": "11202",
    "purchaseDate": "2017-01-23T00:00:00",
    "decommissionDate": null
}
```

### POST
This method handles post requests, which adds a
record to the database. When executing the POST request, do not
include the ComputerId in the body of the request. The database will
assign a unique ComputerId automatically.
- Example URL:
http://localhost:5000/api/Computer
- Example POST Request:
```
{
    "name": "MacBook Air",
    "serialNumber": "10688",
    "purchaseDate": "2017-01-29T00:00:00",
    "decommissionDate": null
}

Example return: Assuming the newly created id is 18:
{
    "computerId": 24,
    "name": "MacBook Air",
    "serialNumber": "10688",
    "purchaseDate": "2017-01-29T00:00:00",
    "decommissionDate": null
}

```

### PUT
This method handles put requests for the Computer. Users need to 
provide a ComputerId at the end of the url and send a full Computer 
object to complete the update.

If successful, the return value will match the body of your PUT request.
- Example URL:
http://localhost:5000/api/Computer/18
- Example PUT Request:
```
{
    "computerId": 24,
    "name": "MacBook Pro",
    "serialNumber": "10688",
    "purchaseDate": "2017-01-29T00:00:00",
    "decommissionDate": null
}
```

### DELETE
This method handles DELETE requests for the Computer records. Requires that the ComputerId of the record to be erased be placed at the end of the URL.

If successful, the object deleted will be returned.
- Example URL:
http://localhost:5000/api/Computer/1




## Order
Supports: GET, POST, PUT, DELETE

### GET
This method will return an array containing all of the Order records in the database.
- Example URL: 
 http://localhost:5000/api/Order
- Example Response:
```
[   
    {
        "orderId": 1,
        "paymentTypeId": 1,
        "customerId": 1,
        "customer": null,
        "completedDate": "2017-07-17T00:00:00"
    },
    {
        "orderId": 2,
        "paymentTypeId": 16,
        "customerId": 16,
        "customer": null,
        "completedDate": "2017-12-09T00:00:00"
    }
]
```
### GET Single Record
Place the OrderId at the end of the url to retrieve just that order record. 
All of the associated products for the order will be included as an array assigned to the "products" key.
- Example URL:
http://localhost:5000/api/Order/1
- Example Response:
```
{
    "orderId": 1,
    "customerId": 1,
    "paymentTypeId": 1,
    "products": [
    {
        "productId": 1,
        "name": "Knit Hat",
        "price": 25,
        "quantity": 2
    },
    {
        "productId": 2,
        "name": "Knit Scarf",
        "price": 25,
        "quantity": 4
    }
} 
```

### POST
This method handles post requests, which adds a
record to the database. When executing the POST request, do not
include the OrderId in the body of the request. The database will
assign a unique OrderId automatically. 
- Example URL:
http://localhost:5000/api/Order
- Example POST Request:
```
{
    "paymentTypeId": 1,
    "customerId": 1,
    "completedDate": "2018-01-29T00:00:00"
}

Example return: Assuming the newly created id is 18:
 {
    "orderId": 18,
    "paymentTypeId": 1,
    "customerId": 1,
    "customer": null,
    "completedDate": "2018-01-29T00:00:00"
}

```

### PUT
This method handles put requests for the Order. Users need to 
provide a OrderId at the end of the url and send a full Order 
object to complete the update.

If successful, the return value will match the body of your PUT request.
- Example URL:
http://localhost:5000/api/Order/18
- Example PUT Request:
```
{
    "orderId": 18,
    "paymentTypeId": 2,
    "customerId": 1,
    "completedDate": "2018-01-29T00:00:00"
}
```

### DELETE
This method handles DELETE requests for the Order records. Requires that the OrderId of the record to be erased be placed at the end of the URL.

If successful, the object deleted will be returned.
- Example URL:
http://localhost:5000/api/Order/1

<br>

## Product
Supports: GET, POST, PUT, DELETE

### GET
This method will return an array containing all of the Product records in the database.
- Example URL: 
 http://localhost:5000/api/Product
- Example Response:
```
[   
    { 
        productId: 1,
        productCategoryId: 2,
        productCategory: null,
        customerId: 1,
        customer: null,
        name: 'Knit Hat',
        price: 25,
        description: 'A beautifully knitted hat for a toddler girl.',
        quantity: 2 
    },
    {   productId: 2,
        productCategoryId: 2,
        productCategory: null,
        customerId: 1,
        customer: null,
        name: 'Knit Scarf',
        price: 25,
        description: 'A beautifully knitted scarf for a toddler girl.',
        quantity: 4 
    }
]
```
### GET Single Record
Place the ProductId at the end of the url to retrieve just that record.
If successful, the return value will match the body of your POST request.
- Example URL:
http://localhost:5000/api/Product/1
- Example Response:
```
{   
    productId: 1,
    productCategoryId: 2,
    productCategory: null,
    customerId: 1,
    customer: null,
    name: 'Knit Hat',
    price: 25,
    description: 'A beautifully knitted hat for a toddler girl.',
    quantity: 2 
}
```

### POST
This method handles post requests, which adds a
record to the database. When executing the POST request, do not
include the ProductId in the body of the request. The database will
assign a unique ProductId automatically.
- Example URL:
http://localhost:5000/api/Product
- Example POST Request:
```
{   
    productCategoryId: 2,
    customerId: 1,
    name: 'Bowler Hat',
    price: 25,
    description: 'Charlie Chaplin.',
    quantity: 2 
    }

Example return: Assuming the newly created id is 14:
{   productId: 14,
    productCategoryId: 2,
    productCategory: null,
    customerId: 1,
    customer: null,
    name: 'Bowler Hat',
    price: 25,
    description: 'Charlie Chaplin.',
    quantity: 2 
}

```

### PUT
This method handles put requests for the Product. Users need to 
provide a ProductId at the end of the url and send a full Product 
object to complete the update.

If successful, the return value will match the body of your PUT request.
- Example URL:
http://localhost:5000/api/Product/1
- Example PUT Request:
```
{   
    productId: 14,
    productCategoryId: 2,
    customerId: 1,
    name: 'Bowler Hat',
    price: 25,
    description: 'Charlie Chaplin.',
    quantity: 2 
}
```

### DELETE
This method handles DELETE requests for the Product records. Requires that the ProductId of the record to be erased be placed at the end of the URL.

If successful, the object deleted will be returned.
- Example URL:
http://localhost:5000/api/Product/1

<br>

## Customer
Supports: GET, POST, PUT

### GET
This method handles GET requests for the customer resource. 
You may use an optional parameter to retrieve a list of customers that either 
have placed orders or have not.:
    /api/customer/?active=true - customers that have placed orders
    /api/customer/?active=false - customers without orders
- Example URL: 
 http://localhost:5000/api/Customer
- Example Response:
```
[   
   {
        "customerId": 1,
        "firstName": "Stacy",
        "lastName": "Gauger",
        "creationDate": "2017-06-21T00:00:00",
        "lastLoginDate": "2018-01-24T00:00:00",
        "orders": null,
        "paymentTypes": null,
        "products": null
    },
    {
        "customerId": 2,
        "firstName": "Loreta",
        "lastName": "Balmer",
        "creationDate": "2017-10-17T00:00:00",
        "lastLoginDate": "2018-01-20T00:00:00",
        "orders": null,
        "paymentTypes": null,
        "products": null
    } 
]
```
### GET Single Record
Place the CustomerId at the end of the url to retrieve just that record.
If successful, the return value will match the body of your POST request.
- Example URL:
http://localhost:5000/api/Customer/1
- Example Response:
```
{ 
    CustomerId: 1, 
    name: 'Jewelry & Accessories' 
}
```

### POST
This method handles post requests, which adds a
record to the database. When executing the POST request, do not
include the CustomerId in the body of the request. The database will
assign a unique CustomerId automatically. The database will also handle adding a CreationDate automatically. All you are required to pass in upon Customer creation is first and last name.
- Example URL:
http://localhost:5000/api/Customer
- Example POST Request:
```
{ 
    "firstName": "Stacy",
    "lastName": "Gauger",
}
```
- Example POST return:
```
{
    "customerId": 1,
    "firstName": "Stacy",
    "lastName": "Gauger",
    "creationDate": "2018-01-30T22:03:53.293353-06:00",
    "lastLoginDate": null,
    "orders": null,
    "paymentTypes": null,
    "products": null
}
```

### PUT
This method handles put requests for the Customer. Users need to 
provide a CustomerId at the end of the url and send a full Customer 
object to complete the update.

If successful, the return value will match the body of your PUT request.
- Example URL:
http://localhost:5000/api/Customer/1
- Example PUT Request:
```
{
    "customerId": 1,
    "firstName": "Stacy",
    "lastName": "Gauger",
    "creationDate": "2018-01-30T22:03:53.293353-06:00",
    "lastLoginDate": "2018-01-30T00:00:00"
} 
```
<br>


## Product Category
Supports: GET, POST, PUT, DELETE

### GET
This method will return an array containing all of the ProductCategory records in the database.
- Example URL: 
 http://localhost:5000/api/ProductCategory
- Example Response:
```
[   { ProductCategoryId: 1, name: 'Jewelry & Accessories' },
    { ProductCategoryId: 2, name: 'Clothing & Shoes' },
    { ProductCategoryId: 3, name: 'Home & Living' },
    { ProductCategoryId: 4, name: 'Arts & Collectibles' } 
]
```
### GET Single Record
Place the ProductCategoryId at the end of the url to retrieve just that record.
If successful, the return value will match the body of your POST request.
- Example URL:
http://localhost:5000/api/ProductCategory/1
- Example Response:
```
{ 
    CustomerId: 1, 
    name: 'Jewelry & Accessories' 
}
```

### POST
This method handles post requests, which adds a
record to the database. When executing the POST request, do not
include the ProductCategoryId in the body of the request. The database will
assign a unique ProductCategoryId automatically.
- Example URL:
http://localhost:5000/api/ProductCategory
- Example POST Request:
```
{ name: 'Jewelry & Accessories' }
```

### PUT
This method handles put requests for the ProductCategory. Users need to 
provide a ProductCategoryId at the end of the url and send a full ProductCategory 
object to complete the update.

If successful, the return value will match the body of your PUT request.
- Example URL:
http://localhost:5000/api/ProductCategory/1
- Example PUT Request:
```
{ 
    ProductCategoryId: 1, 
    name: 'Jewelry Accessories & More' 
}
```

### DELETE
This method handles DELETE requests for the ProductCategory records. Requires that the ProductCategoryId of the record to be erased be placed at the end of the URL.

If successful, the object deleted will be returned.
- Example URL:
http://localhost:5000/api/ProductCategory/1



## Payment Type
Supports: GET, POST, PUT, DELETE

### GET
This method will return an array containing all of the PaymentType records in the database.
- Example URL: 
 http://localhost:5000/api/PaymentType
- Example Response:
```
[
    {
        "paymentTypeId": 1,
        "name": "PayPal",
        "customerId": 1,
        "customer": null,
        "accountNumber": 11111
    },
    {
        "paymentTypeId": 2,
        "name": "Apple Pay",
        "customerId": 1,
        "customer": null,
        "accountNumber": 22221
    }
]
```
### GET Single Record
Place the PaymentTypeId at the end of the url to retrieve just that record.
If successful, the return value will match the body of your POST request.
- Example URL:
http://localhost:5000/api/PaymentType/1
- Example Response:
```
{
    "paymentTypeId": 1,
    "name": "PayPal",
    "customerId": 1,
    "customer": null,
    "accountNumber": 11111
}
```

### POST
This method handles post requests, which adds a
record to the database. When executing the POST request, do not
include the paymentTypeId in the body of the request. The database will
assign a unique paymentTypeId automatically.
- Example URL:
http://localhost:5000/api/PaymentType
- Example POST Request:
```
{
    "name": "Apple Pay",
    "customerId": 1,
    "accountNumber": 565722828
}
```

### PUT
This method handles put requests for the PaymentType. Users need to 
provide a PaymentTypeId at the end of the url and send a full PaymentType 
object to complete the update.

If successful, the return value will match the body of your PUT request.
- Example URL:
http://localhost:5000/api/PaymentType/1
- Example PUT Request:
```
{
  "departmentId": 0,
  "name": "string",
  "expenseBudget": 0
}
```

### DELETE
This method handles DELETE requests for the PaymentType records. Requires that the PaymentTypeId of the record to be erased be placed at the end of the URL.

If successful, the object deleted will be returned.
- Example URL:
http://localhost:5000/api/PaymentType/1

<br><br>


## Contributors

[Jason Figueroa](https://github.com/jasonfigueroa)
[Dre Randaci](https://github.com/DreRandaci)
[Krys Mathis](https://github.com/krysmathis)
[Greg Lawrence](https://github.com/Chewieez)
