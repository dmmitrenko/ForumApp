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

        public (IEnumerable<UserDto> users, string ids) CreateUserCollection
            (IEnumerable<UserForCreationDto> userCollection)
        {
            if (userCollection is null)
                throw new UserCollectionBadRequest();

            var userEntities = _mapper.Map<IEnumerable<User>>(userCollection);
            foreach (var user in userEntities)
            {
                _repository.Users.CreateUser(user);
            }

            _repository.Save();

            var userCollectionToReturn = _mapper.Map<IEnumerable<UserDto>>(userEntities);
            var ids = string.Join(",", userCollectionToReturn.Select(u => u.Id));

            return (users: userCollectionToReturn, ids: ids);
        }

        public void DeleteUser(Guid userId, bool trackChanges)
        {
            var user = _repository.Users.GetUser(userId, trackChanges);
            if (user is null)
                throw new UserNotFoundException(userId);

            _repository.Users.DeleteUser(user);
            _repository.Save();
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

        public void UpdateUser(Guid userId, UserForUpdateDto userForUpdate, bool trackChanges)
        {
            var userEntity = _repository.Users.GetUser(userId, trackChanges);
            if (userEntity is null)
                throw new UserNotFoundException(userId);

            _mapper.Map(userForUpdate, userEntity);
            _repository.Save();
        }
    }
}
