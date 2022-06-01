using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DTO;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public UserService(IRepositoryManager repository, ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public UserDto CreateUser(UserForCreationDto user)
        {
            var userEntity = _mapper.Map<User>(user);

            _repository.Users.CreateUser(userEntity);
            _repository.Save();

            var userToReturn = _mapper.Map<UserDto>(userEntity);

            return userToReturn;
        }

        public IEnumerable<UserDto> GetAllUsers(bool trackChanges)
        {
            var users = _repository.Users.GetAllUsers(trackChanges);

            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

            return usersDto;
        }

        public IEnumerable<UserDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var userEntities = _repository.Users.GetByIds(ids, trackChanges);
            if (ids.Count() != userEntities.Count())
                throw new CollectionByIdsBadRequestException();

            var usersToReturn = _mapper.Map<IEnumerable<UserDto>>(userEntities);
            
            return usersToReturn;    
        }

        public UserDto GetUser(Guid id, bool trackChanges)
        {
            var user = _repository.Users.GetUser(id, trackChanges);

            if (user is null)
                throw new UserNotFoundException(id);

            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
