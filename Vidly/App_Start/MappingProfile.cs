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
            // When Using PUT, the 'id' should never changed. So, We ignore it
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>().ForMember(c => c.Id, opt => opt.Ignore()); ;

            CreateMap<MembershipType, MembershipTypeDTO>();

            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieDTO, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}