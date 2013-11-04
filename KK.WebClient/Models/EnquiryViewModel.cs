using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KK.WebClient.Models
{
    /// <summary>
    /// Note : This View Model is used by API and Controller.
    /// Data Contract and Data Member is used by API
    /// </summary>
    [DataContract]
    public class EnquiryViewModel
    {
        [Required]
        [DataMember(IsRequired = true)]
        [Display(Name = "Car Ads ID")]
        public Guid CarAdsId { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        [Display(Name = "Full name")]
        public string Name { get; set; }

        
        [Required]
        [DataMember(IsRequired = true)]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }
}