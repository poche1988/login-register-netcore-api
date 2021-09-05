using AutoMapper;
using Domain.Entities;
using Models.Account;

namespace API.Mapping.Account
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<RegisterModel, AppUser>()
                .ForMember(a => a.AccessFailedCount, b => b.Ignore())
                .ForMember(a => a.Bio, b => b.Ignore())
                .ForMember(a => a.ConcurrencyStamp, b => b.Ignore())
                .ForMember(a => a.EmailConfirmed, b => b.Ignore())
                .ForMember(a => a.Id, b => b.Ignore())
                .ForMember(a => a.LockoutEnabled, b => b.Ignore())
                .ForMember(a => a.LockoutEnd, b => b.Ignore())
                .ForMember(a => a.NormalizedEmail, b => b.Ignore())
                .ForMember(a => a.NormalizedUserName, b => b.Ignore())
                .ForMember(a => a.PasswordHash, b => b.Ignore())
                .ForMember(a => a.PhoneNumber, b => b.Ignore())
                .ForMember(a => a.PhoneNumberConfirmed, b => b.Ignore())
                .ForMember(a => a.SecurityStamp, b => b.Ignore())
                .ForMember(a => a.TwoFactorEnabled, b => b.Ignore())
                .ForMember(a => a.UserName, b => b.MapFrom(c => c.Email));
        }
    }
}
