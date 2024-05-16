////////////////////////////////////////////////  INICIO MENU (BUTTONS)  ///////////////////////////////////////////////////////////////////
$('.btn-title-item').click(function (event) {
    event.preventDefault(); // Evita el comportamiento predeterminado del botón (Razon por la cual existe este JS, y la paginas no recarguen)
    var targetId = $(this).data('target');
    if (targetId === 'ticket-inicio') {
        $('#TicketsTable').DataTable().ajax.reload();
    }
});

////////////////////////////////////////////////  INICIO TABLA       ///////////////////////////////////////////////////////////////////////

new DataTable('#TicketsTable', {
    processing: true,
    serverSide: true,
    filter: true,
    ajax: {
        type: 'POST',
        url: 'ControlTicketsSoporte.aspx/TicketsTable',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: function (dtParams) { return JSON.stringify({ ClientParameters: JSON.stringify(dtParams) }); },
        dataFilter: function (res) {
            try {
                var parsed = JSON.parse(res);
                return JSON.stringify(parsed.d);
            } catch (e) {
                console.error("Error parsing JSON response: ", e);
                return res;
            }
        },
        error: function (x, y) {
            console.log(x);
        }
    },
    columns: [
        {
            data: 'Id',
            orderable: false
        },
        { data: 'Concepto', orderable: false },
        {
            data: 'Incidencia',
            orderable: false,
            className: 'column-incidencia',
            render: function (data, type, row, meta) {
                if (type === 'display' && data.length > 50) {
                    return '<span title="' + data + '">' + data.substring(0, 50) + '...</span>';
                }
                return data;
            }
        },
        { data: 'Generado', orderable: false },
        { data: 'Inicio', orderable: false },
        { data: 'Fin', orderable: false },
        { data: 'Calificado', orderable: false },
        { data: 'AtencionTicket', orderable: false },
        { data: 'Calificacion', orderable: false },
        {
            title: '',
            data: null,
            orderable: false,
            searchable: false,
            render: function (data, type, row, meta) {
                return '<button class="btn-descargar btn-table btn-table-general" data-id="' + row.Id + '" title="DESCARGAR EVIDENCIA"><i class="fa-solid fa-file-arrow-down table-icon"></i></button>';

            }
        },
        {
            title: '',
            data: null,
            orderable: false,
            searchable: false,
            render: function (data, type, row, meta) {
                return '<button class="btn-informacion btn-table btn-table-general" data-id="' + row.Id + '" title="HISTORIAL"><i class="fa-solid fa-regular fa-circle-info table-icon"></i></button>';
            }
        },
        {
            title: '',
            data: null,
            orderable: false,
            searchable: false,
            render: function (data, type, row, meta) {
                return '<button class="btn-eliminar btn-table btn-table-general" data-id="' + row.Id + '" title="ELIMINAR"><i class="fa-solid fa-trash-can table-icon"></i></button>'
            }
        },
        {
            title: '',
            data: null,
            orderable: false,
            searchable: false,
            render: function (data, type, row, meta) {
                return '<button class="btn-success btn-table btn-table-success" data-id="' + row.Id + '" title="CALIFICAR ATENCIÓN"><i class="fa-solid fa-circle-check table-icon"></i></button>';
            }
        },
    ],
    language: {
        processing: "Procesando...",
        search: "Buscar:",
        lengthMenu: "Mostrar _MENU_ registros",
        info: "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
        infoEmpty: "Mostrando registros del 0 al 0 de un total de 0 registros",
        infoFiltered: "(filtrado de un total de _MAX_ registros)",
        infoPostFix: "",
        loadingRecords: "Cargando...",
        zeroRecords: "No se encontraron resultados",
        emptyTable: "No se ha generado ninguna solicitud.",
        paginate: {
            first: '<i class="fa-solid fa-angles-left"></i>',
            previous: '<i class="fa-solid fa-angle-left"></i>',
            next: '<i class="fa-solid fa-chevron-right"></i>',
            last: '<i class="fa-solid fa-angles-right"></i>'
        },
    },
    lengthMenu: [4, 5, 10, 20],
    layout: {
        bottomEnd: {
            paging: {
                boundaryNumbers: false
            }
        }
    },
    createdRow: function (row, data, dataIndex) {
        var status = data.Status;
        var hasFile = data.HasFile;

        var $btnDescargar = $('.btn-descargar', row);
        var $btnDetalles = $('.btn-informacion', row);
        var $btnEliminar = $('.btn-eliminar', row);
        var $btnCalificar = $('.btn-success', row);

        switch (status) {
            case '1':
                if (hasFile) {
                    $btnDescargar.show();
                } else {
                    $btnDescargar.hide();
                }
                $btnDetalles.show();
                $btnEliminar.show();
                $btnCalificar.hide();
                break;
            case '2':
                if (hasFile) {
                    $btnDescargar.show();
                } else {
                    $btnDescargar.hide();
                }
                $btnDetalles.show();
                $btnEliminar.hide();
                $btnCalificar.hide();
                break;
            case '3':
                if (hasFile) {
                    $btnDescargar.show();
                } else {
                    $btnDescargar.hide();
                }
                $btnDetalles.show();
                $btnEliminar.hide();
                $btnCalificar.show();
                break;
            case '4':
                if (hasFile) {
                    $btnDescargar.show();
                } else {
                    $btnDescargar.hide();
                }
                $btnDetalles.show();
                $btnEliminar.hide();
                $btnCalificar.hide();
                break;
            default:
                $btnDescargar.hide();
                $btnDetalles.hide();
                $btnEliminar.hide();
                $btnCalificar.hide();
        }
    }
});

