using ComplexAlgebra;
using System.Collections.Generic;

namespace Calculus
{
    /// <summary>
    /// A calculator for <see cref="Complex"/> numbers, supporting 2 operations ('+', '-').
    /// The calculator visualizes a single value at a time.
    /// Users may change the currently shown value as many times as they like.
    /// Whenever an operation button is chosen, the calculator memorises the currently shown value and resets it.
    /// Before resetting, it performs any pending operation.
    /// Whenever the final result is requested, all pending operations are performed and the final result is shown.
    /// The calculator also supports resetting.
    /// </summary>
    ///
    /// HINT: model operations as constants
    /// HINT: model the following _public_ properties methods
    /// HINT: - a property/method for the currently shown value
    /// HINT: - a property/method to let the user request the final result
    /// HINT: - a property/method to let the user reset the calculator
    /// HINT: - a property/method to let the user request an operation
    /// HINT: - the usual ToString() method, which is helpful for debugging
    /// HINT: - you may exploit as many _private_ fields/methods/properties as you like
    ///
    /// TODO: implement the calculator class in such a way that the Program below works as expected
    class Calculator
    {
        public const char OperationPlus = '+';
        public const char OperationMinus = '-';

        // TODO fix nullable
        private Stack<Complex?> _values;
        private Stack<char?> _operations;

        public Calculator()
        {
            _values = new Stack<Complex?>();
            _operations = new Stack<char?>();
        }

        // TODO fill this class
        public Complex Value { get; set; }

        public char? Operation
        {
            private get => _operations.Pop();
            set
            {
                _operations.Push(value);
                _values.Push(Value);
            }
        }

        public Complex Result { get; private set; }

        // TODO fix
        public void ComputeResult()
        {
            while (_values.Count > 1 && _operations.Count > 0)
            {
                var o1 = _values.Pop();
                var op = Operation;
                var o2 = Value;
                switch (op)
                {
                    case OperationPlus:
                        Result = o1 + o2;
                        break;
                    case OperationMinus:
                        Result = o1 - o2;
                        break;
                    default:
                        break;
                }
            }
        }

        public void Reset()
        {
            _values.Clear();
            _operations.Clear();
            Result = new Complex();
        }

        // TODO fix
        public override string ToString() => $"{Value}, {(_operations.Count > 0 ? _operations.Peek() : "null")}";
    }
}
