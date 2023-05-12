package utils;

import printing.DefaultInvocePrinter;
import printing.InvoicePrinter;
import rabaty.Discount;
import rabaty.PercentDiscount;

import java.io.DataInput;

public class Config {

    private static Config instance;
    public static Config getConfig(){

        if(instance == null)
            instance = new Config();

        return instance;
    }

    private Discount discount;
    private InvoicePrinter invoicePrinter;

    private Config()
    {
        discount = new PercentDiscount(0);
        invoicePrinter = new DefaultInvocePrinter();
    }

    public InvoicePrinter getInvoicePrinter() {
        return invoicePrinter;
    }

    public void setInvoicePrinter(InvoicePrinter invoicePrinter){
        this.invoicePrinter = invoicePrinter;
    }

    public Discount getDiscount(){
        return discount;
    }

    public void setDiscount(Discount newDiscount){
        discount = newDiscount;
    }
}
