package Shop.products;

import Shop.enumarations.AgeRestriction;

public class Computer extends ElecronicsProduct {

	private final int reductionQuantity = 1000;
	private final static int guaranteePeriodInMounths = 24;
	
	public Computer(String name, double price, int quantity,
			AgeRestriction ageRestriction, int guaranteePeriod) {
		super(name, price, quantity, ageRestriction, guaranteePeriodInMounths);
	}
	
	@Override
	public double getPrice(){
		if(this.getQuantity() > reductionQuantity){
			return 0.95 * this.price;
		} else{
			return this.price;
		}
	}
}
