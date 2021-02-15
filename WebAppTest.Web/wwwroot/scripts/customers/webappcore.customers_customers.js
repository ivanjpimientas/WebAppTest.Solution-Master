var webappcore = webappcore || {};
webappcore.namespace('webappcore.customers_customers');
webappcore.customers_customers = (function (APP, $) {
    var that = this
    //private variables
    indexPageUrl = "Index"
        , customerCreateUrl = "/CustomerManager/Customers/Create"
        , customerEditUrl = "/CustomerManager/Customers/Edit"
        , customerDeleteUrl = "/CustomerManager/Customers/Delete"
        , customerDetailsUrl = "/CustomerManager/Customers/Details";

    //Public API
    return {
        displayAddEditCustomers: function (itemId) {
            debugger;
            var url = "/CustomerManager/Customers/AddEditCustomers?itemId=" + itemId;
            if (itemId > 0)
                $('#title').html("Editar Cliente");
            $("#customerFormModelDiv").load(url, function () {
                $("#customerFormModel").modal("show");
            });
            $('#customerFormModel').on('shown.bs.modal', function () {
            });
        },
        saveCustomerForm: function () {
            //var myformdata = $("#customerForm").serialize();
            var newCustomer = {
                "Id": $("#Id").val(),
                "TipoDocumentoId": $("#TipoDocumentoId").val(),
                "NumeroDocumento": $("#NumeroDocumento").val(),
                "Nombres": $("#Nombres").val(),
                "Apellidos": $("#Apellidos").val(),
                "Direccion": $("#Direccion").val(),
                "Telefono": $("#Telefono").val(),
                "Email": $("#Email").val(),
                "Imagen": ""
            };

            debugger;
            $.ajax({
                type: "POST",
                url: "/CustomerManager/Customers/Create",
                data: newCustomer,
                success: function () {
                    debugger;
                    swal({
                        type: "success",
                        title: "Save Register Success!!!",
                        showConfirmButton: true,
                        confirmButtonText: "Close"
                    }).then(function (result) {
                        if (result.value) {
                            $("#myModal").modal("hide");
                            window.location.href = "/CustomerManager/Customers/Index";
                        }
                    });
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);                    
                }
            })
        },
        displayDeleteCustomer: function (itemId) {
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
                        url: "/CustomerManager/Customers/Delete/" + itemId,
                        success: function () {
                            window.location.href = "/CustomerManager/Customers/Index";
                        }
                    })
                }
            })
        },
        displayListCustomers: function () {
            /*=============================================
            DataTable de Customers
            =============================================*/
            var tablaListaCustomers = $("#tblCustomers").DataTable({
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
}(webappcore, jQuery));