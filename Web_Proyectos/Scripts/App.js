function ValidarFecha(fechaini, fechafin) {
	var _fechaini = new Date(fechaini);
	var _fechafin = new Date(fechafin);
	if (_fechafin > _fechaini) {
		return true;
	}
	else {
		return false;
	}
}
function LoadingOverlayShow(id)
{
	
	$(id).LoadingOverlay("show",
		{
		
			color: "rgba(255,255,255,0.5)",
			image: "/Content/loading2.gif",
			ImageResizeFactor: 0.6,
			//ImageAnimation: "2000ms rotate_right",
		});
}
function LoadingOverlayHide(id) {
	$(id).LoadingOverlay("hide");
}
function getDataCombobox(path, myCallback) {//Para cargar Combox 
	$.ajax({
		type: "GET",
		url: path,
		dataType: "json",
		success: function (result) {
			return myCallback(result.data);
			
			//			getData("departamentos/getdepartamentos", function (result) {
			//				$.each(result.data, function (key, item) {
			//					$("#Departamento").append("<option value=" + item.DepartamentoId + ">" + item.NombreDepartamento + "</option>");
			//				}
			//})
		},
		error: function (data) {
			$.alert("Error");
		}
	})
}