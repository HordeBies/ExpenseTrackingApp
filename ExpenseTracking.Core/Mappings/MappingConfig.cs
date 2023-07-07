using AutoMapper;
using ExpenseTracking.Core.DTO;
using ExpenseTracking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracking.Core.Mappings
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<TransactionCreateRequest, Transaction>();
            CreateMap<Transaction,TransactionUpdateRequest>().ReverseMap();
            CreateMap<Transaction, TransactionResponse>();
        }
    }
}
