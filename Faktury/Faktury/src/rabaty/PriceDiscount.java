package rabaty;

public class PriceDiscount implements Discount{

    private final double discount;

    public PriceDiscount(double discount) {
        this.discount = discount;
    }

    @Override
    public double recalculate(double cena) {
        return Math.max(cena - discount, 0);
    }
}
