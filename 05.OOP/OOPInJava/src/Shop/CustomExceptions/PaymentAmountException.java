package Shop.CustomExceptions;

public class PaymentAmountException extends IllegalArgumentException {

	public PaymentAmountException() {
		super();
	}

	public PaymentAmountException(String message) {
		super(message);
	}
}
