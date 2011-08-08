using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Fulbo.Models
{
    public class Team
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [DisplayName("Home Matches")]
        public virtual ICollection<Match> HomeMatches { get; set; }
        [DisplayName("Away Matches")]
        public virtual ICollection<Match> AwayMatches { get; set; }
    }

    public class Match
    {
        public int Id { get; set; }

        [Required]
        public int HomeTeamId { get; set; }
        [Required]
        public int AwayTeamId { get; set; }

        [DisplayName("Home Team")]
        public virtual Team HomeTeam { get; set; }
        [DisplayName("Away Team")]
        public virtual Team AwayTeam { get; set; }
        
        [DisplayName("Home Team Score")]
        public int HomeScore { get; set; }
        [DisplayName("Away Team Score")]
        public int AwayScore { get; set; }
        [DisplayName("When?")]
        public DateTime Date { get; set; }

        public virtual Fixture Fixture { get; set; }
        [Required]
        public virtual int FixtureId { get; set; }
    }

    [DisplayColumn("Number")]
    public class Fixture
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Season { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
    }
}