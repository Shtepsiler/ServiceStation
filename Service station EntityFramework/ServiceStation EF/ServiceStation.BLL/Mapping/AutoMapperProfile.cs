﻿using AutoMapper;
using ServiceStation.BLL.DTO.Requests;
using ServiceStation.BLL.DTO.Responses;
using ServiceStation.DAL.Entities;

namespace ServiceStation.BLL.Mapping
{
    public class AutoMapperProfile : Profile
    {



        private void CreateJobMap()
        {
            CreateMap<Job, UsersJobsResponse>()
                .ForMember(r=>r.ManagerName,opt=>opt.MapFrom(manager => $"{manager.Manager.FullName}"))
                .ForMember(r => r.ManagerPhone, opt => opt.MapFrom(manager => $"{manager.Manager.Phone}"))
                .ForMember(r=>r.MechanicFullName,opt=>opt.MapFrom(mech=>$"{mech.Mechanic.FirstName} {mech.Mechanic.LastName}"))
                .ForMember(r=>r.Model,opt=>opt.MapFrom(model => model.Model.Name))
                ;
            CreateMap<Job, ManagerResponse>();
            CreateMap<ManagerRequest, Job>();
        }

        private void CreateManagerMap()
        {
            CreateMap<Manager,ManagerResponse>();
            CreateMap<ManagerRequest, Manager>();


        }
        private void CreateModelMap()
        {
            CreateMap<Model, ModelResponse>();
            CreateMap<ModelRequest, Model>();
        }


/*
        private void CreateClientMaps()
        {
            CreateMap<UserSignUpRequest, User>();
            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>()
                .ForMember(
                    response => response.FullName,
                    options => options.MapFrom(user => $"{user.FirstName} {user.LastName}"))
                .ForMember(
                    response => response.Avatar,
                    options => options.MapFrom(
                        user => !string.IsNullOrWhiteSpace(user.Avatar) ? $"Public/Photos/{user.Avatar}" : null));
        }

        private void CreateTicketsMaps()
        {
            CreateMap<TicketRequest, Ticket>();
            CreateMap<Ticket, TicketResponse>();
        }

        private void CreateTeamsMaps()
        {
            CreateMap<TeamRequest, Team>();
            CreateMap<Team, TeamResponse>()
                .ForMember(
                    response => response.Avatar,
                    options => options.MapFrom(
                        team => !string.IsNullOrWhiteSpace(team.Avatar) ? $"Public/Photos/{team.Avatar}" : null));
        }

        private void CreateProjectsMaps()
        {
            CreateMap<ProjectRequest, Project>();
            CreateMap<Project, ProjectResponse>();
        }

        private void CreateRatingsMaps()
        {
            CreateMap<RatingRequest, Rating>();
            CreateMap<Rating, RatingResponse>().ForMember(
                response => response.Average,
                options => options.MapFrom(
                    rating => (rating.Skills
                               + rating.Social
                               + rating.Punctuality
                               + rating.Responsibility) / 4));
        }
*/
        public AutoMapperProfile()
        {
            CreateJobMap();
            CreateManagerMap();
            CreateModelMap();

        }
    }
}
