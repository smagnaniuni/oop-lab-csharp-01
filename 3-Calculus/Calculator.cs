using ComplexAlgebra;
using System;
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

        private Stack<Complex?> _values;
        private Stack<char?> _operations;
        private Complex? _result = null;

        public Calculator()
        {
            _values = new Stack<Complex?>();
            _operations = new Stack<char?>();
        }

        public Complex? Value
        {
            get => _result;
            set
            {
                _result = value;
                Console.WriteLine(value);
            }
        }

        public char? Operation
        {
            set
            {
                _operations.Push(value);
                _values.Push(Value);
                _result = null;
            }
        }

        public void ComputeResult()
        {
            while (_values.Count > 0 && _operations.Count > 0)
            {
                var op = _operations.Pop();
                var o1 = _values.Pop();
                var o2 = Value ?? new Complex();
                switch (op)
                {
                    case OperationPlus:
                        _result = o1 + o2;
                        break;
                    case OperationMinus:
                        _result = o1 - o2;
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
            _result = null;
        }

        public override string ToString() => $"{(_result?.ToString() ?? "null")}, {(_operations.Count > 0 ? _operations.Peek() : "null")}";
    }
}
