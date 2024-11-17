using BackendTodoList;
using BackendTodoList.Dtos;
using BackendTodoList.Model;
using Microsoft.EntityFrameworkCore;

namespace ToDoListApp.Services
{
    public class UserService : IUserService
    {
        private readonly DBContext _context;

        public UserService(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _context.Users.Include(u => u.Tasks).ToListAsync();
            return users.Select(u => new UserDto { id = u.id, username = u.username! });
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.Include(u => u.Tasks).FirstOrDefaultAsync(u => u.id == id);
            return new UserDto { id = user.id, username = user.username! };
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            var user = new User { username = userDto.username };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            userDto.id = user.id;
            return userDto;
        }
    }
}
