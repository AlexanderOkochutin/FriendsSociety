using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    /// <summary>
    /// Service class for mapping DalUser and ORM User entities
    /// </summary>
    public static class ProfileMapper
    {
        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new ORM User entity same as user</returns>
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
                City = profile.City
            };

            return result;
        }

        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new DalUser entity same as user</returns>
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

            foreach (var friend in profile.Friends)
            {
                result.Friends.Add(friend.Id);
            }        
            return result;
        }

        /// <summary>
        /// Map users
        /// </summary>
        /// <param name="users"></param>
        /// <returns>new DalUser collection same as users</returns>
        public static IEnumerable<DalProfile> Map(this IQueryable<Profile> profiles)
        {
            var dalProfiles = new List<DalProfile>();
            foreach (var item in profiles)
            {
                dalProfiles.Add(item.ToDalProfile());
            }
            return dalProfiles;
        }

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
