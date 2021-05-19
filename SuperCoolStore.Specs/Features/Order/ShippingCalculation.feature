Feature: ShippingCalculation
Calculate Shipping price considering distance from distribution center. A fee should be applied to the order grand total
only if the total order weight is greater or equal to 30 kilograms. Also, the fee should be applied for every kilograms that
exceded the limit.

    @Shipping
    Scenario: Calculate shipping fee for order of total weight greater or equal to 30 kilograms
        Given the distance is 50 kilometers
        And the shipping fee is 0.05 cents
        And the total order weight is 30 kilograms
        When the fee is calculated
        Then the shipping value should be 25 dollars

    @Shipping
    Scenario: Shipping fee should be free if subtotal is greater than 200 dollars
        Given the shipping fee is 0.05 cents
        And the distance is 50 kilometers
        And an order is placed with the following items
          | Id | Name    | Price | Weight | HasDiscountOnCash | DiscountPercentage |
          | 1  | Mouse   | 5     | 0.250  | No                | 0                  |
          | 2  | Fridge  | 300   | 35     | Yes               | 7                  |
          | 3  | Monitor | 250   | 1.5    | Yes               | 5                  |
        When the order grand total is calculated
        Then the shipping fee should be 0
