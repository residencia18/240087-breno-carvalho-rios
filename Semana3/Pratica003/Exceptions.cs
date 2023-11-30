namespace Pratica003;

public class Exceptions {
    public class ItemNotFoundException : Exception {
        public ItemNotFoundException() {}

        public ItemNotFoundException(string message) : base(message) {}

        public ItemNotFoundException(string message, Exception innerException) : base(message, innerException) {}
    }

    public class InsufficientStock : Exception {
        public InsufficientStock() {}

        public InsufficientStock(string message) : base(message) {}

        public InsufficientStock(string message, Exception innerException) : base(message, innerException) {}
    }

    public class NegativeStockChange : Exception {
        public NegativeStockChange() {}

        public NegativeStockChange(string message) : base(message) {}

        public NegativeStockChange(string message, Exception innerException) : base(message, innerException) {}
    }
}
