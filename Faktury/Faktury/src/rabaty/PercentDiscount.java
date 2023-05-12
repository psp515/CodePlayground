package rabaty;

public class PercentDiscount implements Discount{

    private final double percentDiscount;

    public PercentDiscount(double percentDiscount) {
        if(percentDiscount < 0 || percentDiscount > 100)
            throw new IllegalArgumentException("Discount must be in range 0 - 1");
        this.percentDiscount = percentDiscount;
    }

    @Override
    public double recalculate(double cena) {
        return cena * (100-percentDiscount) / 100;
    }
}
