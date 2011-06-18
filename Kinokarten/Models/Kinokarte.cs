using System;
using Base.AbstractClasses;
using Database.Interfaces;
using Database.Models;
using Kino.Schnittstelle;
using Kinokarten.Schnittstelle;
using Kinokarten.Schnittstelle.Interfaces;

namespace Kinokarten.Models
{
    /// <summary>
    /// Repr�sentiert eine Kinokarte die zu einer Vorstellung geh�rt.
    /// </summary>
    /// <remarks> Eine Kinokarte kann gekauft und oder reserviert werden.
    /// Ist eine Kinokarte 15 Minuten vor Beginn der Vorstellung reserviert, 
    /// aber nicht gekauft so wird die Reservierung f�r diese Karte storniert. </remarks>
    internal class Kinokarte : Subject, IDatabaseObject
    {
        /// <summary>
        /// Der Preis der Kinokarte.
        /// </summary>
        private readonly float _preis;

        /// <summary>
        /// Der zugeh�rige Sitz zu dieser Kinokarte.
        /// </summary>
        private readonly ISitz _sitz;

        /// <summary>
        /// Die Vorstellung zu der diese Kinokarte geh�rt.
        /// </summary>
        private readonly Vorstellung _vorstellung;

        /// <summary>
        /// Gibt an, ob diese Karte 
        /// </summary>
        private bool _blockiert;

        /// <summary>
        /// Gibt an ob auf den Kaufpreis dieser Karte 10% Rabatt gew�hrt werden soll.
        /// </summary>
        private bool _rabatt;

        /// <summary>
        /// Gibt an ob diese Karte reserviert wurde.
        /// </summary>
        private bool _reserviert;

        /// <summary>
        /// Entity Manager f�r den Zugriff auf die Reservierungen.
        /// </summary>
        private EntityManager<Reservierung> _reservierungen;

        private int id;

        /// <summary>
        /// Wenn die Kinokarte blockiert ist wird dieser Schl�ssel ben�tigt, um die Blockierung aufzuheben.
        /// Wird erst zugewiesen, wenn die Kinokarte initial blockiert wird.
        /// </summary>
        private IKinokarteBlockierungZugangsSchl�ssel zugangsSchl�ssel;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="Kinokarte"/> Klasse.
        /// </summary>
        /// <param name="preis"> Der Preis der Kinokarte. </param>
        /// <param name="sitz"> Der zugeh�rige Sitz dieser Vorstellung. </param>
        /// <param name="vorstellung"> Die zugeh�rige Vorstellung. </param>
        /// <remarks></remarks>
        public Kinokarte(float preis, ISitz sitz, Vorstellung vorstellung)
        {
            _preis = preis;
            _sitz = sitz;
            _vorstellung = vorstellung;
            Verkauft = false;
            _reserviert = false;
            _blockiert = false;

            EntityManager<Kinokarte> kinokarten = new EntityManager<Kinokarte>();
            kinokarten.AddElement(this);
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
        public bool Verkauft { get; set; }

        /// <summary>
        /// Gets the _preis of the kinokarte, taking into account any Rabatt.
        /// </summary>
        /// <remarks></remarks>
        public float Preis
        {
            get
            {
                if (!_rabatt)
                {
                    return _preis;
                }
                else
                {
                    return _preis*0.9f; // 10% Rabatt
                }
            }
        }

        /// <summary>
        /// Gets the Sitz that belongs to this kinokarte.
        /// </summary>
        /// <remarks></remarks>
        public ISitz Sitz
        {
            get { return _sitz; }
        }

        /// <summary>
        /// Gets the vorstellung this kinokarte is for.
        /// </summary>
        /// <remarks></remarks>
        public Vorstellung Vorstellung
        {
            get { return _vorstellung; }
        }

        public bool Blockiert
        {
            get { return _blockiert; }
        }

        public IKinokarteBlockierungZugangsSchl�ssel Blockieren()
        {
            //Console.WriteLine("Blockiert!");
            //if (zugangsSchl�ssel != null && Blockiert)
            //{
            //    // Kinokarte ist bereits blockiert!
            //    throw new KinokarteBlockiertException();
            //}

            _blockiert = true;
            zugangsSchl�ssel = new KinokarteBlockierungZugangsSchl�ssel();
            return zugangsSchl�ssel;
        }

        public void BlockierungAufheben(IKinokarteBlockierungZugangsSchl�ssel key)
        {
            if (zugangsSchl�ssel != key)
            {
                throw new Ung�ltigerZugangsschl�sselException();
            }

            //if (!Blockiert)
            //{
            //    throw new KinokarteNichtBlockiertException();
            //}

            _blockiert = false;
        }

        public void Reservieren()
        {
            _reserviert = true;
        }

        public void ReservierungAufheben()
        {
            //if (Blockiert)
            //{
            //    throw new KinokarteBlockiertException();
            //}

            //if (!Reserviert)
            //{
            //    throw new KinokarteNichtReserviertException();
            //}

            _reserviert = false;
            _rabatt = false;

            Reservierung reservierung =
                _reservierungen.GetElements().Find(delegate(Reservierung r) { return r.Kinokarten.Contains(this); });
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

    public class KinokarteBlockiertException : Exception
    {
    }

    public class KinokarteNichtBlockiertException : Exception
    {
    }

    public class Ung�ltigerZugangsschl�sselException : Exception
    {
    }

    public class KinokarteNichtReserviertException : Exception
    {
    }
}