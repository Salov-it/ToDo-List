using DatabasePostgres.Persistance.Interface;
using MediatR;
using System.Text.RegularExpressions;
using UserServices.Application.Interface;

namespace UserServices.Application.CQRS.Command.UserRegistration
{
    public class RegistrationHandler : IRequestHandler<RegistrationCommand, string>
    {
        private readonly IRegistration _RegisterAsync;
        private readonly IUserRepositoryPostgres _userRepositoryPostgres;
        public string Resullt { get; set; }
        public RegistrationHandler(IRegistration registration, IUserRepositoryPostgres userRepository)
        {
            _RegisterAsync = registration;
            _userRepositoryPostgres = userRepository;
        }
        public async Task<string> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
                if (!Regex.IsMatch(request.registrationDto.Email, Config.FormValidation.EmailFormat))
                {
                    Resullt = "Неверный формат email.";
                }
                else
                {
                    var UserVeri = await _userRepositoryPostgres.UserDataVerification(request.registrationDto.Login, request.registrationDto.Email);
                    if (UserVeri.Login == request.registrationDto.Login) 
                    {
                        Resullt = "Логин уже существует";
                    }
                    else
                    {
                        if(UserVeri.Email == request.registrationDto.Email)
                        {
                            Resullt = "Email уже существует";
                        }
                        else
                        {
                            var Content = await _RegisterAsync.RegisterAsync(request.registrationDto);
                            Resullt = "Пользователь успешно зарегистрирован";
                        }
                    }
                }
            
            return Resullt;
        }
    }
}
