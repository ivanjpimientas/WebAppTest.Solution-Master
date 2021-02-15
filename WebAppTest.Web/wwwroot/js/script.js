/*=============================================
AGREGAR RED
=============================================*/

$(document).on("click", ".addNetwork", function () {
	var url = $("#url_red").val();
	var icono = $("#icono_red").val().split(",")[0];
	var color = $("#icono_red").val().split(",")[1];

	$(".listadoRed").append(`
		<div class="col-sm-12">
            <label style="color:white;">Lorem Imp </label>
            <div class="input-group">
                <span class="input-group-addon"><i class="`+ icono + `"></i></span>
                <input type="text" class="form-control" value="`+ url + `">
                <span class="input-group-addon eliminarRed" style="cursor:pointer" red="`+ icono + `" url="` + url + `"><i class="fa fa-close"></i></span>
            </div>
        </div>
	`)

	//Actualizar el registro de la BD
	var listaRed = JSON.parse($("#ApplicationBusiness_SocialNetworks").val());

	listaRed.push({
		"url": url,
		"icono": icono,
		"background": color
	})

	$("#ApplicationBusiness_SocialNetworks").val(JSON.stringify(listaRed));
})

/*=============================================
ELIMINAR RED
=============================================*/
$(document).on("click", ".eliminarRed", function () {

	var listaRed = JSON.parse($("#ApplicationBusiness_SocialNetworks").val());
	var red = $(this).attr("red");
	var url = $(this).attr("url");

	for (var i = 0; i < listaRed.length; i++) {
		if (red == listaRed[i]["icono"] && url == listaRed[i]["url"]) {
			listaRed.splice(i, 1);
			$(this).parent().parent().parent().parent().remove();
			$("#ApplicationBusiness_SocialNetworks").val(JSON.stringify(listaRed));
		}
	}
})

/*=============================================
PREVISUALIZAR IMÁGENES TEMPORALES
=============================================*/
$("input[type='file']").change(function () {
	var imagen = this.files[0];
	var tipo = $(this).attr("name");

	/*=============================================
    VALIDAMOS EL FORMATO DE LA IMAGEN SEA JPG O PNG
    =============================================*/
	if (imagen["type"] != "image/jpeg" && imagen["type"] != "image/png" && imagen["type"] != "application/pdf") {
		$("input[type='file']").val("");
		notie.alert({
			type: 3,
			text: '¡La imagen debe estar en formato JPG o PNG!',
			time: 7
		})
	} else if (imagen["size"] > 2000000) {
		$("input[type='file']").val("");
		notie.alert({
			type: 3,
			text: '¡La imagen no debe pesar más de 2MB!',
			time: 7
		})
	} else {
		var datosImagen = new FileReader;
		datosImagen.readAsDataURL(imagen);

		$(datosImagen).on("load", function (event) {
			var rutaImagen = event.target.result;
			$(".previewImg_" + tipo).attr("src", rutaImagen);
		})
	}
})

/*=============================================
SUMMERNOTE
=============================================*/

$(".summernote-sm").summernote({
	height: 300,
	callbacks: {
		onImageUpload: function (files) {
			for (var i = 0; i < files.length; i++) {
				upload_sm(files[i]);
			}
		}
	}
});

$(".summernote-smc").summernote({
	height: 300,
	callbacks: {
		onImageUpload: function (files) {
			for (var i = 0; i < files.length; i++) {
				upload_smc(files[i]);
			}
		}
	}
});

/*=============================================
SUBIR IMAGEN AL SERVIDOR
=============================================*/

function upload_sm(file) {
	var datos = new FormData();
	datos.append('FileName', file.name);
	datos.append('ProfileImage', file);
	datos.append("PathFile", 'Contents/img/application/');
	datos.append("FolderFile", "application");

	debugger;
	$.ajax({
		url: "/Application/UploadFile",
		method: "POST",
		data: datos,
		contentType: false,
		cache: false,
		processData: false,
		success: function (respuesta) {
			$('.summernote-sm').summernote("insertImage", respuesta, function ($image) {
				$image.attr('class', 'img-fluid');
			});
		},
		error: function (jqXHR, textStatus, errorThrown) {
			console.error(textStatus + " " + errorThrown);
		}
	})
}

function upload_smc(file) {
	var datos = new FormData();
	datos.append('FileName', file.name);
	datos.append('ProfileImage', file);
	datos.append("PathFile", 'Contents/img/application/');
	datos.append("FolderFile", "application");

	debugger;
	$.ajax({
		url: "/Application/UploadFile",
		method: "POST",
		data: datos,
		contentType: false,
		cache: false,
		processData: false,
		success: function (respuesta) {
			$('.summernote-smc').summernote("insertImage", respuesta, function ($image) {
				$image.attr('class', 'img-fluid');
			});
		},
		error: function (jqXHR, textStatus, errorThrown) {
			console.error(textStatus + " " + errorThrown);
		}
	})
}

function upload_local_img(file) {
	var datos = new FormData();
	datos.append('FileName', file.name);
	datos.append('ProfileImage', file);
	datos.append("PathFile", 'Contents/img/application/');
	datos.append("FolderFile", "application");

	debugger;
	$.ajax({
		url: "/Application/UploadFile",
		method: "POST",
		data: datos,
		contentType: false,
		cache: false,
		processData: false,
		success: function (respuesta) {
			console.log(respuesta);
		},
		error: function (jqXHR, textStatus, errorThrown) {
			console.error(textStatus + " " + errorThrown);
		}
	})
}

$("#logo").on("change", function (e) {

	var file = $(this)[0].files[0];
	var datos = new FormData();
	datos.append('FileName', file.name);
	datos.append('ProfileImage', file);
	datos.append("PathFile", 'Contents/img/application/logos/');
	datos.append("FolderFile", "logos");

	debugger;
	$.ajax({
		url: "/Application/UploadFile",
		method: "POST",
		data: datos,
		contentType: false,
		cache: false,
		processData: false,
		success: function (respuesta) {
			console.log(respuesta);
			$("#logo_actual").val(respuesta);
		},
		error: function (jqXHR, textStatus, errorThrown) {
			console.error(textStatus + " " + errorThrown);
		}
	})
});

$("#icono").on("change", function (e) {
	var file = $(this)[0].files[0];

	var datos = new FormData();
	datos.append('FileName', file.name);
	datos.append('ProfileImage', file);
	datos.append("PathFile", 'Contents/img/application/logos/');
	datos.append("FolderFile", "logos");

	debugger;
	$.ajax({
		url: "/Application/UploadFile",
		method: "POST",
		data: datos,
		contentType: false,
		cache: false,
		processData: false,
		success: function (respuesta) {
			console.log(respuesta);
			$("#icono_actual").val(respuesta);
		},
		error: function (jqXHR, textStatus, errorThrown) {
			console.error(textStatus + " " + errorThrown);
		}
	})
});