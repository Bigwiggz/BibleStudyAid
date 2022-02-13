using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BibleStudyDataAccessLibrary.Models.Enums
{
    public enum MeetingType
    {
        [Display(Name = "Public Discourse")]
        PublicDiscourse=1002,
        [Display(Name = "Watchtower Study")]
        WatchtowerStudy = 1003,
        [Display(Name = "Treasure from God's Word")]
        TreasuresFromGodsWord = 1004,
        [Display(Name = "Spiritual Gems")]
        SpiritualGems = 1005,
        [Display(Name = "Bible Reading")]
        BibleReading = 1006,
        [Display(Name = "Apply Yourself to the Ministry")]
        ApplyYourselftoTheMinistry = 1007,
        [Display(Name = "Living As Christians")]
        LivingAsChristians = 1008,
        [Display(Name = "Congregation Bible Study")]
        CongregationBibleStudy = 1009,
        [Display(Name = "Local Needs")]
        LocalNeeds = 1010,
        [Display(Name = "Circuit Assembly")]
        CircuitAssembly = 1011,
        [Display(Name = "Regional Assembly")]
        RegionalAssembly = 1012,
        [Display(Name = "Circuit Pioneer Meeting")]
        CircuitPioneerMeeting = 1013,
        [Display(Name ="Elder's Meeting with the Pioneers")]
        PioneerElderMeeting = 1014
    }
}
