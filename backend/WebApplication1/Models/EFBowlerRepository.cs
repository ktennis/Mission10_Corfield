//using Microsoft.EntityFrameworkCore;

//namespace WebApplication1.Models
//{
//    public class EFBowlerRepository : IBowlerRepository 
//    {
//        private BowlingLeagueContext _bowlingContext;
//        public EFBowlerRepository(BowlingLeagueContext temp) {
//            _bowlingContext = temp;
//        }
//        public IEnumerable<Bowler> Bowlers => _bowlingContext.Bowlers; //.Bowlers is the table name

//    }
//}

using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class EFBowlerRepository : IBowlerRepository
    {
        private BowlingLeagueContext _bowlingContext;

        public EFBowlerRepository(BowlingLeagueContext temp)
        {
            _bowlingContext = temp;
        }

        public IEnumerable<Bowler> Bowlers
        {
            get
            {
                var bowlersWithTeamNames = _bowlingContext.Bowlers
                    .Join(
                        _bowlingContext.Teams,
                        bowler => bowler.TeamId,
                        team => team.TeamId,
                        (bowler, team) => new { Bowler = bowler, TeamName = team.TeamName }
                    )
                    .Select(joined => new Bowler
                    {
                        BowlerId = joined.Bowler.BowlerId,
                        BowlerLastName = joined.Bowler.BowlerLastName,
                        BowlerFirstName = joined.Bowler.BowlerFirstName,
                        BowlerMiddleInit = joined.Bowler.BowlerMiddleInit,
                        BowlerAddress = joined.Bowler.BowlerAddress,
                        BowlerCity = joined.Bowler.BowlerCity,
                        BowlerState = joined.Bowler.BowlerState,
                        BowlerZip = joined.Bowler.BowlerZip,
                        BowlerPhoneNumber = joined.Bowler.BowlerPhoneNumber,
                        TeamId = joined.Bowler.TeamId,
                        Team = new Team { TeamName = joined.TeamName } // Creating a new Team object with TeamName
                    })
                    .ToList();

                return bowlersWithTeamNames;
            }
        }
    }
}

