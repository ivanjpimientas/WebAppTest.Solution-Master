var webapptest = webapptest || {};
webapptest.namespace('webapptest.addresses_manager');
webapptest.addresses_manager = (function (APP, $) {
    var that = this
    //private variables
    indexPageUrl = "Index"
        , addressCreateUrl = "/Address/Create"
        , addressEditUrl = "/Address/Edit"
        , addressDeleteUrl = "/Address/Delete"
        , addressDetailsUrl = "/Address/Details";

    //Public API
    return {
        displayAddEditAddress: function (itemId) {
            debugger;
            var url = "/Address/AddEditAddress?itemId=" + itemId;
            if (itemId > 0)
                $('#title').html("Edit Address");
            $("#addressFormModelDiv").load(url, function () {
                $("#addressFormModel").modal("show");
            });
            $('#addressFormModel').on('shown.bs.modal', function () {
            });
        },
        saveAddressForm: function () {
            var myformdata = $("#addressForm").serialize();
            $.ajax({
                type: "POST",
                url: "/Address/Create",
                data: myformdata,
                success: function () {
                    swal({
                        type: "success",
                        title: "Save Register Success!!!",
                        showConfirmButton: true,
                        confirmButtonText: "Close"
                    }).then(function (result) {
                        if (result.value) {
                            $("#myModal").modal("hide");
                            window.location.href = "/Address/Index";
                        }
                    });
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            })
        },
        displayDeleteAddress: function (itemId) {
            swal({
                title: "Do you want to delete item with Item Id: " + itemId,
                text: "¡Si no lo está puede cancelar la accíón!",
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                cancelButtonText: 'Cancel',
                confirmButtonText: 'Yes, delete Register!'
            }).then(function (result) {
                if (result.value) {
                    $.ajax({
                        type: "POST",
                        url: "/Address/Delete/" + itemId,
                        success: function () {
                            window.location.href = "/Address/Index";
                        }
                    })
                }
            })
        },
        displayListAddresses: function () {
            /*=============================================
            DataTable Addresses
            =============================================*/
            var tablaAddresses = $("#tblAddresses").DataTable({
                type: "GET",
                dataType: "json",
                "language": {
                    "sProcessing": "Procesando...",
                    "sLengthMenu": "Mostrar _MENU_ registros",
                    "sZeroRecords": "No se encontraron resultados",
                    "sEmptyTable": "Ningún dato disponible en esta tabla",
                    "sInfo": "Mostrando registros del _START_ al _END_",
                    "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0",
                    "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                    "sInfoPostFix": "",
                    "sSearch": "Buscar:",
                    "sUrl": "",
                    "sInfoThousands": ",",
                    "sLoadingRecords": "Cargando...",
                    "oPaginate": {
                        "sFirst": "Primero",
                        "sLast": "Último",
                        "sNext": "Siguiente",
                        "sPrevious": "Anterior"
                    },
                    "oAria": {
                        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                    }
                }
            });
        }
    }
}(webapptest, jQuery));