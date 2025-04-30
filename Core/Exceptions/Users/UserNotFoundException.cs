using Core.Exceptions.Base;
using Core.Exceptions.Consts;

namespace Core.Exceptions.Users;

public class UserNotFoundException(string userId)
    : NotFoundException(ErrorMessages.UserNotFound, userId) { }
