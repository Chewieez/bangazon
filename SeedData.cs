
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
				context.Computer.Add(new Computer { Name = "Microsoft Surface Laptop", SerialNumber =  "11202", PurchaseDate = DateTime.Now });
                context.Computer.Add(new Computer { Name = "Lenovo 720s", SerialNumber =  "98203", PurchaseDate = DateTime.Now });
                context.Computer.Add(new Computer { Name = "Dell Inspiron 7000", SerialNumber =  "33315", PurchaseDate = DateTime.Now });
                context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10675", PurchaseDate = DateTime.Now });
				context.SaveChanges();
			}

			// Seeding TrainingProgram Table
			if (!context.TrainingProgram.Any())
			{
				context.TrainingProgram.Add(new TrainingProgram { Name = "AngualarJS Crash Course", StartDate =  DateTime.Now, EndDate = DateTime.Now, MaxAttendance = 35 });
                context.TrainingProgram.Add(new TrainingProgram { Name = "IT Security Training", StartDate =  DateTime.Now, EndDate = DateTime.Now, MaxAttendance = 125 });
                context.TrainingProgram.Add(new TrainingProgram { Name = "Operating Systems Concepts", StartDate =  DateTime.Now, EndDate = DateTime.Now, MaxAttendance = 120 });
                context.TrainingProgram.Add(new TrainingProgram { Name = "Systems Architecture", StartDate =  DateTime.Now, EndDate = DateTime.Now, MaxAttendance = 120 });
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

				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Kenneth", LastName = "Allen", StartDate = DateTime.Now, Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "John", LastName = "Smith", StartDate = DateTime.Now, Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Jane", LastName = "Doe", StartDate = DateTime.Now, Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Dan", LastName = "Williams", StartDate = DateTime.Now, Supervisor = true });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Ben", LastName = "Taylor", StartDate = DateTime.Now, Supervisor = false });

				// Admin Department
				deptEntityQueryable = from b in context.Department 
                   where b.Name.Equals("Admin") 
                   select b.DepartmentId;

				deptId = int.Parse(deptEntityQueryable.FirstOrDefault().ToString());
                
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Maria", LastName = "Guerrera", StartDate = DateTime.Now, Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Justin", LastName = "Johnson", StartDate = DateTime.Now, Supervisor = true });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Michelle", LastName = "Nyuen", StartDate = DateTime.Now, Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Henry", LastName = "Mall", StartDate = DateTime.Now, Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "George", LastName = "Davidson", StartDate = DateTime.Now, Supervisor = false });

				// Engineering Deparment
				deptEntityQueryable = from b in context.Department 
                   where b.Name.Equals("Engineering") 
                   select b.DepartmentId;

				deptId = int.Parse(deptEntityQueryable.FirstOrDefault().ToString());
                
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Dave", LastName = "Blazen", StartDate = DateTime.Now, Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Frank", LastName = "Dolton", StartDate = DateTime.Now, Supervisor = true });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Michael", LastName = "Yu", StartDate = DateTime.Now, Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Teresa", LastName = "Evans", StartDate = DateTime.Now, Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Susan", LastName = "Lee", StartDate = DateTime.Now, Supervisor = false });

				// Human Resources Department
				deptEntityQueryable = from b in context.Department 
                   where b.Name.Equals("Human Resources") 
                   select b.DepartmentId;

				deptId = int.Parse(deptEntityQueryable.FirstOrDefault().ToString());
                
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Richard", LastName = "Leinecker", StartDate = DateTime.Now, Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Mark", LastName = "Llewelyn", StartDate = DateTime.Now, Supervisor = true });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Sarah", LastName = "Angell", StartDate = DateTime.Now, Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Victor", LastName = "Richardson", StartDate = DateTime.Now, Supervisor = false });
				context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Jose", LastName = "Campos", StartDate = DateTime.Now, Supervisor = false });

				context.SaveChanges();
			}

			// Seeding ComputerEmployee Table
			// if (!context.ComputerEmployee.Any())
			// {
			// 	context.ComputerEmployee.Add(new ComputerEmployee { Name = "IT", ExpenseBudget =  899000 });
            //     context.ComputerEmployee.Add(new ComputerEmployee { Name = "Admin", ExpenseBudget =  500000 });
            //     context.ComputerEmployee.Add(new ComputerEmployee { Name = "Human Resources", ExpenseBudget =  650000 });
            //     context.ComputerEmployee.Add(new ComputerEmployee { Name = "Engineering", ExpenseBudget =  1200000 });
			// 	context.SaveChanges();
			// }
		}
	}
}