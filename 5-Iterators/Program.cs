namespace Iterators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The runnable entrypoint of the exercise.
    /// </summary>
    public class Program
    {
        /// <inheritdoc cref="Program" />
        public static void Main()
        {
            const int len = 50;
            int?[] numbers = new int?[len];
            Random rand = new Random();
            for (int i = 0; i < len; i++)
            {
                if (rand.NextDouble() > 0.2)
                {
                    numbers[i] = rand.Next(len);
                }
            }

            IDictionary<int, int> occurrences = numbers
                .Map(optN => {
                    Console.Write(optN.ToString() + ",");
                    return optN;
                })
                .SkipSome(1)
                .TakeSome(len - 2)
                .Filter(optN => optN.HasValue)
                .Map(optN => optN.Value)
                .Reduce(new Dictionary<int, int>(), (d, n) => {
                    if (!d.ContainsKey(n))
                    {
                        d[n] = 1;
                    }
                    else
                    {
                        d[n]++;
                    }

                    return d;
                });

            Console.WriteLine();

            foreach (KeyValuePair<int, int> kv in occurrences)
            {
                Console.WriteLine(kv);
            }

            Console.WriteLine();

            // Lazy operations won't work unless...

            // ...you use the Enumerator manually...
            var iterator = Java8StreamOperations.Range(0, 3).GetEnumerator();
            Console.WriteLine(iterator.Current);
            while (iterator.MoveNext())
            {
                Console.Write($"{iterator.Current},");
            }
            Console.WriteLine();

            // ...or a foreach
            foreach (var item in Java8StreamOperations.Range(0, 5))
            {
                Console.Write($"{item},");
            }
            Console.WriteLine();

            // ...or a reduce
            Java8StreamOperations.Range(0, 100)
                .TakeWhile(n => n < 10)
                .Peek(n => Console.Write($"{n},"))
                .Reduce(new Dictionary<int, int>(), (o, n) => { o[n] = 1; return o; });
            Console.WriteLine();

            // ...or a ForEach
            Java8StreamOperations.Range(0, 100)
                .TakeWhile(n => n < 15)
                .ForEach(n => Console.Write($"{n},"));
            Console.WriteLine();

            // For eg. this won't display anything
            Java8StreamOperations.Range(0, 100)
                .TakeWhile(n => n < 20)
                .Peek(n => Console.Write($"{n},"));
            Console.WriteLine();
            // Equivalent in java: IntStream.range(0, 100).takeWhile(n -> n < 20).peek(n -> System.out.print(n + ","))

            Java8StreamOperations.Range(0, 10)
                .SkipWhile(n => n < 5)
                .ForEach(n => Console.Write($"{n},"));
        }
    }
}
