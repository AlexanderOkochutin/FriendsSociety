using System.Collections.Generic;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    /// <summary>
    /// Service class for mapping DalProfile and BllProfile Entities
    /// </summary>
    public static class ProfileMapper
    {
        /// <summary>
        /// Method map To BllProfile
        /// </summary>
        /// <returns>new BllProfile the same as DalProfile</returns>
        public static BllProfile ToBllProfile(this DalProfile dalProfile)
        {
            if (ReferenceEquals(dalProfile, null)) return null;
            var bllProfile = new BllProfile()
            {
               Id = dalProfile.Id,
               City = dalProfile.City,
               Gender = dalProfile.Gender,
               FirstName = dalProfile.FirstName,
               BirthDay = dalProfile.BirthDay,
               RelationStatus = dalProfile.RelationStatus,
               LastName = dalProfile.LastName,
               Friends = dalProfile.Friends
            };
            return bllProfile;
        }

        /// <summary>
        /// Method map to DalProfile
        /// </summary>
        /// <returns>new DalProfile the same as BllProfile</returns>
        public static DalProfile ToDalProfile(this BllProfile bllProfile)
        {
            if (ReferenceEquals(bllProfile, null)) return null;
            var dalProfile = new DalProfile()
            {
                Id = bllProfile.Id,
                City = bllProfile.City,
                Gender = bllProfile.Gender,
                FirstName = bllProfile.FirstName,
                BirthDay = bllProfile.BirthDay,
                RelationStatus = bllProfile.RelationStatus,
                LastName = bllProfile.LastName,
                Friends = bllProfile.Friends
            };
            return dalProfile;
        }

        /// <summary>
        /// Method map To BllProfiles
        /// </summary>
        /// <returns>new BllProfiles collection same as DalProfiles collection</returns>
        public static IEnumerable<BllProfile> Map(this IEnumerable<DalProfile> dalProfiles)
        {
            var bllProfiles = new List<BllProfile>();
            foreach (var dalProfile in dalProfiles)
            {
                bllProfiles.Add(dalProfile.ToBllProfile());
            }
            return bllProfiles;
        }
    }
}