////////////////////////////////////////////////     FIN TABLA   ///////////////////////////////////////////////////////////////////////////

////////////////////////////////////////////////  INICIO ALERTAS ///////////////////////////////////////////////////////////////////////////
/*  ALERTAS GENERALES */
function alert_general(text, subtitle, type) { // se puede llamar desde cualquier clase 
    Swal.fire({
        title: text,
        text: subtitle,
        icon: type
    });
}
function alert_time(text, type) {
    Swal.fire({
        title: text,
        icon: type,
        showConfirmButton: false,
        timer: 1200
    });
}
/* FIN ALERTA GENERAL */


/* AGREGAR TICKET*/
$('#btnAgregarNuevoTicket').click(function (event) {
    event.preventDefault();
    var boton = $(this);
    Swal.showLoading();
    boton.prop('disabled', true);

    var plantelId = $('[id$="ddlPlantel"]').val();
    var conceptoId = $('[id$="ddlConcepto"]').val();
    var detalle = $('[id$="txtDetalle"]').val();
    var fileInput = $('[id$="fileUpEvidencia"]')[0];

    enviarFormulario(plantelId, conceptoId, detalle, fileInput);
    function enviarFormulario(plantelId, conceptoId, detalle, fileInput) {
        if (fileInput.files.length > 0) {
            var file = fileInput.files[0];
            var fileName = file.name;
            var reader = new FileReader();
            reader.onload = function (e) {
                var fileBytes = e.target.result.split(',')[1];
                $.ajax({
                    type: 'POST',
                    url: 'ControlTicketsSoporte.aspx/Btn_Agregar',
                    data: JSON.stringify({ plantelId: plantelId, conceptoId: conceptoId, detalle: detalle, fileBytes: fileBytes, fileName: fileName }),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (response) {
                        if (response.d.Success) {
                            alert_general("Ticket Generado", response.d.Message, "success");
                            $('#TicketsTable').DataTable().ajax.reload();
                            $('[id$="txtDetalle"]').val('');
                            $('[id$="fileUpEvidencia"]').val('');
                            $('#nombre_file').text('');
                        } else {
                            alert_general("Error", response.d.Message, "warning");
                        }
                        boton.prop('disabled', false);
                    },
                    error: function (xhr, status, error) {
                        alert_general("Error", "Error al generar el ticket", "error");
                        console.log('Error al generar el ticket: ' + error);
                        console.log('Respuesta del servidor: ' + xhr.responseText);
                        boton.prop('disabled', false);
                    }
                });
            };
            reader.readAsDataURL(file);
        } else {
            $.ajax({
                type: 'POST',
                url: 'ControlTicketsSoporte.aspx/Btn_Agregar',
                data: JSON.stringify({ plantelId: plantelId, conceptoId: conceptoId, detalle: detalle, fileBytes: null, fileName: '' }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    if (response.d.Success) {
                        Swal.hideLoading();
                        alert_general("Nueva Solicitud", response.d.Message, "success");
                        $('#TicketsTable').DataTable().ajax.reload();
                        $('[id$="txtDetalle"]').val('');
                        $('[id$="fileUpEvidencia"]').val('');
                        $('#nombre_file').text('');
                    } else {
                        Swal.hideLoading();
                        alert_general("Error", response.d.Message, "warning");
                    }
                    boton.prop('disabled', false);
                },
                error: function (xhr, status, error) {
                    Swal.hideLoading();
                    alert_general("Error", "Error al generar el ticket", "error");
                    console.log('Error al generar el ticket: ' + error);
                    console.log('Respuesta del servidor: ' + xhr.responseText);
                    boton.prop('disabled', false);
                }
            });
        }
    }
});
/*  FIN AGREGAR TICKET */


