using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LoginSystemManagement.DTOs.Request;
using LoginSystemManagement.DTOs.Response;
using LoginSystemManagement.Entity;
using LoginSystemManagement.IRepository;
using LoginSystemManagement.IServices;
using Microsoft.IdentityModel.Tokens;

namespace LoginSystemManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<UserResponse> UserRegister(UserRequest userRequest)
        {
            var users = new User
            {
                Name = userRequest.Name,
                Password = BCrypt.Net.BCrypt.HashPassword(userRequest.Password),
                UserRole = userRequest.UserRole
            };
        
            var data = await _userRepository.UserRegister(users);

            var response = new UserResponse
            {
                Id= users.Id,
                Name = users.Name,
                UserRole = users.UserRole

            };
            return response;
        }

        
        public async Task<LoginResponse> UserLogin(LoginRequest loginRequest)
        {
            var user = await _userRepository.GetUserName(loginRequest.Name);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var passwordMatch = BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password);
            if (!passwordMatch)
            {
                throw new Exception("Invalid password");
            }

            var token = CreateToken(user);

            return token;

        }

        public LoginResponse CreateToken(User user)
        {
            var claimlist = new List<Claim>();
            claimlist.Add(new Claim("Name", user.Name));
            claimlist.Add(new Claim("Password", user.Password));
            claimlist.Add(new Claim("UserRole", user.UserRole.ToString()));

            var Key = _configuration["Jwt:Key"];
            var secKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
            var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256);


            var togen = new JwtSecurityToken(
                 issuer: _configuration["Jwt:Issuer"],
                 audience: _configuration["Jwt:Audience"],
                 claims: claimlist,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credentials
                );

            var res = new LoginResponse();
            res.Token = new JwtSecurityTokenHandler().WriteToken(togen);
            return res;
        }


        public async Task<List<UserResponse>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return users.Select(u => new UserResponse
            {
                Id = u.Id,
                Name = u.Name,
                UserRole = u.UserRole
            }).ToList();
        }


    }
}
