using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.DTOS;
using Vidly.Models;

namespace Vidly.App_Start
{

    /*
     * In the Package Manager Console:
     *   $ install-package automapper
     */ 

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
        }
    }
}