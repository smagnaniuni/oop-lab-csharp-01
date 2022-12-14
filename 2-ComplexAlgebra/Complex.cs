using System;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        // TODO: fill this class\
        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
        public Complex() : this(0, 0)
        {
        }

        public double Real { get; }
        public double Imaginary { get; }
        public double Modulus => Math.Sqrt(Real * Real + Imaginary * Imaginary);
        public double Phase => Math.Atan2(Imaginary, Real);

        /// <summary>
        /// Returns the addition
        /// </summary>
        /// <param name="i"> The other Complex number to sum </param>
        /// <returns></returns>
        public Complex Plus(Complex i) => this + i;

        /// <summary>
        /// Returns the subtraction
        /// </summary>
        /// <param name="i"> The other Complex number to subtract </param>
        /// <returns></returns>
        public Complex Minus(Complex i) => this - i;

        /// <summary>
        /// Returns the complement
        /// </summary>
        /// <returns></returns>
        public Complex Complement() => new Complex(Real, -Imaginary);

        public override string ToString()
        {
            var re = $"{Real}";
            var im = $"{(Imaginary != 0 ? ((Math.Abs(Imaginary) != 1 ? Math.Abs(Imaginary) : "") + "i") : "")}";
            return re + $"{(Imaginary > 0 ? " + " : (Imaginary < 0 ? " - " : ""))}" + im;
        }

        public override bool Equals(object obj) => obj is Complex complex &&
                                                   Real == complex.Real &&
                                                   Imaginary == complex.Imaginary;

        public override int GetHashCode() => HashCode.Combine(Real, Imaginary);

        public static Complex operator +(Complex c1, Complex c2) => new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        public static Complex operator -(Complex c1, Complex c2) => new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
    }
}