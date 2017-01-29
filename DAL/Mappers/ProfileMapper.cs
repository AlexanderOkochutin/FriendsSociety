using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    /// <summary>
    /// Service class for mapping DalProfile and ORM Profile entities
    /// </summary>
    public static class ProfileMapper
    {
        /// <summary>
        /// Map To Profile
        /// </summary>
        /// <returns>new ORM Profile entity same as dalProfile</returns>
        public static Profile ToProfile(this DalProfile profile)
        {
            if (ReferenceEquals(profile, null)) return null;
            Profile result = new Profile()
            {
                Id = profile.Id,
                BirthDay = profile.BirthDay,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Gender = profile.Gender,
                RelationStatus = profile.RelationStatus,
                City = profile.City,

            };
            return result;
        }

        /// <summary>
        /// Map To Dal Profiel
        /// </summary>
        /// <returns>new DalProfile entity same as Profile</returns>
        public static DalProfile ToDalProfile(this Profile profile)
        {
            if (ReferenceEquals(profile, null)) return null;
            DalProfile result = new DalProfile()
            {
                Id = profile.Id,
                BirthDay = profile.BirthDay,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Gender = profile.Gender,
                RelationStatus = profile.RelationStatus,
                City = profile.City             
            };
            result.Friends = profile.Friends.Select(p => p.Id).ToList();
            return result;
        }

        /// <summary>
        /// Map To DalProfiles
        /// </summary>
        /// <returns>new DalProfiles collection same as Profiles</returns>
        public static IEnumerable<DalProfile> Map(this IQueryable<Profile> profiles)
        {
            var dalProfiles = new List<DalProfile>();
            foreach (var item in profiles)
            {
                dalProfiles.Add(item.ToDalProfile());
            }
            return dalProfiles;
        }

        /// <summary>
        /// Map Profiles
        /// </summary>
        /// <returns>new DalProfiles collection same as Profiles</returns>
        public static IEnumerable<DalProfile> Map(this IEnumerable<Profile> profiles)
        {
            var dalProfiles = new List<DalProfile>();
            foreach (var item in profiles)
            {
                dalProfiles.Add(item.ToDalProfile());
            }
            return dalProfiles;
        }
    }
}
