package Shop.products;

import Shop.enumarations.AgeRestriction;

public class Appliance extends ElecronicsProduct {
	private final int criticalQuantity = 50;
	private final static int guaranteePeriodInMounths = 6;
	
	public Appliance(String name, double price, int quantity,
			AgeRestriction ageRestriction, int guaranteePeriod) {
		super(name, price, quantity, ageRestriction, guaranteePeriodInMounths);
	}

	@Override
	public double getPrice(){
		if(this.getQuantity() < criticalQuantity){
			return 1.05 * this.price;
		} else{
			return this.price;
		}
	}
}
