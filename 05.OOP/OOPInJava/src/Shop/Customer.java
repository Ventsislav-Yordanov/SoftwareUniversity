package Shop;

import java.security.InvalidParameterException;

public class Customer {
	private String name;
	private int age;
	private double balance;

	public Customer(String name, int age, double balance) {
		this.name = name;
		this.age = age;
		this.balance = balance;
	}

	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		if(name == null || name == ""){
			throw new InvalidParameterException("Name cannot be empty or null!");
		}
		
		this.name = name;
	}
	
	public int getAge() {
		return age;
	}
	
	public void setAge(int age) {
		if (age < 0) {
			throw new InvalidParameterException("Age cannot be negative!");
		}
		
		this.age = age;
	}
	
	public double getBalance() {
		return balance;
	}
	
	public void setBalance(double balance) {
		if (balance < 0) {
			throw new InvalidParameterException("Balance cannot be negative!");
		}
		
		this.balance = balance;
	}
}
