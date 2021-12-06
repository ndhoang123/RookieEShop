$(function(){
	function toggleCreateShippingAddress() {
		var shippingAddressId = $('input[name=ShippingAddressId]:checked').val(),
			$createShipping = $('.create-shipping-address');

		if (shippingAddressId === "0") {
			$createShipping.show();
		}
		else {
			$createShipping.hide();
		}
	}

	$('input[name=ShippingAddressId]').on('change', function () {
		toggleCreateShippingAddress();
	});

	toggleCreateShippingAddress();
})