using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;
using MvcPL.ViewModels;

namespace MvcPL.Infrastructure.Mappers
{

    public static class ProfileMapper
    {
        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new BllUser same as user</returns>
        public static ProfileViewModel ToViewProfileModel(this BllProfile profile)
        {
            if (ReferenceEquals(profile, null)) return null;
            ProfileViewModel result = new ProfileViewModel()
            {
                Id = profile.Id,
                LastName = profile.LastName,
                BirthDay = profile.BirthDay,
                Gender = profile.Gender,
                RelationStatus = profile.RelationStatus,
                FirstName = profile.FirstName,
                City = profile.City,
                Friends = profile.Friends.ToList()
            };
            return result;
        }

        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new DalUser same as user</returns>
        public static BllProfile ToBllProfile(this ProfileViewModel profile)
        {
            if (ReferenceEquals(profile, null)) return null;
            BllProfile result = new BllProfile()
            {
                Id = profile.Id,
                LastName = profile.LastName,
                BirthDay = profile.BirthDay,
                Gender = profile.Gender,
                RelationStatus = profile.RelationStatus,
                FirstName = profile.FirstName,
                City = profile.City,
                Friends = profile.Friends
            };
            return result;
        }

        /// <summary>
        /// Map Users
        /// </summary>
        /// <param name="users"></param>
        /// <returns>new BllUsers collection same as users</returns>
        public static IEnumerable<ProfileViewModel> Map(this IEnumerable<BllProfile> profiles)
        {
            var Profiles = new List<ProfileViewModel>();
            foreach (var item in profiles)
            {
                Profiles.Add(item.ToViewProfileModel());
            }
            return Profiles;
        }
    }
}