const createShipping = document.querySelector(".create-shipping-address");
const textAddress = document.querySelectorAll("input[type=text]");

function toggleCreateShippingAddress(addressValue) {
  createShipping.style.display = addressValue === "0" ? "block" : "none";
  textAddress.forEach(function (x) {
    x.required = addressValue === "0";
  });
}

// for re-render when select the other input.
var shippingAddressElms = document.querySelectorAll(
  "input[name=ShippingAddressId]"
);
shippingAddressElms.forEach(function (elm) {
  elm.addEventListener("change", function (event) {
    toggleCreateShippingAddress(event.target.value);
  });
});

// get last input radio.
// for first render.
toggleCreateShippingAddress(
  shippingAddressElms[shippingAddressElms.length - 1].checked ? "0" : ""
);

