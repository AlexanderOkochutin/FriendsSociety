using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;
using MvcPL.ViewModels;

namespace MvcPL.Infrastructure.Mappers
{
    /// <summary>
    /// Class for mapping Profile view model and BllProfile
    /// </summary>
    public static class ProfileMapper
    {
        /// <summary>
        /// Map To Profile View Model
        /// </summary>
        /// <returns>Return Profile view Model same as BllProfile</returns>
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
        /// Map to BllProfile
        /// </summary>
        /// <returns>Bllprofile same as ProfileViewModel</returns>
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
        /// Map To ProfileViewModels
        /// </summary>
        /// <returns>Collection of ProfileViewModels same as BllProfiles</returns>
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