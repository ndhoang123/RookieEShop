var shippingAddressId = document.querySelector("input[name=ShippingAddressId]:checked").value;
const createShipping = document.getElementsByClassName("create-shipping-address");
const textAddress = document.querySelectorAll("input[type=text]");
const btn = document.getElementById("addOrder");

function toggleCreateShippingAddress(){
	console.log(shippingAddressId);
	if(shippingAddressId === "0"){
		createShipping[0].style.display = "block";
		textAddress.forEach(function(x){
			x.required = true;
		})
	}
	if(shippingAddressId !== "0"){
		console.log("B");
		createShipping[0].style.display = "none";
		textAddress.forEach(function(x){
			x.required = false;
		})
	}
}

document.querySelector('input[name=ShippingAddressId]').addEventListener('click', function(){
	toggleCreateShippingAddress();
})

toggleCreateShippingAddress();

btn.addEventListener("click", function(){
	alert("Hello world")
})