package printing;

import dokumenty.Invoice;
import dokumenty.InvoiceItem;

import java.util.Iterator;

public abstract class InvoicePrinter {

    protected void printHeader(Invoice invoice){
        System.out.println("=====================================================");
        System.out.println("FA z dnia: " + invoice.getSellDate().toString());
        System.out.println("Wystawiona dla: " + invoice.getBuyer());
    }

    protected void printItem(InvoiceItem item)
    {
        System.out.println("Towar: " + item.getName()+" Ilosc: " + item.getCount()+" Wartosc:" + item.getValue());
    }

    public void printInvoice(Invoice invoice)
    {
        printHeader(invoice);
        Iterator<InvoiceItem> iterator = invoice.getIteratorPozycji();
        while(iterator.hasNext())
        {
            InvoiceItem item = iterator.next();
            printItem(item);
        }
        printFooter(invoice);
    }

    private void printFooter(Invoice invoice) {
        System.out.println("Na kwote: " + invoice.getTotal());
        System.out.println("=====================================================");
    }
}
