using Microsoft.AspNetCore.Mvc;
using System;
using CalculatorWEB.Models;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var model = new CalculatorModel();
        return View(model);
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

        return View("Index", model);
    }

    private double CalculateFactorial(int n)
    {
        if (n < 0)
            return 0;
        if (n == 0)
            return 1;

       return CalculateFactorial(n-1)*n;
    }

    private double CalculateFibonacci(int n)
    {
        if (n < 0)
            return 0;

        if (n == 0)
            return 0;
        if (n == 1)
            return 1;


        return CalculateFibonacci(n-1)+CalculateFibonacci(n-2);
    }
}
