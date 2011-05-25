using System.Collections.Generic;

namespace TicketOperations.PublicInterfaceMembers
{
    public interface IPublicFilmprogramm
    {
        /// <summary>
        /// Gets or sets the list of shows that represent the shows that are shown in the week the movie program is responsible for.
        /// </summary>
        /// <value>The shows.</value>
        /// <remarks></remarks>
        /// <pre></pre>
        List<IPublicVorstellung> Vorstellungen { get; }

        int GetIdentifier();
    }
}