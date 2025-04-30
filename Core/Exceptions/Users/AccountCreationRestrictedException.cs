using Core.Exceptions.Base;
using Core.Exceptions.Consts;

namespace Core.Exceptions.Users;

public class AccountCreationRestrictedException(string userId)
    : NotFoundException(ErrorMessages.AccountCreationRestricted, userId) { }
