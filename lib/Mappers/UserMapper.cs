using dtos.user;
using models;

namespace Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };
        }

        public static User ToUser(this CreateUserDto dto)
        {
            return new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = dto.Password // TODO: Hash password
            };
        }
    }
}