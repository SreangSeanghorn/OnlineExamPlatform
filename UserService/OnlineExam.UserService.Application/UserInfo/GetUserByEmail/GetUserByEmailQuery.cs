

using OnlineExam.UserService.Application.Shared.Queries;

namespace OnlineExam.Application;

public class GetUserByEmailQuery : IQuery<GetUserInfoByEmailResponseDTO>
{
    public string Email { get; set; }

    public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
}

