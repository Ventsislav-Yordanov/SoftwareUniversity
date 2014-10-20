package Shop.products;

import java.util.Date;
import java.time.Instant;

import Shop.enumarations.AgeRestriction;
import Shop.interfaces.Expiriable;

public class FoodProduct extends Product implements Expiriable {
	private Date expirationDate;
	
	public FoodProduct(String name, double price, int quantity, 
			AgeRestriction ageRestriction, Date expirationDate) {
		super(name, price, quantity, ageRestriction);
		this.setExpirationDate(expirationDate);
	}
	
	@Override
	public double getPrice() {
		Date now = Date.from(Instant.now());
        long expire = now.getTime() + 1000 * 60 * 60 * 24 * 15;

        if (this.getExpirationDate() == null || this.getExpirationDate().getTime() <= expire) {
            return 0.7 * this.price;
        } else {
            return this.price;
        }
	}

	public Date getExpirationDate() {
		return expirationDate;
	}

	public void setExpirationDate(Date expirationDate) {
		this.expirationDate = expirationDate;
	}
	
	@Override
    public String toString(){
		String expirationDateToString = String.format(", expires on: %s", this.getExpirationDate());
        return super.toString() + expirationDateToString;
    }
}
