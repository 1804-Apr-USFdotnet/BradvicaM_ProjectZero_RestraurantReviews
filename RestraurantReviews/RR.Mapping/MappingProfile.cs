﻿using System;
using AutoMapper;
using RR.Models;
using RR.ViewModels;

namespace RR.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Restaurant, RestaurantViewModel>()
                .ForSourceMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Restaurant, RestaurantNameViewModel>()
                .ForSourceMember(x => x.Id, opt => opt.Ignore())
                .ForSourceMember(x => x.AverageRating, opt => opt.Ignore())
                .ForSourceMember(x => x.City, opt => opt.Ignore())
                .ForSourceMember(x => x.PhoneNumber, opt => opt.Ignore())
                .ForSourceMember(x => x.State, opt => opt.Ignore())
                .ForSourceMember(x => x.Street, opt => opt.Ignore())
                .ForSourceMember(x => x.Website, opt => opt.Ignore())
                .ForSourceMember(x => x.ZipCode, opt => opt.Ignore());

            CreateMap<AddReviewViewModel, Review>()
                .ForMember(des => des.Id, opt => opt.UseValue(Guid.NewGuid()))
                .ForPath(des => des.RestaurantId, opt => opt.MapFrom(src => src.Restaurant.Id));

            CreateMap<Review, ReviewViewModel>()
                .ForSourceMember(src => src.Id, opt => opt.Ignore())
                .ForSourceMember(src => src.Restaurant, opt => opt.Ignore())
                .ForSourceMember(src => src.RestaurantId, opt => opt.Ignore());

            CreateMap<Restaurant, TopRatedRestaurantViewModel>()
                .ForSourceMember(x => x.Id, opt => opt.Ignore())
                .ForSourceMember(x => x.City, opt => opt.Ignore())
                .ForSourceMember(x => x.PhoneNumber, opt => opt.Ignore())
                .ForSourceMember(x => x.State, opt => opt.Ignore())
                .ForSourceMember(x => x.Street, opt => opt.Ignore())
                .ForSourceMember(x => x.Website, opt => opt.Ignore())
                .ForSourceMember(x => x.ZipCode, opt => opt.Ignore());

            CreateMap<AddRestaurantViewModel, Restaurant>()
                .ForMember(des => des.Id, opt => opt.UseValue(Guid.NewGuid()));
        }
    }
}
