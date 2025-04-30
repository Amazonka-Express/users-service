namespace Core.Exceptions.Consts;

public static class ErrorMessages
{
    public const string UserNotFound = "User with id {0} not found.";
    public const string AccountCreationRestricted =
        "Account creation is restricted. Email {0} is not allowed.";
    public const string UserNotValid = "User is not valid.";
    public const string InvalidArgument = "Invalid argument: {0}.";
}
