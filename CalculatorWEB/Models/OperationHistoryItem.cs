using System;
public class OperationHistoryItem
{
    public int Id { get; set; }
    public string OperationType { get; set; }
    public string FirstNumber { get; set; }
    public string SecondNumber { get; set; }
    public string Result { get; set; }
    public DateTime Timestamp { get; set; }
}