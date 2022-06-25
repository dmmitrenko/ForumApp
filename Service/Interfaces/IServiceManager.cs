namespace ForumApp.Service.Interfaces;

public interface IServiceManager
{
    IUserService UserService { get; }
    IBlogService BLogService { get; }
}
