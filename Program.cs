﻿using System;
using system_payment.Entities;
using system_payment.Entities.Enums;
using System.Globalization;
namespace system_payment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string dptName = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        
            Department dpt = new Department(dptName);
            Worker worker = new Worker(name, level, salary, dpt);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++){
                Console.Write($"Enter #{i} contract data:");
                Console.Write("Date  (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hour = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, value, hour);
                worker.AddContract(contract);
            }

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthYear = Console.ReadLine();
            int month = int.Parse(monthYear.Substring(0, 2));
            int year = int.Parse(monthYear.Substring(3));
            
            double totalSalary = worker.Income(year, month);

            Console.Write("Name: " + worker.Name);
            Console.Write("\nDepartment: " + worker.Department.Name);
            Console.Write("\nIncome for: " + monthYear + ": " + totalSalary.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