////////  BOTONES DE TABLA  ////////

/* DESCARGAR */
$('#TicketsTable').on('click', 'button.btn-descargar', async function (event) {
    event.preventDefault();
    var id_ticket = $(this).data('id');

    $.ajax({
        type: 'POST',
        url: 'ControlTicketsSoporte.aspx/Btn_DataTable_Descargar',
        data: JSON.stringify({ id_ticket: id_ticket }),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (response) {
            if (response.d.Success) {
                var fileBase64 = response.d.Message;
                var fileName = response.d.FileName;
                var contentType = response.d.ContentType;
                var binary = atob(fileBase64);
                var bytes = new Uint8Array(binary.length);
                for (var i = 0; i < binary.length; i++) {
                    bytes[i] = binary.charCodeAt(i);
                }
                var blob = new Blob([bytes.buffer], { type: contentType });
                var downloadLink = document.createElement('a');
                downloadLink.href = window.URL.createObjectURL(blob);
                downloadLink.download = fileName;
                document.body.appendChild(downloadLink);
                downloadLink.click();
                document.body.removeChild(downloadLink);
            } else {
                alert_time(response.d.Message, "warning");
            }
        },
        error: function (xhr, status, error) {
            alert_general("Error", "Error inesperado con el Modal", "error");
        }
    });
});

/* INFORMACION */
$('#TicketsTable').on('click', 'button.btn-informacion', async function (event) {
    event.preventDefault();
    var id_ticket = $(this).data('id');
    Swal.showLoading();

    $.ajax({
        type: 'POST',
        url: 'ControlTicketsSoporte.aspx/Btn_DataTable_Informacion',
        data: JSON.stringify({ id_ticket: id_ticket }),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (response) {
            Swal.hideLoading();
            const datos = response.d;

            if (datos) {
                // Inyectar los datos en el modal
                $('#id_ticket').text(id_ticket);
                $('#asistente').text(datos.Asistente);
                $('#soporte').text(datos.Soporte);
                $('#concepto').text(datos.Concepto);
                $('#incidencia').text(datos.Incidencia);

                // Limpiar la tabla de detalles
                $('#tabla-detalle').empty();

                // Construir las filas de la tabla de detalles
                let filaIniciado = '<tr><th scope="row">1</th><td>' + datos.FechaIniciado + '</td><td>' + datos.Usuario + '</td><td></td><td>Iniciado</td></tr>';
                let filaEnProceso = '<tr><th scope="row">2</th><td>' + datos.FechaProceso + '</td><td>' + datos.UsuarioAtiende + '</td><td></td><td>En Proceso</td></tr>';
                let filaAtendido = '<tr><th scope="row">3</th><td>' + datos.FechaAtendido + '</td><td>' + datos.UsuarioAtiende + '</td><td>' + datos.Observaciones + '</td><td>Atendido</td></tr>';
                let filaCerrado = '<tr><th scope="row">4</th><td>' + datos.FechaCerrado + '</td><td>' + datos.Usuario + '</td><td>' + datos.ObsCerrado + '</td><td>Cerrado</td></tr>';

                $('#tabla-detalle').append(filaIniciado, filaEnProceso, filaAtendido, filaCerrado);

                $('#calificacion').text(datos.Calificacion);
                $('#tiempo_respuesta').text(datos.TiempoRespuesta);

                Swal.fire({
                    title: $('#modal-titulo').html(),
                    html: $('#modal-contenido').html(),
                    showCloseButton: true,
                    showCancelButton: false,
                    showConfirmButton: false,
                });
            } else {
                alert_general("Error", "No se encontraron datos para el ticket seleccionado", "error");
            }
        },
        error: function (xhr, status, error) {
            Swal.hideLoading();
            console.log('Error al obtener datos del modal:', error);
            console.log('Estado:', status);
            console.log('Respuesta del servidor:', xhr.responseText);
            alert_general("Error", "Error inesperado con el Modal", "error");
        }
    });
});

