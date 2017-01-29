using System.Collections.Generic;
using BLL.Interface.Entities;
using MvcPL.ViewModels;

namespace MvcPL.ViewModels
{
    public class SendViewModel
    {
        public ProfileViewModel I { get; set; }
        public ProfileViewModel Companion { get; set; }
        public IEnumerable<BllMessage> Messages { get; set; }
    }
}