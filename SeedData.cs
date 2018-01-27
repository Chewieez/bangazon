
/*****************************************************************/
/* If seeded data is no longer required this file can be deleted */
/*****************************************************************/

using System;
using System.Linq;
using BangazonAPI.Data;
using BangazonAPI.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BangazonAPI
{
	public static class SeedData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			var context = serviceProvider.GetRequiredService<BangazonAPIContext>();
			
			context.Database.EnsureCreated();
			
			// Seeding Computer Table
			if (!context.Computer.Any())
			{
				context.Computer.Add(new Computer { Name = "Microsoft Surface Laptop", SerialNumber =  "11202", PurchaseDate = Convert.ToDateTime("01/23/2017") });
				context.Computer.Add(new Computer { Name = "Microsoft Surface Laptop", SerialNumber =  "11203", PurchaseDate = Convert.ToDateTime("01/23/2017") });
				context.Computer.Add(new Computer { Name = "Microsoft Surface Laptop", SerialNumber =  "11204", PurchaseDate = Convert.ToDateTime("01/23/2017") });
				context.Computer.Add(new Computer { Name = "Microsoft Surface Laptop", SerialNumber =  "11205", PurchaseDate = Convert.ToDateTime("01/23/2017") });
				context.Computer.Add(new Computer { Name = "Microsoft Surface Laptop", SerialNumber =  "11206", PurchaseDate = Convert.ToDateTime("01/23/2017") });
				context.Computer.Add(new Computer { Name = "Microsoft Surface Laptop", SerialNumber =  "11207", PurchaseDate = Convert.ToDateTime("01/23/2017") });
				context.Computer.Add(new Computer { Name = "Microsoft Surface Laptop", SerialNumber =  "11208", PurchaseDate = Convert.ToDateTime("01/23/2017") });

                context.Computer.Add(new Computer { Name = "Lenovo 720s", SerialNumber =  "98209", PurchaseDate = Convert.ToDateTime("03/11/2017") });
				context.Computer.Add(new Computer { Name = "Lenovo 720s", SerialNumber =  "98210", PurchaseDate = Convert.ToDateTime("03/11/2017") });
				context.Computer.Add(new Computer { Name = "Lenovo 720s", SerialNumber =  "98211", PurchaseDate = Convert.ToDateTime("03/11/2017") });
				context.Computer.Add(new Computer { Name = "Lenovo 720s", SerialNumber =  "98212", PurchaseDate = Convert.ToDateTime("03/11/2017") });
				context.Computer.Add(new Computer { Name = "Lenovo 720s", SerialNumber =  "98213", PurchaseDate = Convert.ToDateTime("03/11/2017") });
				context.Computer.Add(new Computer { Name = "Lenovo 720s", SerialNumber =  "98214", PurchaseDate = Convert.ToDateTime("03/11/2017") });
				context.Computer.Add(new Computer { Name = "Lenovo 720s", SerialNumber =  "98215", PurchaseDate = Convert.ToDateTime("03/11/2017") });
				context.Computer.Add(new Computer { Name = "Lenovo 720s", SerialNumber =  "98216", PurchaseDate = Convert.ToDateTime("03/11/2017") });
				context.Computer.Add(new Computer { Name = "Lenovo 720s", SerialNumber =  "98217", PurchaseDate = Convert.ToDateTime("03/11/2017") });

                context.Computer.Add(new Computer { Name = "Dell Inspiron 7000", SerialNumber =  "33315", PurchaseDate = Convert.ToDateTime("05/21/2017") });
				context.Computer.Add(new Computer { Name = "Dell Inspiron 7000", SerialNumber =  "33316", PurchaseDate = Convert.ToDateTime("05/21/2017") });
				context.Computer.Add(new Computer { Name = "Dell Inspiron 7000", SerialNumber =  "33317", PurchaseDate = Convert.ToDateTime("05/21/2017") });
				context.Computer.Add(new Computer { Name = "Dell Inspiron 7000", SerialNumber =  "33318", PurchaseDate = Convert.ToDateTime("05/21/2017") });
				context.Computer.Add(new Computer { Name = "Dell Inspiron 7000", SerialNumber =  "33319", PurchaseDate = Convert.ToDateTime("05/21/2017") });
				context.Computer.Add(new Computer { Name = "Dell Inspiron 7000", SerialNumber =  "33320", PurchaseDate = Convert.ToDateTime("05/21/2017") });
				
				// this computer is not assigned
				context.Computer.Add(new Computer { Name = "Dell Inspiron 7000", SerialNumber =  "33321", PurchaseDate = Convert.ToDateTime("05/21/2017") });
				
				context.Computer.Add(new Computer { Name = "Dell Inspiron 7000", SerialNumber =  "33322", PurchaseDate = Convert.ToDateTime("05/21/2017") });

                // context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10676", PurchaseDate = Convert.ToDateTime("08/21/2017") });
				// context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10677", PurchaseDate = Convert.ToDateTime("08/21/2017") });
				// context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10678", PurchaseDate = Convert.ToDateTime("08/21/2017") });
				// context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10679", PurchaseDate = Convert.ToDateTime("08/21/2017") });
				// context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10680", PurchaseDate = Convert.ToDateTime("08/21/2017") });
				// context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10681", PurchaseDate = Convert.ToDateTime("08/21/2017") });
				// context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10682", PurchaseDate = Convert.ToDateTime("08/21/2017") });
				// context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10683", PurchaseDate = Convert.ToDateTime("08/21/2017") });
				// context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10684", PurchaseDate = Convert.ToDateTime("08/21/2017") });
				// context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10685", PurchaseDate = Convert.ToDateTime("08/21/2017") });
				// context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10686", PurchaseDate = Convert.ToDateTime("08/21/2017") });
				// context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10687", PurchaseDate = Convert.ToDateTime("08/21/2017") });

				context.SaveChanges();
			}

			// Seeding TrainingProgram Table
			if (!context.TrainingProgram.Any())
			{
				context.TrainingProgram.Add(new TrainingProgram { Name = "AngualarJS Course", StartDate =  Convert.ToDateTime("02/12/2018"), EndDate = Convert.ToDateTime("02/16/2017"), MaxAttendance = 25 });
                context.TrainingProgram.Add(new TrainingProgram { Name = "IT Security Training", StartDate =  Convert.ToDateTime("03/19/2017"), EndDate = Convert.ToDateTime("03/23/2017"), MaxAttendance = 25 });
                context.TrainingProgram.Add(new TrainingProgram { Name = "Operating Systems Concepts", StartDate =  Convert.ToDateTime("02/26/2017"), EndDate = Convert.ToDateTime("03/02/2017"), MaxAttendance = 25 });
                context.TrainingProgram.Add(new TrainingProgram { Name = "Systems Architecture", StartDate =  Convert.ToDateTime("04/16/2017"), EndDate = Convert.ToDateTime("04/20/2017"), MaxAttendance = 25 });
				context.TrainingProgram.Add(new TrainingProgram { Name = "Business Analysis", StartDate =  Convert.ToDateTime("04/16/2017"), EndDate = Convert.ToDateTime("04/20/2017"), MaxAttendance = 25 });
				context.TrainingProgram.Add(new TrainingProgram { Name = "Project Management", StartDate =  Convert.ToDateTime("04/16/2017"), EndDate = Convert.ToDateTime("04/20/2017"), MaxAttendance = 25 });
				context.SaveChanges();
			}

			// Seeding Department Table
			if (!context.Department.Any())
			{
				context.Department.Add(new Department { Name = "IT", ExpenseBudget =  899000 });
                context.Department.Add(new Department { Name = "Admin", ExpenseBudget =  500000 });
                context.Department.Add(new Department { Name = "Human Resources", ExpenseBudget =  650000 });
                context.Department.Add(new Department { Name = "Engineering", ExpenseBudget =  1200000 });
				context.SaveChanges();
			}

			// Seeding Employee Table
			if (!context.Employee.Any())
			{
				// IT Department
				var deptEntityQueryable = from b in context.Department 
                   where b.Name.Equals("IT") 
                   select b.DepartmentId;

				// parsing the integer value of the department id from the Entity Queryable object
				int deptId = int.Parse(deptEntityQueryable.FirstOrDefault().ToString());

				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Kenneth", LastName = "Allen", StartDate = Convert.ToDateTime("06/11/2017"), Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "John", LastName = "Smith", StartDate = Convert.ToDateTime("04/03/2017"), Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Jane", LastName = "Doe", StartDate = Convert.ToDateTime("04/23/2017"), Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Dan", LastName = "Williams", StartDate = Convert.ToDateTime("11/23/2016"), Supervisor = true });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Ben", LastName = "Taylor", StartDate = Convert.ToDateTime("04/15/2017"), Supervisor = false });

				// Admin Department
				deptEntityQueryable = from b in context.Department 
                   where b.Name.Equals("Admin") 
                   select b.DepartmentId;

				deptId = int.Parse(deptEntityQueryable.FirstOrDefault().ToString());
                
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Maria", LastName = "Guerrera", StartDate = Convert.ToDateTime("06/26/2017"), Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Justin", LastName = "Johnson", StartDate = Convert.ToDateTime("11/27/2016"), Supervisor = true });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Michelle", LastName = "Nyuen", StartDate = Convert.ToDateTime("04/13/2017"), Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Henry", LastName = "Mall", StartDate = Convert.ToDateTime("06/09/2017"), Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "George", LastName = "Davidson", StartDate = Convert.ToDateTime("04/14/2017"), Supervisor = false });

				// Engineering Deparment
				deptEntityQueryable = from b in context.Department 
                   where b.Name.Equals("Engineering") 
                   select b.DepartmentId;

				deptId = int.Parse(deptEntityQueryable.FirstOrDefault().ToString());
                
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Dave", LastName = "Blazen", StartDate = Convert.ToDateTime("04/27/2017"), Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Frank", LastName = "Dolton", StartDate = Convert.ToDateTime("11/15/2016"), Supervisor = true });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Michael", LastName = "Yu", StartDate = Convert.ToDateTime("06/29/2017"), Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Teresa", LastName = "Evans", StartDate = Convert.ToDateTime("06/01/2017"), Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Susan", LastName = "Lee", StartDate = Convert.ToDateTime("04/02/2017"), Supervisor = false });

				// Human Resources Department
				deptEntityQueryable = from b in context.Department 
                   where b.Name.Equals("Human Resources") 
                   select b.DepartmentId;

				deptId = int.Parse(deptEntityQueryable.FirstOrDefault().ToString());
                
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Richard", LastName = "Leinecker", StartDate = Convert.ToDateTime("06/24/2017"), Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Mark", LastName = "Llewelyn", StartDate = Convert.ToDateTime("11/21/2016"), Supervisor = true });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Sarah", LastName = "Angell", StartDate = Convert.ToDateTime("04/30/2017"), Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Victor", LastName = "Richardson", StartDate = Convert.ToDateTime("04/07/2017"), Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Jose", LastName = "Campos", StartDate = Convert.ToDateTime("06/10/2017"), Supervisor = false });

				context.SaveChanges();
			}

			// Seeding ComputerEmployee Table
			if (!context.ComputerEmployee.Any())
			{
				int employeeId = (from e in context.Employee 
                   where e.LastName.Equals("Allen") && e.FirstName.Equals("Kenneth")  
                   select e.EmployeeId).Single();

				int computerId = (from c in context.Computer 
                   where c.SerialNumber.Equals("33315")
                   select c.ComputerId).Single();

				// employeeId, computerId, dateAssigned, dateRemoved
				context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("06/11/2017") });

				employeeId = (from e in context.Employee
                   where e.LastName.Equals("Smith") && e.FirstName.Equals("John")  
                   select e.EmployeeId).Single();

				computerId = (from c in context.Computer 
                   where c.SerialNumber.Equals("98210")
                   select c.ComputerId).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("04/03/2017") });

				employeeId = (from e in context.Employee
                   where e.LastName.Equals("Doe") && e.FirstName.Equals("Jane")  
                   select e.EmployeeId).Single();

				computerId = (from c in context.Computer 
                   where c.SerialNumber.Equals("98214")
                   select c.ComputerId).Single();

				context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("04/23/2017") });

				employeeId = (from e in context.Employee
                   where e.LastName.Equals("Williams") && e.FirstName.Equals("Dan")  
                   select e.EmployeeId).Single();

				computerId = (from c in context.Computer 
                   where c.SerialNumber.Equals("11205")
                   select c.ComputerId).Single();

				context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("01/31/2017") });

				employeeId = (from e in context.Employee
                   where e.LastName.Equals("Taylor") && e.FirstName.Equals("Ben")  
                   select e.EmployeeId).Single();

				computerId = (from c in context.Computer 
                   where c.SerialNumber.Equals("98213")
                   select c.ComputerId).Single();

				context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("04/15/2017") });

				employeeId = (from e in context.Employee
                   where e.LastName.Equals("Guerrera") && e.FirstName.Equals("Maria")  
                   select e.EmployeeId).Single();

				computerId = (from c in context.Computer 
                   where c.SerialNumber.Equals("33319")
                   select c.ComputerId).Single();

				context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("06/26/2017") });

				employeeId = (from e in context.Employee
                   where e.LastName.Equals("Johnson") && e.FirstName.Equals("Justin")  
                   select e.EmployeeId).Single();

				computerId = (from c in context.Computer 
                   where c.SerialNumber.Equals("11208")
                   select c.ComputerId).Single();

				context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("01/31/2017") });

				employeeId = (from e in context.Employee
                   where e.LastName.Equals("Nyuen") && e.FirstName.Equals("Michelle")  
                   select e.EmployeeId).Single();

				computerId = (from c in context.Computer 
                   where c.SerialNumber.Equals("98209")
                   select c.ComputerId).Single();

				context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("04/13/2017") });

				employeeId = (from e in context.Employee
                   where e.LastName.Equals("Mall") && e.FirstName.Equals("Henry")  
                   select e.EmployeeId).Single();

				computerId = (from c in context.Computer 
                   where c.SerialNumber.Equals("33316")
                   select c.ComputerId).Single();

				context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("06/09/2017") });

				employeeId = (from e in context.Employee
                   where e.LastName.Equals("Davidson") && e.FirstName.Equals("George")  
                   select e.EmployeeId).Single();

				computerId = (from c in context.Computer 
                   where c.SerialNumber.Equals("98211")
                   select c.ComputerId).Single();

				context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("04/14/2017") });

				employeeId = (from e in context.Employee
                   where e.LastName.Equals("Blazen") && e.FirstName.Equals("Dave")  
                   select e.EmployeeId).Single();

				computerId = (from c in context.Computer 
                   where c.SerialNumber.Equals("98212")
                   select c.ComputerId).Single();

				context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("04/27/2017") });

				employeeId = (from e in context.Employee
                   where e.LastName.Equals("Dolton") && e.FirstName.Equals("Frank")  
                   select e.EmployeeId).Single();

				computerId = (from c in context.Computer 
                   where c.SerialNumber.Equals("11202")
                   select c.ComputerId).Single();

				context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("01/31/2017") });

				employeeId = (from e in context.Employee
                   where e.LastName.Equals("Yu") && e.FirstName.Equals("Michael")  
                   select e.EmployeeId).Single();

				computerId = (from c in context.Computer 
                   where c.SerialNumber.Equals("33320")
                   select c.ComputerId).Single();

				context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("06/29/2017") });

				employeeId = (from e in context.Employee
                   where e.LastName.Equals("Evans") && e.FirstName.Equals("Teresa")  
                   select e.EmployeeId).Single();

				computerId = (from c in context.Computer 
                   where c.SerialNumber.Equals("33317")
                   select c.ComputerId).Single();

				context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("06/01/2017") });

				employeeId = (from e in context.Employee
                   where e.LastName.Equals("Lee") && e.FirstName.Equals("Susan")  
                   select e.EmployeeId).Single();

				computerId = (from c in context.Computer 
                   where c.SerialNumber.Equals("98216")
                   select c.ComputerId).Single();

				context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("04/02/2017") });

				employeeId = (from e in context.Employee
                   where e.LastName.Equals("Leinecker") && e.FirstName.Equals("Richard")  
                   select e.EmployeeId).Single();

				computerId = (from c in context.Computer 
                   where c.SerialNumber.Equals("33322")
                   select c.ComputerId).Single();

				context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("06/24/2017") });

				employeeId = (from e in context.Employee
                   where e.LastName.Equals("Llewelyn") && e.FirstName.Equals("Mark")  
                   select e.EmployeeId).Single();

				computerId = (from c in context.Computer 
                   where c.SerialNumber.Equals("11203")
                   select c.ComputerId).Single();

				context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("01/31/2017") });

				employeeId = (from e in context.Employee
                   where e.LastName.Equals("Angell") && e.FirstName.Equals("Sarah")  
                   select e.EmployeeId).Single();

				computerId = (from c in context.Computer 
                   where c.SerialNumber.Equals("98217")
                   select c.ComputerId).Single();

				context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("04/30/2017") });

				employeeId = (from e in context.Employee
                   where e.LastName.Equals("Richardson") && e.FirstName.Equals("Victor")  
                   select e.EmployeeId).Single();

				computerId = (from c in context.Computer 
                   where c.SerialNumber.Equals("98215")
                   select c.ComputerId).Single();				

				context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("04/07/2017") });

				employeeId = (from e in context.Employee
                   where e.LastName.Equals("Campos") && e.FirstName.Equals("Jose")
                   select e.EmployeeId).Single();

				computerId = (from c in context.Computer 
                   where c.SerialNumber.Equals("33318")
                   select c.ComputerId).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("06/10/2017") });

				// employeeId = (from e in context.Employee
                //    where e.LastName.Equals("Smith") && e.FirstName.Equals("John")  
                //    select e.EmployeeId).Single();

				// computerId = (from c in context.Computer 
                //    where c.SerialNumber.Equals("33319")
                //    select c.ComputerId).Single();

				// context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("10/23/2017") });

				// employeeId = (from e in context.Employee
                //    where e.LastName.Equals("Smith") && e.FirstName.Equals("John")  
                //    select e.EmployeeId).Single();

				// computerId = (from c in context.Computer 
                //    where c.SerialNumber.Equals("33320")
                //    select c.ComputerId).Single();

				// context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("10/23/2017") });

				// employeeId = (from e in context.Employee
                //    where e.LastName.Equals("Smith") && e.FirstName.Equals("John")  
                //    select e.EmployeeId).Single();

				// computerId = (from c in context.Computer 
                //    where c.SerialNumber.Equals("33321")
                //    select c.ComputerId).Single();

				// context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("10/23/2017") });

				// employeeId = (from e in context.Employee
                //    where e.LastName.Equals("Smith") && e.FirstName.Equals("John")  
                //    select e.EmployeeId).Single();

				// computerId = (from c in context.Computer 
                //    where c.SerialNumber.Equals("33322")
                //    select c.ComputerId).Single();

				// context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("10/23/2017") });

				// employeeId = (from e in context.Employee
                //    where e.LastName.Equals("Smith") && e.FirstName.Equals("John")  
                //    select e.EmployeeId).Single();

				// computerId = (from c in context.Computer 
                //    where c.SerialNumber.Equals("10676")
                //    select c.ComputerId).Single();

				// context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("10/23/2017") });

				// employeeId = (from e in context.Employee
                //    where e.LastName.Equals("Smith") && e.FirstName.Equals("John")  
                //    select e.EmployeeId).Single();

				// computerId = (from c in context.Computer 
                //    where c.SerialNumber.Equals("10677")
                //    select c.ComputerId).Single();

				// context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("10/23/2017") });

				// employeeId = (from e in context.Employee
                //    where e.LastName.Equals("Smith") && e.FirstName.Equals("John")  
                //    select e.EmployeeId).Single();

				// computerId = (from c in context.Computer 
                //    where c.SerialNumber.Equals("10678")
                //    select c.ComputerId).Single();

				// context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("10/23/2017") });
				
				// context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("10/23/2017") });
				// context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("10/23/2017") });
				// context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("10/23/2017") });
				// context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("10/23/2017") });
				// context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("10/23/2017") });
				// context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("10/23/2017") });
				// context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("10/23/2017") });
				// context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("10/23/2017") });
				// context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId, DateAssigned = Convert.ToDateTime("10/23/2017") });
				
				context.SaveChanges();
			}

			// Seeding TrainingEmployee Table
			if (!context.TrainingEmployee.Any())
			{
				int trainingProgramId = (from tp in context.TrainingProgram 
                   where tp.Name.Equals("IT Security Training")
                   select tp.TrainingProgramId).Single();

				var employees = context.Employee;

				foreach (var e in employees)
				{
					context.TrainingEmployee.Add(new TrainingEmployee { TrainingProgramId = trainingProgramId, EmployeeId = e.EmployeeId });	
				}

				trainingProgramId = (from tp in context.TrainingProgram 
                   where tp.Name.Equals("Project Management")
                   select tp.TrainingProgramId).Single();

				foreach (var e in employees)
				{
					if(e.Supervisor)
					{
						context.TrainingEmployee.Add(new TrainingEmployee { TrainingProgramId = trainingProgramId, EmployeeId = e.EmployeeId });
					}
				}

				trainingProgramId = (from tp in context.TrainingProgram 
                   where tp.Name.Equals("Business Analysis")
                   select tp.TrainingProgramId).Single();

				int departmentId = (from d in context.Department 
                   where d.Name.Equals("Human Resources")
                   select d.DepartmentId).Single();

				foreach (var e in employees)
				{
					
					if(e.DepartmentId == departmentId)
					{
						context.TrainingEmployee.Add(new TrainingEmployee { TrainingProgramId = trainingProgramId, EmployeeId = e.EmployeeId });
					}
				}

				// angular
				trainingProgramId = (from tp in context.TrainingProgram 
                   where tp.Name.Equals("AngualarJS Course")
                   select tp.TrainingProgramId).Single();

				departmentId = (from d in context.Department 
                   where d.Name.Equals("IT")
                   select d.DepartmentId).Single();

				foreach (var e in employees)
				{
					
					if(e.DepartmentId == departmentId)
					{
						context.TrainingEmployee.Add(new TrainingEmployee { TrainingProgramId = trainingProgramId, EmployeeId = e.EmployeeId });
					}
				}

				// operating systems
				trainingProgramId = (from tp in context.TrainingProgram 
                   where tp.Name.Equals("Operating Systems Concepts")
                   select tp.TrainingProgramId).Single();

				foreach (var e in employees)
				{
					
					if(e.DepartmentId == departmentId)
					{
						context.TrainingEmployee.Add(new TrainingEmployee { TrainingProgramId = trainingProgramId, EmployeeId = e.EmployeeId });
					}
				}

				// architecture
				trainingProgramId = (from tp in context.TrainingProgram 
                   where tp.Name.Equals("Systems Architecture")
                   select tp.TrainingProgramId).Single();

				foreach (var e in employees)
				{
					
					if(e.DepartmentId == departmentId)
					{
						context.TrainingEmployee.Add(new TrainingEmployee { TrainingProgramId = trainingProgramId, EmployeeId = e.EmployeeId });
					}
				}

                
				context.SaveChanges();
			}
		}
	}
}