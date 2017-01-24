﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
using ORM;
using ORM.Entities;

namespace DAL.Concrete
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly SocialNetworkContext context;
        private readonly DbSet<Profile> Profiles;
        private readonly DbSet<Message> Messages;
        private readonly DbSet<File> Files;
        private readonly DbSet<Post> Posts;

        public ProfileRepository(SocialNetworkContext socialNetworkContext)
        {
            context = socialNetworkContext;
            Profiles = socialNetworkContext.Set<Profile>();
            Messages = socialNetworkContext.Set<Message>();
            Files = socialNetworkContext.Set<File>();
            Posts = socialNetworkContext.Set<Post>();
        }

        public void Add(DalProfile dalProfile)
        {
            var profile = dalProfile.ToProfile();
            Profiles.Add(profile);
        }

        public void DeleteById(int id)
        {
            Profiles.Remove(Profiles.FirstOrDefault(p => p.Id == id));
        }

        public DalProfile GetById(int id)
        {
            return Profiles.FirstOrDefault(p => p.Id == id).ToDalProfile();
        }

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

        public DalProfile GetByPredicate(Expression<Func<DalProfile, bool>> f)
        {
            throw new NotImplementedException();
        }

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
            }
            foreach (var id in dalProfile.Friends)
            {
                var temp = Profiles.FirstOrDefault(p => p.Id == id);
                profile.Friends.Add(temp);
            }
            foreach (var post in dalProfile.PostsId)
            {
                var temp = Posts.FirstOrDefault(p => p.Id == post);
                profile.Posts.Add(temp);
            }
            foreach (var file in Files)
            {
                profile.Files.Add(file);
            }
            foreach (var message in Messages)
            {
                profile.Messages.Add(message);
            }
            context.Entry(profile).State = EntityState.Modified;
        }
    }
}
