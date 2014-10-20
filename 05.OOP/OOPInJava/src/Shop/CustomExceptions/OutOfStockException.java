package Shop.CustomExceptions;

import java.security.InvalidParameterException;

public class OutOfStockException extends InvalidParameterException {

	public OutOfStockException() {
		super();
	}

	public OutOfStockException(String message) {
		super(message);
	}
}
