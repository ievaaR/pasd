namespace ddapi.Models;

public class Delivery {
      public string expected_delivery_datetime { get; set; } = null!;
      public string actual_delivery_datetime { get; set; } = null!;
      public int order_id{ get; set; }
      public int cost_in_cents{ get; set; }
      public string status{ get; set; } = null!;
      public int id { get; set; }
}