namespace Application.DTOs.Common;


public class ApiErrorResponse
{
    public int Status { get; set; }
    public string Message { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string ErrorType { get; set; } = string.Empty;
}
