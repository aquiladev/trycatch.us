var trycatchCart = {
	loadWaiting: false,
	topcartselector: '',

	init: function (topcartselector) {
		this.loadWaiting = false;
		this.topcartselector = topcartselector;
	},

	setLoadWaiting: function (display) {
		this.loadWaiting = display;
	},

	addtocart: function (url) {
		if (this.loadWaiting != false) {
			return;
		}
		this.setLoadWaiting(true);

		$.ajax({
			cache: false,
			url: url,
			type: 'post',
			success: function (response) {
				if (response.updatetopcartsectionhtml) {
					$(trycatchCart.topcartselector).html(response.updatetopcartsectionhtml);
				}
				if (response.message) {
					if (response.success == true) {
						displayBarNotification(response.message, 'success', 3500);
					} else {
						displayBarNotification(response.message, 'error', 0);
					}
					return false;
				}
				if (response.redirect) {
					location.href = response.redirect;
					return true;
				}
				return false;
			},
			complete: function () {
				trycatchCart.setLoadWaiting(false);
			},
			error: function () {
				alert('Failed to add the artilce to the cart.');
			}
		});
	}
};

var barNotificationTimeout;
function displayBarNotification(message, messagetype, timeout) {
	clearTimeout(barNotificationTimeout);

	var cssclass = 'success';
	if (messagetype == 'success') {
		cssclass = 'success';
	}
	else if (messagetype == 'error') {
		cssclass = 'error';
	}
	$('#bar-notification')
		.removeClass('success')
		.removeClass('error');
	$('#bar-notification .content').remove();

	var htmlcode = '';
	if ((typeof message) == 'string') {
		htmlcode = '<p class="content">' + message + '</p>';
	} else {
		for (var i = 0; i < message.length; i++) {
			htmlcode = htmlcode + '<p class="content">' + message[i] + '</p>';
		}
	}
	$('#bar-notification').append(htmlcode)
		.addClass(cssclass)
		.fadeIn('slow')
		.mouseenter(function() {
			clearTimeout(barNotificationTimeout);
		});

	$('#bar-notification .close').unbind('click').click(function () {
		$('#bar-notification').fadeOut('slow');
	});

	if (timeout > 0) {
		barNotificationTimeout = setTimeout(function () {
			$('#bar-notification').fadeOut('slow');
		}, timeout);
	}
}