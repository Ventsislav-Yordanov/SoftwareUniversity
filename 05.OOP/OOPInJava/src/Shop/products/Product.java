package Shop.products;

import java.security.InvalidParameterException;

import Shop.enumarations.AgeRestriction;
import Shop.interfaces.Buyable;

public abstract class Product implements Buyable {
	private String name;
	protected double price;
	private int quantity;
	AgeRestriction ageRestriction;
	
	public Product(String name, double price, int quantity, AgeRestriction ageRestriction) {
		this.setName(name);
		this.setPrice(price);
		this.setQuantity(quantity);
		this.setAgeRestriction(ageRestriction);
	}
	
	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		if(name == null || name == ""){
			throw new InvalidParameterException("Name cannot be null or empty");
		}
		
		this.name = name;
	}
	
	public double getPrice() {
		return price;
	}
	
	public void setPrice(double price) {
		if(price < 0){
			throw new InvalidParameterException("Price cannot be negative");
		}
		
		this.price = price;
	}
	
	public AgeRestriction getAgeRestriction() {
		return ageRestriction;
	}
	
	public void setAgeRestriction(AgeRestriction ageRestriction) {
		this.ageRestriction = ageRestriction;
	}
	

	public int getQuantity() {
		return quantity;
	}

	public void setQuantity(int quantity) {
		if (quantity < 0) {
            throw new InvalidParameterException("Product quantity cannot be negative!");
        } 
		
		this.quantity = quantity;
	}

	@Override
	public String toString() {
		String productToString = String.format(
				"Name : %s, Price: %.2f, Quanity : %d",
				this.getName(), this.getPrice(), this.getQuantity());
		
		return productToString;
	}
}