/* ELIMINAR */
$('#TicketsTable').on('click', 'button.btn-eliminar', async function (event) {
    event.preventDefault();
    var id_ticket = $(this).data('id');
    var confirmado = await alert_DeleteTicket(id_ticket); // Aqui se manda a llamar la alerta de este boton (alert_DeleteTicket)

    if (confirmado) {
        $.ajax({
            type: 'POST',
            url: 'ControlTicketsSoporte.aspx/Btn_DataTable_Eliminar',
            data: JSON.stringify({ id_ticket: id_ticket }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                if (response.d.Success) {
                    alert_time(response.d.Message, "success");
                } else {
                    alert_general("Error",response.d.Message, "error");
                }
                $('#TicketsTable').DataTable().ajax.reload();
            },
            error: function (xhr, status, error) {
                alert_general("ERROR", "No se permite eliminar este Ticket.", "error");
            }
        });
    }
    function alert_DeleteTicket(id_ticket) {
        return new Promise((resolve) => {
            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: "btn btn-success",
                    cancelButton: "btn btn-danger"
                },
                buttonsStyling: false
            });
            swalWithBootstrapButtons.fire({
                title: '\u00BFDeseas eliminar esta solicitud?',
                text: "Esta acci\u00F3n no se puede revertir",
                icon: "warning",
                showCancelButton: true,
                confirmButtonText: "S\u00ED, eliminar",
                cancelButtonText: "Cancelar",
                reverseButtons: true
            }).then((result) => {
                if (result.isConfirmed) {
                    alert_time("Ticket Eliminado", "success");
                    resolve(true);
                }
                else if (result.dismiss === Swal.DismissReason.cancel) {
                    alert_time("Cancelado", "info");
                    resolve(false);
                }
            });
        });
    }
});

/* SUCCESS */
$('#TicketsTable').on('click', 'button.btn-success', async function (event) {
    event.preventDefault();
    var id_ticket = $(this).data('id');
    Swal.fire({
        title: `Problema resuelto <i class="fa-regular fa-face-laugh-wink"></i>`,
        input: "select",
        inputOptions: {
            Opciones: {
                1: `Excelente`,
                2: `Muy Buena`,
                3: `Buena`,
                4: `Regular`,
                5: `Mala`,
            }
        },
        inputPlaceholder: "Por favor, califica la atención recibida.",
        //icon: "success",
        inputAttributes: {
            autocapitalize: "off"
        },
        confirmButtonText: "Enviar",
        showCancelButton: true,
        showLoaderOnConfirm: true,
        preConfirm: async (calificacion) => {
            if (!calificacion) {
                Swal.showValidationMessage(`Selecciona una opción.`);
                return;
            }
            try {
                await $.ajax({
                    type: 'POST',
                    url: 'ControlTicketsSoporte.aspx/Btn_DataTable_Calificacion_Success',
                    data: JSON.stringify({ id_ticket: id_ticket, calificacion: calificacion }),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function () {
                        $('#TicketsTable').DataTable().ajax.reload();
                        $('#TicketsTable2').DataTable().ajax.reload();
                    },
                    error: function (xhr, status, error) {
                        console.error(xhr.responseText);
                        Swal.showValidationMessage(`Error al enviar: ${error}`);
                    }
                });
            } catch (error) {
                Swal.showValidationMessage(`Error al enviar: ${error}`);
            }
        },
        allowOutsideClick: () => !Swal.isLoading()
    }).then((result) => {
        if (result.isConfirmed) {
            alert_time("Calificación enviada.", "success");
        }
    });
});

//////// FIN BOTONES DE TABLA  //////

////////////////////////////////////////////////  FIN ALERTAS ///////////////////////////////////////////////////////////////////////////
function mostrarNombreArchivo(input) {
    var nombreArchivo = input.value.split("\\").pop();
    document.getElementById("nombre_file").innerHTML = nombreArchivo;
}