package printing;

import dokumenty.Invoice;

public class CrazyInvoicePrinter extends InvoicePrinter
{
    protected void printFooter(Invoice invoice)
    {
        System.out.println("=====================================================");
        System.out.println("Na kwote: " + invoice.getTotal());
        System.out.println("The PRICE is CRAZY");
    }
}
