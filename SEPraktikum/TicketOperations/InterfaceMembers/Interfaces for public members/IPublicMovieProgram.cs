using System.Collections.Generic;

namespace TicketOperations.InterfaceMembers
{
    public interface IPublicMovieProgram
    {
        /// <summary>
        /// Gets or sets the list of shows that represent the shows that are shown in the week the movie program is responsible for.
        /// </summary>
        /// <value>The shows.</value>
        /// <remarks></remarks>
        List<IPublicShow> Shows { get; }

        int GetIdentifier();
    }
}