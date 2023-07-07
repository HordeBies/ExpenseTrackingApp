using AutoMapper;
using ExpenseTracking.Core.DTO;
using ExpenseTracking.Domain.Entities;

namespace ExpenseTracking.Core.Mappings
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<TransactionCreateRequest, Transaction>();
            CreateMap<Transaction, TransactionUpdateRequest>().ReverseMap();
            CreateMap<Transaction, TransactionResponse>();

            CreateMap<ApplicationUser, UserPreferencesReponse>();
            CreateMap<UserPreferencesUpdateRequest, ApplicationUser>();
        }
    }
}
