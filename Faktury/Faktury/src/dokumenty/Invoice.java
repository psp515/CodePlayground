package dokumenty;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.Date;

import magazyn.Cargo;
import rabaty.Discount;

import static utils.Config.getConfig;


public class Invoice {
	Date dataSprzedazy;
	String kontrahent;
	ArrayList<InvoiceItem> pozycje;
	double suma;
	Discount discount;

	public Invoice(Date dataSprzedazy, String kontrahent)
	{
		this.dataSprzedazy=dataSprzedazy;
		this.kontrahent=kontrahent;
		pozycje=new ArrayList<InvoiceItem>();
		suma=0;
		discount = getConfig().getDiscount();
	}
	public void dodajPozycje(Cargo cargo, double ilosc)
	{
		InvoiceItem pozycja = new InvoiceItem(cargo, ilosc);
		pozycja.setPrice(discount.recalculate(pozycja.getPrice()));
		pozycje.add(pozycja);
		this.przeliczSume();
	}
	public double getTotal()
	{
		return suma;
	}
	public Date getSellDate()
	{
		return dataSprzedazy;
	}

	//jak sie zmieni cos na fakturze to trzeba wywolac te metode
	private void przeliczSume()
	{
		Iterator<InvoiceItem> iteratorPozycji=pozycje.iterator();
		InvoiceItem pozycja;
		suma=0;
		while(iteratorPozycji.hasNext())
		{
			pozycja = iteratorPozycji.next();
			suma += pozycja.getValue();
		}
	}
	public Iterator<InvoiceItem> getIteratorPozycji()
	{
		return pozycje.iterator();
	}
	public String getBuyer()
	{
		return this.kontrahent;
	}
	
	
}
