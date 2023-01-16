import React, {useState} from 'react'

export function Offer () {
  const [order_id, setOrderId] = useState("");
  const [price_in_cents, setPrice] = useState("");
  const [expected_delivery_datetime, setDate] = useState("");

  let handleSubmit = async (e) => {
    e.preventDefault();
    try {
      console.log(expected_delivery_datetime);
      let res = await fetch("https://pasd-webshop-api.onrender.com/api/delivery/", {
        headers: {
          'accept': 'application/json',
          'x-api-key': '4sqmKzToVkUoTsVfze4X',
          'Content-Type': 'application/json'
        },
        method: "POST",
        body: JSON.stringify({
          order_id: order_id,
          price_in_cents: price_in_cents,
          expected_delivery_datetime: expected_delivery_datetime,
        }),
      });
      let resJson = await res.json();
      if (res.status === 200) {
        setOrderId("");
        setPrice("");
        setDate("");
        alert("Delivery offer has been ");
        //window.location.replace('/delivery');
        console.log(resJson);
      } else if(res.status===400 || res.status===422) {
        console.log(resJson);
        alert("Order is already being delivered");
      } else {
        alert("Random error");
      }
    } catch (err) {
      console.log(err);
    }
  }
  
  return (
    <form onSubmit={handleSubmit} className = "mx-auto">
      <div class="mb-3">
        <label class="form-label">Order ID</label>
          <input
            type="text"
            defaultValue={order_id}
            onChange={(e) => setOrderId(e.target.value)}
            class="form-control"
          />
      </div>
      <div class="mb-3">
        <label class="form-label">
          Suggest price (in cents)
          <input
            type="text"
            defaultValue={price_in_cents}
            onChange={(e) => setPrice(e.target.value)}
            class="form-control"
          />
        </label>
      </div>
      <div class="mb-3">
        <label class="form-label">
          Suggest date
          <input
            type="datetime-local"
            defaultValue={expected_delivery_datetime}
            onChange={(e) => setDate(e.target.value + ":04.390Z")}
            class="form-control"
          />
        </label>
      </div>
      <button type="submit" class="btn btn-primary">Submit</button>
    </form>
  );
}
