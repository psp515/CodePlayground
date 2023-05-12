package magazyn;

import java.util.ArrayList;
import java.util.List;

public class Cargo {
	private double price;
	private String name;

	List<Cargo> subcategories = new ArrayList<>();

	public List<Cargo> getSubcategories() {
		return subcategories;
	}

	public void addSubcategory(Cargo subcategories) {
		this.subcategories.add(subcategories);
	}

	public Cargo(String name){
		this.name = name;
	}

	public Cargo(double price, String name) {
		this.price = price;
		this.name = name;
	}
	
	// operacje na cenie
	public void setPrice(double cena)
	{
		this.price =cena;
	}
	public double getPrice()
	{
		return price;
	}
	// operacje na nazwie towaru
	public String getName()
	{
		return name;
	}
	public void setName(String name)
	{
		this.name = name;
	}
}
