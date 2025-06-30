namespace WebApplication.Application.Common.Results
{
    [Flags]
    public enum Status
    {
        Ok,
        Created,
        Accepted,
        NoContent,
        Error,
        Conflict,
        Forbiden,
        Validation,
        Common,
        NotFound,
        ServerError,
        BadRequest,
    }

    public class Result
    {
        public bool IsSuccess { get; set; }
        public bool IsFailure { get => !IsSuccess; }
        public string? Message { get; set; }
        public Status Status { get; set; }

        public static Result<T> Success<T>(T value, string message = "Success", Status status = Status.Ok)
            => new() { Value = value, IsSuccess = true, Message = message, Status = status };

        public static Result Success(string message = "Success", Status status = Status.Ok)
            => new() { IsSuccess = true, Message = message, Status = status };

        public static Result<T> Failure<T>(string message = "Failure", Status status = Status.Error)
            => new() { IsSuccess = false, Message = message, Status = status };

        public static Result Failure(string message = "Failure", Status status = Status.Error)
            => new() { IsSuccess = false, Message = message, Status = status };

    }

    public class Result<T> : Result
    {
        public T? Value { get; set; }

    }
}
