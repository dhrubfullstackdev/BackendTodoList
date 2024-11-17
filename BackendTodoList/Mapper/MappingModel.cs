using AutoMapper;
using BackendTodoList.Dtos;
using BackendTodoList.Model;

public class MappingModel : Profile
{
    public MappingModel()
    {
        // Map User DTOs
        CreateMap<UserDto, User>();
        CreateMap<User, UserDto>();
        CreateMap<TaskDto, Tasks>();
        CreateMap<Tasks, TaskDto>();
        CreateMap<CategoryDto,Category>();
        CreateMap<Category, CategoryDto>();
    }
}
