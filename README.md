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
provide a DepartmentId at the end of the url and send a full PaymentType 
object to complete the update.

If successful, the return value will match the body of your PUT request.
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

## Training Program
Supports: GET, POST, PUT, DELETE (future start dates only)

## Computer Resources
Supports: GET, POST, PUT, DELETE

## Order
Supports: GET, POST, PUT, DELETE

## Product
Supports: GET, POST, PUT, DELETE



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

### DELETE
This method handles DELETE requests for the Customer records. Only requires the ID of the resource/row being deleted

If successful, the object deleted will be returned.
- Example URL:
http://localhost:5000/api/Customer/1



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
This method handles DELETE requests for the ProductCategory records. Only requires the ID of the resource/row being deleted

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
This method handles DELETE requests for the PaymentType records. Only requires the ID of the resource/row being deleted

If successful, the object deleted will be returned.
- Example URL:
http://localhost:5000/api/PaymentType/1

