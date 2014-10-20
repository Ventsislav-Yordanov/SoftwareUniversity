package Shop.CustomExceptions;

public class PurchasePermissionDeniedException extends IllegalArgumentException {

	public PurchasePermissionDeniedException() {
		super();
	}

	public PurchasePermissionDeniedException(String message) {
		super(message);
	}
}
