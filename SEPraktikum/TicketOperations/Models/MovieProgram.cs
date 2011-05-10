using System;
using System.Collections.Generic;
using Base.AbstractClasses;

namespace TicketOperations.Models {
    /// <summary>
    /// Represents the movie program of a specific week.
    /// The movie program contains all shows that will be shown in the specific week.
    /// </summary>
    /// <remarks></remarks>
	public class MovieProgram : Subject  {
        /// <summary>
        /// The starting date of the movie program.
        /// From this date the movie program contains all shows that will be shown for the duration of 7 days.
        /// </summary>
        private DateTime startDateTime;
        /// <summary>
        /// The shows that are shown in the week the movie program represents.
        /// </summary>
        private List<Show> shows;
        /// <summary>
        /// Movie programs must be published by the admin before beeing visible to customers.
        /// </summary>
        private bool published;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieProgram"/> class.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <param name="shows">The shows.</param>
        /// <remarks></remarks>
        public MovieProgram(DateTime startTime, List<Show> shows)
        {
            startDateTime = startTime;
            this.shows = shows;
            published = false;
        }

        /// <summary>
        /// Publishes this movie program. It can now be seen by the customers.
        /// </summary>
        /// <remarks></remarks>
        public void Publish() 
        {
            published = true;
        }

        /// <summary>
        /// Gets or sets the list of shows that represent the shows that are shown in the week the movie program is responsible for.
        /// </summary>
        /// <value>The shows.</value>
        /// <remarks></remarks>
        public List<Show> Shows
        {
            get { return shows; }
            set { shows = value; }
        }
	}

}
