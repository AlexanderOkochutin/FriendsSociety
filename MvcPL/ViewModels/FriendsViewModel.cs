using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.ViewModels
{
    public class FriendsViewModel
    {
        public FriendsViewModel()
        {
            FriendsInvites = new GenericPaginationModel<ProfileViewModel>();
            Friends = new List<ProfileViewModel>();
        }

        
        public int UserId { get; set; }
        public GenericPaginationModel<ProfileViewModel> FriendsInvites { get; set; }
        public ICollection<ProfileViewModel> Friends { get; set; }
    }
}