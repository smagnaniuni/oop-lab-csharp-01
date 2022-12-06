namespace Properties
{
    using System;

    /// <summary>
    /// The class models a card.
    /// </summary>
    public class Card
    {
        private string Seed { get; }
        private string Name { get; }
        private int Ordinal { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="name">the name of the card.</param>
        /// <param name="seed">the seed of the card.</param>
        /// <param name="ordinal">the ordinal number of the card.</param>
        public Card(string name, string seed, int ordinal)
        {
            Name = name;
            Ordinal = ordinal;
            Seed = seed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="tuple">the informations about the card as a tuple.</param>
        internal Card(Tuple<string, string, int> tuple) : this(tuple.Item1, tuple.Item2, tuple.Item3)
        {
        }

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString()
        {
            // TODO understand string interpolation
            return $"{this.GetType().Name}(Name={Name}, Seed={Seed}, Ordinal={Ordinal})";
        }

        // TODO generate Equals(object obj)
        public override bool Equals(object obj)
        {
            return obj is Card card &&
                   Seed == card.Seed &&
                   Name == card.Name &&
                   Ordinal == card.Ordinal;
        }

        // TODO generate GetHashCode()
        public override int GetHashCode()
        {
            return HashCode.Combine(Seed, Name, Ordinal);
        }
    }
}
