using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.ViewModels
{
    public class ProfileViewModel
    {
        public ProfileViewModel()
        {
            Friends = new List<int>();
            PostsId = new List<int>();
            GalleryId = new List<int>();
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [StringLength(128, ErrorMessage = "Max length - {0} symbols")]
        [Required(ErrorMessage = "Please enter your firsrt name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(128, ErrorMessage = "Max length - {0} symbols")]
        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Birth Day")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDay { get; set; }

        [Display(Name = "Relationship status")]
        public string RelationStatus { get; set; }

        /// <summary>
        /// user status
        /// </summary>
        [Display(Name = "City")]
        [StringLength(128, ErrorMessage = "Max length - {0} symbols")]
        public string City { get; set; }

        public IList<int> Friends { get; set; }

        public IList<int> PostsId { get; set; }

        public IList<int> GalleryId { get; set; }

        public bool IsYourFriend { get; set; }

        public bool IsYouSendInvite { get; set; }

        public bool IsYou { get; set; }

        public bool IsUnreadMessage { get; set; }

    }
}