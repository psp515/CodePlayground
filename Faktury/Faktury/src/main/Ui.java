package main;

import java.util.Calendar;

import magazyn.Cargo;
import dokumenty.Invoice;
import printing.InvoicePrinter;

import static utils.Config.getConfig;

public class Ui {

	public static void main(String[] args) {
		Calendar now = Calendar.getInstance();

		Cargo item = new Cargo("Item");

		Cargo boots = new Cargo("Boots");
		Cargo newBalance = new Cargo(1000, "New Balance");
		Cargo nike = new Cargo(200, "Nike Air");

		Cargo shirt = new Cargo("Shirt");
		Cargo adidasShirt = new Cargo(200, "Adidas T-Shirt M");
		Cargo nikeShirt = new Cargo(250, "Nike T-Shirt S");

		item.addSubcategory(boots);
		item.addSubcategory(shirt);

		boots.addSubcategory(newBalance);
		boots.addSubcategory(nike);

		shirt.addSubcategory(adidasShirt);
		shirt.addSubcategory(nikeShirt);

		System.out.println("---- Item");
		for(Cargo cargo : item.getSubcategories())
		{
			handleCargo(cargo);
		}

		//I przykladowa fakture
		Invoice f=new Invoice(now.getTime(),"Fido");
		f.dodajPozycje(adidasShirt,2);
		f.dodajPozycje(newBalance, 2);

		InvoicePrinter invoicePrinting = getConfig().getInvoicePrinter();
		invoicePrinting.printInvoice(f);

	}

	private static void handleCargo(Cargo cargo) {
		if(cargo.getSubcategories().size() != 0)
		{
			System.out.println("--- " + cargo.getName());
			for(Cargo smallerCargo : cargo.getSubcategories())
				handleCargo(smallerCargo);
		}
		else{
			System.out.println("-- " + cargo.getName() + ",Price: " + cargo.getPrice());
		}
	}
}
