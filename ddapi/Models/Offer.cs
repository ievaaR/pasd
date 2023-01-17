namespace ddapi.Models;

public class Offer {
      public int order_id{ get; set; }
      public int price_in_cents{ get; set; }
      public string expected_delivery_datetime{ get; set; } = null!;
}