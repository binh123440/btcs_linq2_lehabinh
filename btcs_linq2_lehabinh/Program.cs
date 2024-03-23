using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public class Department
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Position
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Department Department { get; set; }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Position Position { get; set; }
    }

    public static void Main(string[] args)
    {
        // Tạo danh sách phòng ban
        var departments = new List<Department>
        {
            new Department { Name = "IT", Description = "Information Technology Department" },
            new Department { Name = "HR", Description = "Human Resources Department" }
        };

        // Tạo danh sách vị trí công việc
        var positions = new List<Position>
        {
            new Position { Name = "SE", Description = "Develop software applications", Department = departments[0] },
            new Position { Name = "HRM", Description = "Manage human resources activities", Department = departments[1] }
        };

        // Tạo danh sách nhân viên
        var employees = new List<Employee>
        {
            new Employee { Name = "lehabinh", Age = 30, Position = positions[0] },
            new Employee { Name = "lekimnam", Age = 35, Position = positions[1] }
        };

        // Nhập thông tin tìm kiếm từ người dùng
        Console.Write("Insert employee information: ");
        Console.Write("Age from (min Age): ");
        int minAge = int.Parse(Console.ReadLine());
        Console.Write("to Age (max Age): ");
        int maxAge = int.Parse(Console.ReadLine());
        Console.Write("Position: ");
        string positionKeyword = Console.ReadLine();
        Console.Write("Department: ");
        string departmentKeyword = Console.ReadLine();

        // Sử dụng LINQ để tìm kiếm và lọc kết quả
        var searchResults = employees.Where(e =>
            e.Age >= minAge &&
            e.Age <= maxAge &&
            (e.Position.Name.Contains(positionKeyword) || e.Position.Description.Contains(positionKeyword)) &&
            (e.Position.Department.Name.Contains(departmentKeyword) || e.Position.Department.Description.Contains(departmentKeyword)));
        // In ra kết quả
        Console.WriteLine("\nSearching Result :");
        foreach (var employee in searchResults)
        {
            Console.WriteLine($"Name: {employee.Name}, Age: {employee.Age}, Position: {employee.Position.Name}, Department: {employee.Position.Department.Name}");
        }
    }
}
