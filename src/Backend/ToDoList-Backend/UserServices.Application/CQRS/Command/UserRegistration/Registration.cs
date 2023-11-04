﻿using DatabasePostgres.Persistance.Interface;
using UserServices.Application.Dto;
using UserServices.Application.Interface;

namespace UserServices.Application.CQRS.Command.UserRegistration
{
    public class Registration : IRegistration
    {
        private readonly IUserRepositoryPostgres _userRepositoryPostgres;
        private readonly string _RegistrationResponseDto;
        public string Resullt { get; set; }
       
        public Registration(IUserRepositoryPostgres userRepositoryPostgres)
        {
            _userRepositoryPostgres = userRepositoryPostgres;
           
        }
        public async Task<string> RegisterAsync(RegistrationResponseDto registrationResponseDto)
        {
            DateTime CreateData = DateTime.Now;
            return  await _userRepositoryPostgres.UserAdd(registrationResponseDto.Login,registrationResponseDto.Password,
            registrationResponseDto.Email,CreateData);  
        }
    }
}
