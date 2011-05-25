using System;
using Base.AbstractClasses;
using Cinema.Models;
using Database.Interfaces;
using Database.Models;
using TicketOperations.PublicInterfaceMembers;

namespace TicketOperations.Models
{
    /// <summary>
    /// Repräsentiert eine Kinokarte die zu einer Vorstellung gehört.
    /// </summary>
    /// <remarks> Eine Kinokarte kann gekauft und oder reserviert werden.
    /// Ist eine Kinokarte 15 Minuten vor Beginn der Vorstellung reserviert, 
    /// aber nicht gekauft so wird die Reservierung für diese Karte storniert. </remarks>
    public class Kinokarte : Subject, IDatabaseObject
    {
        private int id;
        private IKinokarteBlockierungZugangsSchlüssel key;
        /// <summary>
        /// Gibt an, ob diese Karte bereits verkauft wurde.
        /// </summary>
        private bool _verkauft;
        /// <summary>
        /// Gibt an ob diese Karte reserviert wurde.
        /// </summary>
        private bool _reserviert;

        private bool _blockiert;
        /// <summary>
        /// Gibt an ob auf den Kaufpreis dieser Karte 10% Rabatt gewährt werden soll.
        /// </summary>
        private bool _rabatt;
        /// <summary>
        /// Der Preis der Kinokarte.
        /// </summary>
        private float _preis;
        /// <summary>
        /// Der zugehörige Sitz zu dieser Kinokarte.
        /// </summary>
        private Sitz sitz;
        /// <summary>
        /// Die Vorstellung zu der diese Kinokarte gehört.
        /// </summary>
        private Vorstellung vorstellung;
        /// <summary>
        /// Entity Manager für den Zugriff auf die Reservierungen.
        /// </summary>
        private EntityManager<Reservierung> _databaseReservation;

        /// <summary>
        /// Initializes a new instance of the <see cref="Kinokarte"/> class.
        /// </summary>
        /// <param name="preis"> Der Preis der Kinokarte. </param>
        /// <param name="sitz"> Der zugehörige Sitz dieser Vorstellung. </param>
        /// <param name="vorstellung"> Die zugehörige Vorstellung. </param>
        /// <remarks></remarks>
        public Kinokarte(float preis, Sitz sitz, Vorstellung vorstellung)
        {
            this._preis = preis;
            this.sitz = sitz;
            this.vorstellung = vorstellung;
            this._verkauft = false;
            this._reserviert = false;
            // Reservationsnummer erstellen
            this._reservationsnummer = vorstellung.GetHashCode() + " " + sitz.ToString();
        }
        
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Kinokarte"/> is Reserviert.
        /// </summary>
        /// <value><c>true</c> if Reserviert; otherwise, <c>false</c>.</value>
        /// <remarks></remarks>
        public bool Reserviert
        {
            get { return _reserviert; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Kinokarte"/> is discounted.
        /// This is true when it was bought buy a student/pupil and or pensioneer.
        /// The Rabatt is always 10%.
        /// </summary>
        /// <value><c>true</c> if the ticketprice is discounted; otherwise, <c>false</c>.</value>
        /// <remarks></remarks>
        public bool Rabatt
        {
            get { return _rabatt; }
            set { _rabatt = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Kinokarte"/> is sold.
        /// </summary>
        /// <value><c>true</c> if sold; otherwise, <c>false</c>.</value>
        /// <remarks></remarks>
        public bool Verkauft
        {
            get { return _verkauft; }
            set { _verkauft = value; }
        }

        /// <summary>
        /// Gets the _preis of the kinokarte, taking into account any Rabatt.
        /// </summary>
        /// <remarks></remarks>
        public float Preis
        {
            get {
                if (!_rabatt)
                {
                    return _preis;
                }
                else
                {
                    return _preis * 0.9f; // 10% Rabatt
                }
            }
        }

        /// <summary>
        /// Gets the Sitz that belongs to this kinokarte.
        /// </summary>
        /// <remarks></remarks>
        public Sitz Sitz
        {
            get { return sitz; }
        }

        /// <summary>
        /// Gets the vorstellung this kinokarte is for.
        /// </summary>
        /// <remarks></remarks>
        public Models.Vorstellung Vorstellung
        {
            get { return vorstellung; }
        }

        public bool Blockiert
        {
            get { return _blockiert; }
        }

        public IKinokarteBlockierungZugangsSchlüssel Blockieren()
        {
            if (key != null && Blockiert)
            {
                throw new TicketBlockedException();
            }

            this._blockiert = true;
            key = new KinokarteBlockierungZugangsSchlüssel();
            return key;
        }

        public void BlockierungAufheben(IKinokarteBlockierungZugangsSchlüssel key)
        {
            if (this.key != key)
            {
                throw new WrongAccessKeyException();
            }

            if (!this.Blockiert)
            {
                throw new TicketNotBlockedException();
            }

            this._blockiert = false;
        }

        public void Reservieren()
        {
            _reserviert = true;
        }

        public void ReservierungAufheben()
        {
            if (Blockiert)
            {
                throw new TicketBlockedException();
            }

            if (!Reserviert)
            {
                throw new TicketNotReservedException();
            }

            _reserviert = false;
            _rabatt = false;

            Reservierung reservierung = _databaseReservation.GetElements().Find(delegate(Reservierung r) { return r.Kinokarten.Contains(this); });
            reservierung.TicketEntfernen(this);
        }

        public void SetIdentifier(int id)
        {
            this.id = id;
        }

        public int GetIdentifier()
        {
            return id;
        }
    }

    public class TicketBlockedException : Exception
    {
    
    }

    public class TicketNotBlockedException : Exception
    {

    }

    public class WrongAccessKeyException : Exception
    {
    
    }

    public class TicketNotReservedException : Exception
    {
    
    }
}