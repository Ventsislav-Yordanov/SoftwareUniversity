package Shop.CustomExceptions;

public class ProductExpiredException extends IllegalArgumentException {

	public ProductExpiredException() {
		super();
	}

	public ProductExpiredException(String message) {
		super(message);
	}
}
