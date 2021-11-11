$(function(){
	function toggleCreateShippingAddress() {
		var $createShipping = $('.create-shipping-address'),
			shippingAddressId = $('input[name=ShippingAddressId]:checked').val();

		if (shippingAddressId === "0") {
			$createShipping.show();
		}
		else {
			$createShipping.hide();
		}
	}

	toggleCreateShippingAddress();
})