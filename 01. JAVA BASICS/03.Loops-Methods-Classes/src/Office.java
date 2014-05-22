public class Office implements Comparable<Office> {
	private String town;
	private double income;
	
	public Office(String town, double income) {
		super();
		this.town = town;
		this.income = income;
	}

	public String getTown() {
		return town;
	}

	public void setTown(String town) {
		this.town = town;
	}

	public double getIncome() {
		return income;
	}

	public void setIncome(double income) {
		this.income = income;
	}
	
	@Override
	public int compareTo(Office off) {
		return this.town.compareTo(off.getTown());
	}
}
