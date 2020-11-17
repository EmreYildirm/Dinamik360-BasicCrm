using AutoMapper;
using BasicCrm.Entities;
using BasicCrm.WEB.Dto;
using BasicCrm.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicCrm.WEB.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /*
            //Dto to Entity
            CreateMap<Customer, CustomerDto>();
            //Entity to Dto
            CreateMap<CustomerDto, Customer>();

            CreateMap<SaveCustomerDto, Customer>();
            CreateMap<Customer, SaveCustomerDto>();    
            */

            //VM to Entity
            CreateMap<Customer, CustomerViewModel>();
            //Entity to VM
            CreateMap<CustomerViewModel, Customer>();

            CreateMap<SaveCustomerViewModel, Customer>();
            CreateMap<Customer, SaveCustomerViewModel>();


        }
    }
}
