using System.Collections.Generic;

namespace TicketOperations.Models
{
    public interface NeededMovieProgramMembers
    {
        /// <summary>
        /// Publishes this movie program. It can now be seen by the customers.
        /// </summary>
        /// <remarks></remarks>
        void Publish();

        /// <summary>
        /// Gets or sets the list of shows that represent the shows that are shown in the week the movie program is responsible for.
        /// </summary>
        /// <value>The shows.</value>
        /// <remarks></remarks>
        List<Show> Shows { get; set; }
    }
}