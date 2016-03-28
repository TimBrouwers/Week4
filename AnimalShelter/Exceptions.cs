using System;

namespace AnimalShelter
{
    public class ExistingChipNumberException : Exception
    {
        public ExistingChipNumberException()
        {
        }

        public ExistingChipNumberException(string message) : base(message)
        {
        }

        public ExistingChipNumberException(string message, Exception inner) : base(message, inner)
        {
        }

    }

    public class WrongInputException : Exception
    {
        public WrongInputException()
        {
        }

        public WrongInputException(string message) : base(message)
        {
        }

        public WrongInputException(string message, Exception inner) : base(message, inner)
        {
        }

    }
}
