/*
 * Prelim Activity 01: Codac Logistics Delivery & Fuel Auditor
 * By: Justin Louise Neypes
 *
 * Description:
 * This console-based application tracks a delivery driver's fuel expenses
 * and performance over a 5-day work week. It validates distance input,
 * calculates fuel efficiency, and generates an audit report.
 */

using System;

class Program
{
    static void Main()
    {
        // ================================
        // TASK 1: Driver Profile & Distance Validation
        // ================================

        // string is used for text data like names
        string driverName;

        // decimal is used for money to avoid floating-point rounding errors
        decimal weeklyFuelBudget;

        // double is used for measurements that may contain decimals
        double totalDistance;

        Console.Write("Enter Driver Full Name: ");
        driverName = Console.ReadLine();

        Console.Write("Enter Weekly Fuel Budget: ");
        weeklyFuelBudget = decimal.Parse(Console.ReadLine());

        // Ask for distance first time
        Console.Write("Enter Total Distance Traveled this week (km): ");
        totalDistance = double.Parse(Console.ReadLine());

        // while loop ensures the user keeps entering until valid
        while (totalDistance < 1.0 || totalDistance > 5000.0)
        {
            Console.WriteLine("Error: Distance must be between 1.0 and 5000.0 km.");
            Console.Write("Please re-enter distance: ");
            totalDistance = double.Parse(Console.ReadLine());
        }

        // ================================
        // TASK 2: Fuel Expense Tracking
        // ================================

        // 1D array to store 5 days of fuel expenses
        decimal[] fuelExpenses = new decimal[5];

        // accumulator for total fuel spent
        decimal totalFuelSpent = 0m;

        // for loop is ideal when the number of iterations is known (5 days)
        for (int i = 0; i < fuelExpenses.Length; i++)
        {
            // (i + 1) converts index (0–4) into human-friendly day number (1–5)
            Console.Write($"Enter fuel expense for Day {i + 1}: ");
            fuelExpenses[i] = decimal.Parse(Console.ReadLine());

            // accumulate total
            totalFuelSpent += fuelExpenses[i];
        }

        // ================================
        // TASK 3: Performance Analysis
        // ================================

        // compute average daily fuel expense
        decimal averageDailyExpense = totalFuelSpent / fuelExpenses.Length;

        // compute fuel efficiency
        double efficiency = totalDistance / (double)totalFuelSpent;

        string efficiencyRating;

        // if/else determines efficiency category
        if (efficiency > 15)
        {
            efficiencyRating = "High Efficiency";
        }
        else if (efficiency >= 10)
        {
            efficiencyRating = "Standard Efficiency";
        }
        else
        {
            efficiencyRating = "Low Efficiency / Maintenance Required";
        }

        // bool used to check if spending is within budget
        bool isUnderBudget = totalFuelSpent <= weeklyFuelBudget;

        // ================================
        // TASK 4: Audit Report
        // ================================

        Console.WriteLine("\n===== CODAC LOGISTICS AUDIT REPORT =====");
        Console.WriteLine($"Driver Name: {driverName}");

        Console.WriteLine("\nFuel Expenses (5 Days):");

        // display each day's expense
        for (int i = 0; i < fuelExpenses.Length; i++)
        {
            Console.WriteLine($"Day {i + 1}: {fuelExpenses[i]:C}");
        }

        Console.WriteLine($"\nTotal Fuel Spent: {totalFuelSpent:C}");
        Console.WriteLine($"Average Daily Expense: {averageDailyExpense:C}");
        Console.WriteLine($"Efficiency Rating: {efficiencyRating}");
        Console.WriteLine($"Under Budget: {isUnderBudget}");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}