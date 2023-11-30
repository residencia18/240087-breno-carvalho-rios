namespace advocacia;
public class Exceptions {
    public class UniqueValueException : Exception {
        public UniqueValueException() {}

        public UniqueValueException(string message) : base(message) {}

        public UniqueValueException(string message, Exception innerException) : base(message, innerException) {}
    }
}
