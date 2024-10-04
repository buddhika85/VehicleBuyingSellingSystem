namespace DTOs;

public class ResultDto
{
    public required string FunctionPerformed { get; set; }
    public string? ErrorMessage { get; set; }
    public bool IsSuccess => string.IsNullOrWhiteSpace(ErrorMessage);
}
