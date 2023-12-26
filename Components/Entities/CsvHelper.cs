using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace OMH_Player_Cards.Components.Entities
{
    public class CsvHelper
    {
        public static List<PlayerStat> ReadCsvToPlayerStats()
        {
            try
            {
                using (var reader = new StreamReader("..\\..\\Data\\Ranking-players-Fs-2022_23.csv"))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", Encoding = Encoding.UTF32 }))
                {
                    // Read and return the list of PlayerStats
                    csv.Context.RegisterClassMap<PlayerStatMap>();
                    return csv.GetRecords<PlayerStat>().ToList();
                }
            }
            catch (Exception ex)
            {
                //TODO: error handling
                return new List<PlayerStat>();
            }
        }
    }

    public class PlayerStatMap : ClassMap<PlayerStat>
    {
        public PlayerStatMap()
        {
            // Map properties to CSV columns based on the provided CSV header
            Map(m => m.ID).Name("ID");
            Map(m => m.Player).Name("Player");
            Map(m => m.Team).Name("Team");
            Map(m => m.Position).Name("Position");
            Map(m => m.OverallPercent).Name("Overall%");
            Map(m => m.IndividualPercent).Name("Individual%");
            Map(m => m.DefensivePercent).Name("Defensive%");
            Map(m => m.OffensivePercent).Name("Ofensive%");
            Map(m => m.TOI).Name("TOI");
            Map(m => m.GoalsPer60).Name("Goals/60");
            Map(m => m.FirstAssistsPer60).Name("First Assists/60");
            Map(m => m.SecondAssistsPer60).Name("Second Assists/60");
            Map(m => m.TotalPointsPer60).Name("Total Points/60");
            Map(m => m.ShotsPer60).Name("Shots/60");
            Map(m => m.SHPercent).Name("SH%");
            Map(m => m.ixGPer60).Name("ixG/60");
            Map(m => m.iCFPer60).Name("iCF/60");
            Map(m => m.iFFPer60).Name("iFF/60");
            Map(m => m.iSCFPer60).Name("iSCF/60");
            Map(m => m.iHDCFPer60).Name("iHDCF/60");
            Map(m => m.RushAttemptsPer60).Name("Rush Attempts/60");
            Map(m => m.ReboundsCreatedPer60).Name("Rebounds Created/60");
            Map(m => m.PIMPer60).Name("PIM/60");
            Map(m => m.PDPer60).Name("PD/60");
            Map(m => m.GiveawaysPer60).Name("Giveaways/60");
            Map(m => m.TakeawaysPer60).Name("Takeaways/60");
            Map(m => m.HitsPer60).Name("Hits/60");
            Map(m => m.ShotsBlockedPer60).Name("Shots Blocked/60");
            Map(m => m.CFPer60).Name("CF/60");
            Map(m => m.CAPer60).Name("CA/60");
            Map(m => m.CFPercent).Name("CF%");
            Map(m => m.FFPer60).Name("FF/60");
            Map(m => m.FAPer60).Name("FA/60");
            Map(m => m.FFPercent).Name("FF%");
            Map(m => m.SFPer60).Name("SF/60");
            Map(m => m.SAPer60).Name("SA/60");
            Map(m => m.SFPercent).Name("SF%");
            Map(m => m.GFPer60).Name("GF/60");
            Map(m => m.GAPer60).Name("GA/60");
            Map(m => m.GFPercent).Name("GF%");
            Map(m => m.xGFPer60).Name("xGF/60");
            Map(m => m.xGAPer60).Name("xGA/60");
            Map(m => m.xGFPercent).Name("xGF%");
            Map(m => m.SCFPer60).Name("SCF/60");
            Map(m => m.SCAPer60).Name("SCA/60");
            Map(m => m.SCFPercent).Name("SCF%");
            Map(m => m.HDCFPer60).Name("HDCF/60");
            Map(m => m.HDCAPer60).Name("HDCA/60");
            Map(m => m.HDCFPercent).Name("HDCF%");
            Map(m => m.HDGFPer60).Name("HDGF/60");
            Map(m => m.HDGAPer60).Name("HDGA/60");
            Map(m => m.HDGFPercent).Name("HDGF%");
            Map(m => m.OnIceSHPercent).Name("On-Ice SH%");
            Map(m => m.OnIceSVPercent).Name("On-Ice SV%");
            Map(m => m.PDO).Name("PDO");
            Map(m => m.CFPer60Rel).Name("CF/60 Rel");
            Map(m => m.CAPer60Rel).Name("CA/60 Rel");
            Map(m => m.CFPercentRel).Name("CF% Rel");
            Map(m => m.FFPer60Rel).Name("FF/60 Rel");
            Map(m => m.FAPer60Rel).Name("FA/60 Rel");
            Map(m => m.FFPercentRel).Name("FF% Rel");
            Map(m => m.SFPer60Rel).Name("SF/60 Rel");
            Map(m => m.SAPer60Rel).Name("SA/60 Rel");
            Map(m => m.SFPercentRel).Name("SF% Rel");
            Map(m => m.GFPer60Rel).Name("GF/60 Rel");
            Map(m => m.GAPer60Rel).Name("GA/60 Rel");
            Map(m => m.GFPercentRel).Name("GF% Rel");
            Map(m => m.xGFPer60Rel).Name("xGF/60 Rel");
            Map(m => m.xGAPer60Rel).Name("xGA/60 Rel");
            Map(m => m.xGFPercentRel).Name("xGF% Rel");
            Map(m => m.SCFPer60Rel).Name("SCF/60 Rel");
            Map(m => m.SCAPer60Rel).Name("SCA/60 Rel");
            Map(m => m.SCFPercentRel).Name("SCF% Rel");
            Map(m => m.HDCFPer60Rel).Name("HDCF/60 Rel");
            Map(m => m.HDCAPer60Rel).Name("HDCA/60 Rel");
            Map(m => m.HDCFPercentRel).Name("HDCF% Rel");
            Map(m => m.HDGFPer60Rel).Name("HDGF/60 Rel");
            Map(m => m.HDGAPer60Rel).Name("HDGA/60 Rel");
            Map(m => m.HDGFPercentRel).Name("HDGF% Rel");
        }
    }
}
