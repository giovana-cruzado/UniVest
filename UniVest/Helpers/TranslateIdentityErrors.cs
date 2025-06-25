namespace UniVest.Helpers;
public static class TranslateIdentityErrors
{
    public static string TranslateErrorMessage(string codeError)
    {
        string message = codeError switch
        {
            "DefaultError" => "Ocorreu um erro desconhecido.",
            "ConcurrencyFailure" => "Falha de concorrência otimista, o objeto foi modificado.",
            "InvalidToken" => "Token inválido.",
            "LoginAlreadyAssociated" => "Já existe um usuário com este login.",
            "InvalidUserName" => "E-mail inválido.",
            "DuplicateUserName" => "Este login já está sendo utilizado.",
            "DuplicateEmail" => $"Este email já está sendo utilizado",
            "invalidRoleName" => "Esta permissão é inválida",
            "UserAlreadyInRole" => "Usuário já possui esta permissão.",
            "UserNotInRole" => "Usuário não tem esta permissão.",
            "UserLockoutNotEnabled" => "Lockout não está habilitado para este usuário.",
            "UserAlreadyHasPassword" => "Usuário já possui uma senha definida.",
            "PasswordMismatch" => "Senha incorreta.",
            "PasswordTooShort" => "Senha muito curta.",
            "PasswordRequiresNonAlphanumeric" => "Senhas devem conter ao menos um caracter não alfanumérico.",
            "PasswordRequiresDigit" => "Senhas devem conter ao menos um dígito ('0'-'9').",
            "PasswordRequiresLower" => "Senhas devem conter ao menos um caracter em caixa baixa ('a'-'z').",
            "PasswordRequiresUpper" => "Senhas devem conter ao menos um caracter em caixa alta ('A'-'Z').",
            _ => "Ocorreu um erro desconhecido.",
        };
        return message;
    }
}