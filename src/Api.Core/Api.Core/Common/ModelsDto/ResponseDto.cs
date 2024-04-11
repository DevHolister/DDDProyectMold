using System.Text.Json.Serialization;

namespace Api.Core.Common.ModelsDto;

public class ResponseDto<T>
{
    public ResponseDto()
    {
        Errors = new List<string>();
        Success = true;
    }
    public ResponseDto(T data, string message = "")
    {
        Data = data;
        Message = message;
        Code = StatusCode.OK;
        Errors = new List<string>();
        Success = true;
    }
    public ResponseDto(string message, StatusCode code)
    {
        Success = false;
        Message = message;
        Code = code;
        Errors = new List<string>();
    }
    public void SetMessage(string message)
    {
        Success = false;
        Message = message;
    }
    public void SetStatusError(string message, StatusCode status)
    {
        Success = false;
        Message = message;
        Code = status;
    }
    public void SetErrors(List<string> errors)
    {
        Errors = errors;
    }
    public void AddError(string error)
    {
        Errors.Add(error);
        Success = false;
    }
    public void SetData(T data, StatusCode status)
    {
        Data = data;
        Code = status;
    }
    public void SetStatusCode(StatusCode status)
    {
        Code = status;
    }

    [JsonIgnore]
    public StatusCode Code { get; set; }
    public bool Success { get; set; }
    public string? Message { get; set; }
    public List<string> Errors { get; set; }
    public T? Data { get; set; }
}
