using System;
using System.Collections.Generic;
namespace Models {
	public class MovieProgram : Interfaces.Subject  {
        private DateTime startDateTime;
        private List<Show> shows;
        private bool published;

        public MovieProgram(DateTime startTime, List<Show> shows)
        {
            startDateTime = startTime;
            this.shows = shows;
            published = false;
        }

        public void Publish() 
        {
            published = true;
        }

        public List<Show> Shows
        {
            get { return shows; }
            set { shows = value; }
        }
	}

}
