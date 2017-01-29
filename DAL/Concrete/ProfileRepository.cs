using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
using ORM;
using ORM.Entities;

namespace DAL.Concrete
{
    /// <summary>
    /// Profile repository class implements IProfileRepository
    /// </summary>
    public class ProfileRepository : IProfileRepository
    {
        private readonly SocialNetworkContext context;
        private readonly DbSet<Profile> Profiles;
        private readonly DbSet<Message> Messages;
        private readonly DbSet<File> Files;
        private readonly DbSet<Post> Posts;

        /// <summary>
        /// Create instance of Profile repository
        /// </summary>
        public ProfileRepository(SocialNetworkContext socialNetworkContext)
        {
            context = socialNetworkContext;
            Profiles = socialNetworkContext.Set<Profile>();
            Messages = socialNetworkContext.Set<Message>();
            Files = socialNetworkContext.Set<File>();
            Posts = socialNetworkContext.Set<Post>();
        }

        /// <summary>
        /// Method for adding new profile entity
        /// </summary>
        public void Add(DalProfile dalProfile)
        {
            var profile = dalProfile.ToProfile();
            Profiles.Add(profile);
        }

        /// <summary>
        /// Delete by Id profile
        /// </summary>
        /// <param name="id">id of exist profile</param>
        public void DeleteById(int id)
        {
            var profile = Profiles.FirstOrDefault(p => p.Id == id);
            if (!ReferenceEquals(profile, null))
            {
                Profiles.Remove(profile);
            }
            else
            {
                throw new ArgumentNullException(nameof(profile));
            }
        }

        /// <summary>
        /// Get profile by Id
        /// </summary>
        /// <returns>DalProfile entity</returns>
        public DalProfile GetById(int id)
        {
            return Profiles.FirstOrDefault(p => p.Id == id).ToDalProfile();
        }

        /// <summary>
        /// Get all profiles
        /// </summary>
        /// <returns>collection of profiles</returns>
        public IEnumerable<DalProfile> GetAll()
        {
            return
                Profiles.Include(p => p.Files)
                    .Include(p => p.Messages)
                    .Include(p => p.Friends)
                    .Include(p => p.InFriends).
                    Include(p=>p.Posts)
                    .Select(p => p)
                    .Map();
        }

        /// <summary>
        /// Update exist profile
        /// </summary>
        public void Update(DalProfile dalProfile)
        {
            var profile = Profiles.FirstOrDefault(p => p.Id == dalProfile.Id);
            if (!ReferenceEquals(profile, null))
            {
                profile.BirthDay = dalProfile.BirthDay;
                profile.FirstName = dalProfile.FirstName;
                profile.LastName = dalProfile.LastName;
                profile.Gender = dalProfile.Gender;
                profile.RelationStatus = dalProfile.RelationStatus;
                profile.City = dalProfile.City;
                profile.Friends.Clear();
                foreach (var id in dalProfile.Friends)
                {
                    var temp = Profiles.FirstOrDefault(p => p.Id == id);
                    profile.Friends.Add(temp);
                }
                context.Entry(profile).State = EntityState.Modified;
            }
            else
            {
                throw new ArgumentNullException(nameof(profile));
            }
        }
           
        /// <summary>
        /// get profile by contact email
        /// </summary>
        /// <returns>Dal profile entity</returns>
        public DalProfile GetByUserEmail(string email)
        {
            var user = context.Users.FirstOrDefault(u => u.Email == email);
            if(!ReferenceEquals(user,null))
            {
                return user.Profile.ToDalProfile();
            }
            else
            {
                throw new ArgumentNullException(nameof(user));
            }
            
        }

        public IEnumerable<DalProfile> GetAllFriendsOfId(int id)
        {
            var profile = Profiles.FirstOrDefault(p => p.Id == id);
            if (!ReferenceEquals(profile, null))
            {
                return profile.Friends.Map();
            }
            else
            {
                throw new ArgumentNullException(nameof(profile));
            }
        }
    }
}
