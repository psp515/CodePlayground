package utils;


import rabatlosowy.LosowyRabat;

public class RandomPercentDiscountAdapter {

    private final LosowyRabat losowyRabat;

    public RandomPercentDiscountAdapter() {
        losowyRabat = new LosowyRabat();
    }

    public double getRandomPercentDiscount(){
        return 100 * losowyRabat.losujRabat();
    }
}
