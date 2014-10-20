package Shop.products;

import java.security.InvalidParameterException;
import Shop.enumarations.AgeRestriction;

public abstract class ElecronicsProduct extends Product {
	private int guaranteePeriod;

	public ElecronicsProduct(String name, double price, int quantity,
			AgeRestriction ageRestriction, int guaranteePeriod) {
		super(name, price, quantity, ageRestriction);
		this.setGuaranteePeriod(guaranteePeriod);
	}

	public int getGuaranteePeriod() {
		return guaranteePeriod;
	}

	public void setGuaranteePeriod(int guaranteePeriod) {
		if (guaranteePeriod < 0) {
            throw new InvalidParameterException("Guarantee period cannot be negative!");
        }
		
		this.guaranteePeriod = guaranteePeriod;
	}
}
