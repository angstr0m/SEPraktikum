using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketOperations.Models;

namespace TicketOperations.InterfaceMembers
{
    class PublicMovieProgram : IPublicMovieProgram
    {
        private MovieProgram _movieprogram;

        public PublicMovieProgram(MovieProgram movieProgram)
        {
            _movieprogram = movieProgram;
        }

        public List<IPublicShow> Shows
        {
            get 
            { 
                List<IPublicShow> shows = new List<IPublicShow>();

                foreach (Show s in _movieprogram.Shows)
                {
                    shows.Add(new PublicShow(s));
                }

                return shows;
            }
        }

        public int GetIdentifier()
        {
            return _movieprogram.GetIdentifier();
        }
    }
}
