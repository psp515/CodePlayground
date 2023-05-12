package dokumenty;

import magazyn.Cargo;

public class InvoiceItem {
	private Cargo cargo;
	private double price;
	private double count;
	private double value;
	private String name;

	public InvoiceItem(Cargo cargo, double ilosc) {
		this.cargo = cargo;
		this.count = ilosc;
		this.price = cargo.getPrice();
		this.name = cargo.getName();
		this.recalculate();
	}

	public void setCargo(Cargo cargo) {
		this.cargo = cargo;
		this.price = cargo.getPrice();
		this.recalculate();
	}

	public double getCount() {
		return count;
	}

	public void setCount(double count) {
		this.count = count;
		this.recalculate();
	}

	public double getPrice()
	{
		return this.price;
	}
	
	public void setPrice(double price) {
		this.price = price;
		this.recalculate();
	}

	public String getName() {
		return name;
	}

	public double getValue() {
		return value;
	}

	// jak sie zmieni cos w pozycji to trzeba wywolac te metode
	private void recalculate() {
		this.value = this.count * this.price;
	}

}
