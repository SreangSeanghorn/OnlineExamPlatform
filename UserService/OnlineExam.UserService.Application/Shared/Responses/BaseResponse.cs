using System;

namespace OnlineExam.UserService.Application.Shared.Responses
{
    public record BaseResponse<T>(bool IsSuccess, int Status,string Message, T Data);
}
