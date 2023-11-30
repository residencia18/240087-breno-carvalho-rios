namespace advocacia;
public class Exceptions {
    public class UniqueValueException : Exception {
        public UniqueValueException() {}

        public UniqueValueException(string message) : base(message) {}

        public UniqueValueException(string message, Exception innerException) : base(message, innerException) {}
    }
    
    public class EmptyInputException : Exception {
        public EmptyInputException() {}

        public EmptyInputException(string message) : base(message) {}

        public EmptyInputException(string message, Exception innerException) : base(message, innerException) {}
    }

    public class InvalidCpfException : Exception {
        public InvalidCpfException() {}

        public InvalidCpfException(string message) : base(message) {}

        public InvalidCpfException(string message, Exception innerException) : base(message, innerException) {}
    }

    public class InvalidCnaException : Exception {
        public InvalidCnaException() {}

        public InvalidCnaException(string message) : base(message) {}

        public InvalidCnaException(string message, Exception innerException) : base(message, innerException) {}
    }

    public class InvalidDateException : Exception {
        public InvalidDateException() {}

        public InvalidDateException(string message) : base(message) {}

        public InvalidDateException(string message, Exception innerException) : base(message, innerException) {}
    }
}
