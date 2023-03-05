using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace ERP.Api.Extensions
{
    public class IdentityTranslatedMessages : IdentityErrorDescriber
    {
        private readonly IStringLocalizer<IdentityTranslatedMessages> _localizer;

        public IdentityTranslatedMessages(IStringLocalizer<IdentityTranslatedMessages> localizer)
        {
            _localizer = localizer;
        }

        public override IdentityError DefaultError() { return new IdentityError { Code = nameof(DefaultError), Description = _localizer["Ocorreu um erro desconhecido."].Value }; }
        public override IdentityError ConcurrencyFailure() { return new IdentityError { Code = nameof(ConcurrencyFailure), Description = _localizer["Falha de concorrência otimista, o objeto foi modificado."].Value }; }
        public override IdentityError PasswordMismatch() { return new IdentityError { Code = nameof(PasswordMismatch), Description = _localizer["Senha incorreta."].Value }; }
        public override IdentityError InvalidToken() { return new IdentityError { Code = nameof(InvalidToken), Description = _localizer["Token inválido."].Value }; }
        public override IdentityError LoginAlreadyAssociated() { return new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = _localizer["Já existe um usuário com este login."].Value }; }
        public override IdentityError InvalidUserName(string userName) { return new IdentityError { Code = nameof(InvalidUserName), Description = _localizer["Login '{0}' é inválido, pode conter apenas letras ou dígitos.", userName].Value }; }
        public override IdentityError InvalidEmail(string email) { return new IdentityError { Code = nameof(InvalidEmail), Description = _localizer["Email '{0}' é inválido.", email].Value }; }
        public override IdentityError DuplicateUserName(string userName) { return new IdentityError { Code = nameof(DuplicateUserName), Description = _localizer["Login '{0}' já está sendo utilizado.", userName].Value }; }
        public override IdentityError DuplicateEmail(string email) { return new IdentityError { Code = nameof(DuplicateEmail), Description = _localizer["Email '{0}' já está sendo utilizado.", email].Value }; }
        public override IdentityError InvalidRoleName(string role) { return new IdentityError { Code = nameof(InvalidRoleName), Description = _localizer["A permissão '{0}' é inválida.", role].Value }; }
        public override IdentityError DuplicateRoleName(string role) { return new IdentityError { Code = nameof(DuplicateRoleName), Description = _localizer["A permissão '{0}' já está sendo utilizada.", role].Value }; }
        public override IdentityError UserAlreadyHasPassword() { return new IdentityError { Code = nameof(UserAlreadyHasPassword), Description = _localizer["Usuário já possui uma senha definida."].Value }; }
        public override IdentityError UserLockoutNotEnabled() { return new IdentityError { Code = nameof(UserLockoutNotEnabled), Description = _localizer["Lockout não está habilitado para este usuário."].Value }; }
        public override IdentityError UserAlreadyInRole(string role) { return new IdentityError { Code = nameof(UserAlreadyInRole), Description = _localizer["Usuário já possui a permissão '{0}'.", role].Value }; }
        public override IdentityError UserNotInRole(string role) { return new IdentityError { Code = nameof(UserNotInRole), Description = _localizer["Usuário não tem a permissão '{0}'.", role].Value }; }
        public override IdentityError PasswordTooShort(int length) { return new IdentityError { Code = nameof(PasswordTooShort), Description = _localizer["Senhas devem conter ao menos {0} caracteres.", length].Value }; }
        public override IdentityError PasswordRequiresNonAlphanumeric() { return new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = _localizer["Senhas devem conter ao menos um caracter não alfanumérico."].Value }; }
        public override IdentityError PasswordRequiresDigit() { return new IdentityError { Code = nameof(PasswordRequiresDigit), Description = _localizer["Senhas devem conter ao menos um digito ('0'-'9')."].Value }; }
        public override IdentityError PasswordRequiresLower() { return new IdentityError { Code = nameof(PasswordRequiresLower), Description = _localizer["Senhas devem conter ao menos um caracter em caixa baixa ('a'-'z')."].Value }; }
        public override IdentityError PasswordRequiresUpper() { return new IdentityError { Code = nameof(PasswordRequiresUpper), Description = _localizer["Senhas devem conter ao menos um caracter em caixa alta ('A'-'Z')."].Value }; }
    }
}
