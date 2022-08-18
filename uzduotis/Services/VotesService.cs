using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uzduotis.Contexts;
using uzduotis.NewFolder;

namespace uzduotis.Services
{
    
    public class VotesService
    {
        private VotesContext context = new VotesContext();
        public void AddVote (Vote vote)
        {
            context.Add(vote);
            context.SaveChanges();
        }
        public List<Vote> FindAllVotes()
        {
            return context.Votes.ToList();
        }
        public int CalcMinScore(string language)
        {
            
            var languageVotes = context.Votes.Where(m => m.Language == language).ToList();
            return languageVotes.Min(m => m.Score);
           
           
        }
        public int CalcMaxScore(string language)
        {
            var languageVotes = context.Votes.Where(m => m.Language == language).ToList();
            return languageVotes.Max(m => m.Score);

            
        }
        public int CountVotes(string language)
        {
            return context.Votes.Count(m => m.Language == language);
        }
        public int CalcAverageScore(string language)
        {
            var languageVotes = context.Votes.Where(m => m.Language == language).ToList();
            return (int)languageVotes.Average(m => m.Score);
        }
    }
}
