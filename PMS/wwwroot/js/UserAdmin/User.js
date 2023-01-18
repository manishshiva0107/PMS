function SuccessAjaxMethod(response) {
	alert(response.result.message).then(function () {
		location.reload();
	});
}

function ErrorAjaxMethod(response) {
	alert("Failed to save details.");
}