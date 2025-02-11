using LoginSystemManagement.DTOs.Request;
using LoginSystemManagement.DTOs.Response;

namespace LoginSystemManagement.IServices
{
    public interface IUserService
    {
        Task<UserResponse> UserRegister(UserRequest userRequest);
        Task<LoginResponse> UserLogin(LoginRequest loginRequest);
        Task<List<UserResponse>> GetAllUsers();
    }
}
