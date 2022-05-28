﻿namespace Service.Contracts
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IBlogService BLogService { get; }
    }
}
