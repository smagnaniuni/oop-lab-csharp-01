namespace Properties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A factory class for building <see cref="ISet{T}">decks</see> of <see cref="Card"/>s.
    /// </summary>
    public class DeckFactory
    {
        private string[] Seeds { get; set; }

        private string[] Names { get; set; }

        // TODO improve
        public IList<string> GetSeeds()
        {
            return Seeds.ToList();
        }

        // TODO improve
        public void SetSeeds(IList<string> seeds)
        {
            Seeds = seeds.ToArray();
        }

        // TODO improve
        public IList<string> GetNames()
        {
            return Names.ToList();
        }

        // TODO improve
        public void SetNames(IList<string> names)
        {
            Names = names.ToArray();
        }

        // TODO improve
        public int GetDeckSize()
        {
            return Names.Length * Seeds.Length;
        }

        /// TODO improve
        public ISet<Card> GetDeck()
        {
            if (Names == null || Seeds == null)
            {
                throw new InvalidOperationException();
            }

            return new HashSet<Card>(Enumerable
                .Range(0, Names.Length)
                .SelectMany(i => Enumerable
                    .Repeat(i, Seeds.Length)
                    .Zip(
                        Enumerable.Range(0, Seeds.Length),
                        (n, s) => Tuple.Create(Names[n], Seeds[s], n)))
                .Select(tuple => new Card(tuple))
                .ToList());
        }
    }
}
