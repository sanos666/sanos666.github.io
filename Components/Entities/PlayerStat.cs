using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OMH_Player_Cards.Components.Entities
{
    public class PlayerStat
    {
        public string ID { get; set; }
        public string Player { get; set; }
        public string Team { get; set; }
        public string Position { get; set; }
        [Display(Name = "Overall %")]
        public string OverallPercent { get; set; }
        [Display(Name = "Individual %")]
        public string IndividualPercent { get; set; }
        [Display(Name = "DEF%")]
        public string DefensivePercent { get; set; }
        [Display(Name = "OFF%")]
        public string OffensivePercent { get; set; }
        public string TOI { get; set; }
        public string GoalsPer60 { get; set; }
        public string FirstAssistsPer60 { get; set; }
        public string SecondAssistsPer60 { get; set; }
        public string TotalPointsPer60 { get; set; }
        public string ShotsPer60 { get; set; }
        [Display(Name = "SH%")]
        public string SHPercent { get; set; }
        public string ixGPer60 { get; set; }
        public string iCFPer60 { get; set; }
        public string iFFPer60 { get; set; }
        public string iSCFPer60 { get; set; }
        public string iHDCFPer60 { get; set; }
        public string RushAttemptsPer60 { get; set; }
        public string ReboundsCreatedPer60 { get; set; }
        public string PIMPer60 { get; set; }
        public string PDPer60 { get; set; }
        public string GiveawaysPer60 { get; set; }
        public string TakeawaysPer60 { get; set; }
        public string HitsPer60 { get; set; }
        public string ShotsBlockedPer60 { get; set; }
        public string CFPer60 { get; set; }
        public string CAPer60 { get; set; }
        public string CFPercent { get; set; }
        public string FFPer60 { get; set; }
        public string FAPer60 { get; set; }
        [DisplayName("FF%")]
        public string FFPercent { get; set; }
        public string SFPer60 { get; set; }
        public string SAPer60 { get; set; }
        public string SFPercent { get; set; }
        public string GFPer60 { get; set; }
        public string GAPer60 { get; set; }
        public string GFPercent { get; set; }
        public string xGFPer60 { get; set; }
        public string xGAPer60 { get; set; }
        public string xGFPercent { get; set; }
        public string SCFPer60 { get; set; }
        public string SCAPer60 { get; set; }
        public string SCFPercent { get; set; }
        public string HDCFPer60 { get; set; }
        public string HDCAPer60 { get; set; }
        public string HDCFPercent { get; set; }
        public string HDGFPer60 { get; set; }
        public string HDGAPer60 { get; set; }
        public string HDGFPercent { get; set; }
        public string OnIceSHPercent { get; set; }
        public string OnIceSVPercent { get; set; }
        public string PDO { get; set; }
        public string CFPer60Rel { get; set; }
        public string CAPer60Rel { get; set; }
        public string CFPercentRel { get; set; }
        public string FFPer60Rel { get; set; }
        public string FAPer60Rel { get; set; }
        public string FFPercentRel { get; set; }
        public string SFPer60Rel { get; set; }
        public string SAPer60Rel { get; set; }
        public string SFPercentRel { get; set; }
        public string GFPer60Rel { get; set; }
        public string GAPer60Rel { get; set; }
        public string GFPercentRel { get; set; }
        public string xGFPer60Rel { get; set; }
        public string xGAPer60Rel { get; set; }
        public string xGFPercentRel { get; set; }
        public string SCFPer60Rel { get; set; }
        public string SCAPer60Rel { get; set; }
        public string SCFPercentRel { get; set; }
        public string HDCFPer60Rel { get; set; }
        public string HDCAPer60Rel { get; set; }
        public string HDCFPercentRel { get; set; }
        public string HDGFPer60Rel { get; set; }
        public string HDGAPer60Rel { get; set; }
        public string HDGFPercentRel { get; set; }
    }
}
