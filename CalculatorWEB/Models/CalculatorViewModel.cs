using CalculatorWEB.Models;
using System.Collections.Generic;
public class CalculatorViewModel
{
    public CalculatorModel CalculatorData { get; set; }
    public List<OperationHistoryItem> OperationHistory { get; set; }
}