package Shop;

import java.util.Date;

import Shop.CustomExceptions.OutOfStockException;
import Shop.CustomExceptions.PaymentAmountException;
import Shop.CustomExceptions.ProductExpiredException;
import Shop.CustomExceptions.PurchasePermissionDeniedException;
import Shop.enumarations.AgeRestriction;
import Shop.interfaces.Expiriable;
import Shop.products.Product;

public final class PurchaseManager {
	
	private PurchaseManager(){
		
	}
	
	public static void processPurchase(Customer customer, Product product){
		if (product.getQuantity() < 1) {
			throw new OutOfStockException("This product is out of stock!");
		}
		
		if (product instanceof Expiriable) {
			Date expirationDate = ((Expiriable) product).getExpirationDate();
			Date now = new Date();
			if (expirationDate.before(now)) {
				throw new ProductExpiredException("Product has expired!");
			}
		}
		
		if (customer.getBalance() < product.getPrice()) {
            throw new PaymentAmountException("You do not have enough money to buy this product!");
        }
		
		if ((product.getAgeRestriction() == AgeRestriction.Teenager && customer.getAge() < 13) || 
                (product.getAgeRestriction() == AgeRestriction.Adult && customer.getAge() < 18)) {
            throw new PurchasePermissionDeniedException("You are too young to buy this product!");
        }
		
		customer.setBalance(customer.getBalance() - product.getPrice());
		product.setQuantity(product.getQuantity() - 1);
	}
}
