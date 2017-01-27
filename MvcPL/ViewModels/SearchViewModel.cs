using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.ViewModels
{
    public class SearchViewModel
    {
        /// <summary>
        /// Part of user name
        /// </summary>
        public string StringKey { get; set; }

        /// <summary>
        /// User city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Finded users
        /// </summary>
        public GenericPaginationModel<ProfileViewModel> Profiles { get; set; }
    }
}