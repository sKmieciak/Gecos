using Microsoft.AspNetCore.Mvc;
using System;
using CalculatorWEB.Models;
using System.Collections.Generic;

public class HomeController : Controller
{
    private static List<OperationHistoryItem> operationHistory = new List<OperationHistoryItem>();

    public IActionResult Index()
    {
        var calculatorData = new CalculatorModel();
        var operationHistory = new List<OperationHistoryItem>();
        var viewModel = new CalculatorViewModel
        {
            CalculatorData = calculatorData,
            OperationHistory = operationHistory
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Calculate(CalculatorModel model)
    {
        switch (model.Operation)
        {
            case "Add":
                model.Result = model.FirstNumber + model.SecondNumber;
                break;
            case "Subtract":
                model.Result = model.FirstNumber - model.SecondNumber;
                break;
            case "Multiply":
                model.Result = model.FirstNumber * model.SecondNumber;
                break;
            case "Divide":
                model.Result = model.SecondNumber != 0 ? model.FirstNumber / model.SecondNumber : double.NaN;
                break;
            case "Factorial":
                model.Result = CalculateFactorial((int)model.FirstNumber);
                break;
            case "Fibonacci":
                model.Result = CalculateFibonacci((int)model.FirstNumber);
                break;
            default:
                model.Result = double.NaN;
                break;
        }

        var operationHistoryItem = new OperationHistoryItem
        {
            OperationType = model.Operation,
            FirstNumber = model.FirstNumber.ToString(),
            SecondNumber = CheckSecondNumber(model),
            Result = model.Result.ToString(),
            Timestamp = DateTime.Now
        };
        var viewModel = new CalculatorViewModel
        {
            CalculatorData = model,
            OperationHistory = operationHistory
        };
        viewModel.OperationHistory.Add(operationHistoryItem);

        return View("Index", viewModel);
    }

    private double CalculateFactorial(int n)
    {
        if (n < 0)
            return 0;
        if (n == 0)
            return 1;

        return CalculateFactorial(n - 1) * n;
    }

    private double CalculateFibonacci(int n)
    {
        if (n < 0)
            return 0;

        if (n == 0)
            return 0;
        if (n == 1)
            return 1;


        return CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
    }
    private string CheckSecondNumber(CalculatorModel model)
    {
        if (model.Operation == "Factorial" || model.Operation == "Fibonacci")
        {
            return "";
        }
        return model.SecondNumber.ToString();

    }
}
