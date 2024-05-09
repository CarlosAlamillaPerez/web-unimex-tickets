////////////////////////////////////////////////  INICIO MENU (BUTTONS)  //////////////////////////////////////////////////////////////////////////
$('.btn-title-item').click(function (event) {
    event.preventDefault(); // Evita el comportamiento predeterminado del botón (Razon por la cual existe este JS, y la paginas no recarguen)
    var targetId = $(this).data('target');
    if (targetId === 'ticket-inicio') {
        $('#ticket-history').show();
        $('#ticket-calificacion').hide();
    } else if (targetId === 'ticket-fin') {
        $('#ticket-history').hide();
        $('#ticket-calificacion').show();
    }
});

////////////////////////////////////////////////  INICIO TABLA       //////////////////////////////////////////////////////////////////////////
function mostrarNombreArchivo(input) {
    var nombreArchivo = input.value.split("\\").pop();
    document.getElementById("nombre_file").innerHTML = nombreArchivo;
}

new DataTable('#TicketsTable', {
    processing: true,
    serverSide: true,
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
    filter: true,
    columns: [
        {
            data: 'Id',
        },
        //{ data: 'Usuario' },
        { data: 'Concepto' },
        {
            data: 'Incidencia',
            className: 'column-incidencia',
            render: function (data, type, row, meta) {
                if (type === 'display' && data.length > 50) {
                    return '<span title="' + data + '">' + data.substring(0, 50) + '...</span>';
                }
                return data;
            }
        },
        { data: 'Generado' },
        { data: 'Inicio' },
        { data: 'Fin' },
        { data: 'Calificado' },
        { data: 'AtencionTicket' },
        { data: 'Calificacion' },
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
                return '<button class="btn-informacion btn-table btn-table-general" data-id="' + row.Id + '" title="HISTORIAL" onclick="mostrarDetallesTicket(this)"><i class="fa-solid fa-regular fa-circle-info table-icon"></i></button>';
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
        }
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
        emptyTable: "No se ha generado ningún ticket.",
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
    }
});
new DataTable('#TicketsTable2', {
    processing: true,
    serverSide: true,
    ajax: {
        type: 'POST',
        url: 'ControlTicketsSoporte.aspx/TicketsTable2',
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
    filter: true,
    columns: [
        {
            data: 'Id',
        },
        //{ data: 'Usuario' },
        { data: 'Concepto' },
        {
            data: 'Incidencia',
            className: 'column-incidencia',
            render: function (data, type, row, meta) {
                if (type === 'display' && data.length > 50) {
                    return '<span title="' + data + '">' + data.substring(0, 50) + '...</span>';
                }
                return data;
            }
        },
        { data: 'Generado' },
        { data: 'Inicio' },
        { data: 'Fin' },
        { data: 'Status' },
        { data: 'AtencionTicket' },
        //{ data: 'Calificacion' },
        {
            title: 'NO RESUELTO',
            data: null,
            orderable: false,
            searchable: false,
            render: function (data, type, row, meta) {
                return '<button class="btn-error btn-table btn-table-error" data-id="' + row.Id + '" title="MANDAR A CORREGIR"><i class="fa-solid fa-circle-xmark table-icon"></i></button>';

            }
        },
        {
            title: 'RESUELTO',
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
        emptyTable: "No hay tickets resueltos",
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


/* INICIO BOTON DE AGREGAR TICKET*/
$('#btnAgregarNuevoTicket').click(function (event) {
    event.preventDefault();
    var boton = $(this);
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
        }
    }
});
/*  FIN   BOTON DE AGREGAR TICKET */


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
/* DETALLES */
$('#TicketsTable').on('click', 'button.btn-informacion', async function (event) {
    event.preventDefault();
    var id_ticket = $(this).data('id');

    $.ajax({
        type: 'POST',
        url: 'ControlTicketsSoporte.aspx/Btn_DataTable_Informacion',
        data: JSON.stringify({ id_ticket: id_ticket }),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (response) {
            alert_time("Archivo", "success");
        },
        error: function (xhr, status, error) {
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
                    alert_time(response.d.Message, "success");
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
                title: '\u00BFDeseas eliminar este ticket?',
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
/* ERROR */
$('#TicketsTable2').on('click', 'button.btn-error', async function (event) {
    event.preventDefault();
    var id_ticket = $(this).data('id');

    Swal.fire({
        title: "¿No se encontró solución?",
        input: "textarea",
        inputPlaceholder: "Detalla el problema que presentas...",
        icon: "question",
        inputAttributes: {
            autocapitalize: "off"
        },
        showCancelButton: true,
        confirmButtonText: "Enviar",
        showLoaderOnConfirm: true,
        preConfirm: async (mensaje) => {
            if (mensaje == "") {
                Swal.showValidationMessage(`Describe tu problema &nbsp; <i class="fa-regular fa-face-sad-cry"></i>`);
                return;
            }
            try {
                await $.ajax({
                    type: 'POST',
                    url: 'ControlTicketsSoporte.aspx/Btn_DataTable_Calificacion_Error',
                    data: JSON.stringify({ id_ticket: id_ticket, mensaje: mensaje }),
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
            alert_time("Mensaje enviado", "success");
        }
    });
});
/* SUCCESS */
$('#TicketsTable2').on('click', 'button.btn-success', async function (event) {
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





















//$("#ContentPlaceHolder1_fileUpEvidencia").change(function () {
//    var path = this.value
//    path = path.substring(12);
//    $("#mensaje").text(path)
//});



//const width_threshold = 480;

//function drawLineChart() {
//    if ($("#lineChart").length) {
//        ctxLine = document.getElementById("lineChart").getContext("2d");
//        optionsLine = {
//            scales: {
//                yAxes: [
//                    {
//                        scaleLabel: {
//                            display: true,
//                            labelString: "Hits"
//                        }
//                    }
//                ]
//            }
//        };

//        // Set aspect ratio based on window width
//        optionsLine.maintainAspectRatio =
//            $(window).width() < width_threshold ? false : true;

//        configLine = {
//            type: "line",
//            data: {
//                labels: [
//                    "January",
//                    "February",
//                    "March",
//                    "April",
//                    "May",
//                    "June",
//                    "July"
//                ],
//                datasets: [
//                    {
//                        label: "Latest Hits",
//                        data: [88, 68, 79, 57, 50, 55, 70],
//                        fill: false,
//                        borderColor: "rgb(75, 192, 192)",
//                        cubicInterpolationMode: "monotone",
//                        pointRadius: 0
//                    },
//                    {
//                        label: "Popular Hits",
//                        data: [33, 45, 37, 21, 55, 74, 69],
//                        fill: false,
//                        borderColor: "rgba(255,99,132,1)",
//                        cubicInterpolationMode: "monotone",
//                        pointRadius: 0
//                    },
//                    {
//                        label: "Featured",
//                        data: [44, 19, 38, 46, 85, 66, 79],
//                        fill: false,
//                        borderColor: "rgba(153, 102, 255, 1)",
//                        cubicInterpolationMode: "monotone",
//                        pointRadius: 0
//                    }
//                ]
//            },
//            options: optionsLine
//        };

//        lineChart = new Chart(ctxLine, configLine);
//    }
//}

//function drawBarChart() {
//    if ($("#barChart").length) {
//        ctxBar = document.getElementById("barChart").getContext("2d");

//        optionsBar = {
//            responsive: true,
//            scales: {
//                yAxes: [
//                    {
//                        barPercentage: 0.2,
//                        ticks: {
//                            beginAtZero: true
//                        },
//                        scaleLabel: {
//                            display: true,
//                            labelString: "Hits"
//                        }
//                    }
//                ]
//            }
//        };

//        optionsBar.maintainAspectRatio =
//            $(window).width() < width_threshold ? false : true;

//        /**
//         * COLOR CODES
//         * Red: #F7604D
//         * Aqua: #4ED6B8
//         * Green: #A8D582
//         * Yellow: #D7D768
//         * Purple: #9D66CC
//         * Orange: #DB9C3F
//         * Blue: #3889FC
//         */

//        configBar = {
//            type: "horizontalBar",
//            data: {
//                labels: ["Red", "Aqua", "Green", "Yellow", "Purple", "Orange", "Blue"],
//                datasets: [
//                    {
//                        label: "# of Hits",
//                        data: [33, 40, 28, 49, 58, 38, 44],
//                        backgroundColor: [
//                            "#F7604D",
//                            "#4ED6B8",
//                            "#A8D582",
//                            "#D7D768",
//                            "#9D66CC",
//                            "#DB9C3F",
//                            "#3889FC"
//                        ],
//                        borderWidth: 0
//                    }
//                ]
//            },
//            options: optionsBar
//        };

//        barChart = new Chart(ctxBar, configBar);
//    }
//}

//function drawPieChart() {
//    if ($("#pieChart").length) {
//        var chartHeight = 300;

//        $("#pieChartContainer").css("height", chartHeight + "px");

//        ctxPie = document.getElementById("pieChart").getContext("2d");

//        optionsPie = {
//            responsive: true,
//            maintainAspectRatio: false,
//            layout: {
//                padding: {
//                    left: 10,
//                    right: 10,
//                    top: 10,
//                    bottom: 10
//                }
//            },
//            legend: {
//                position: "top"
//            }
//        };

//        configPie = {
//            type: "pie",
//            data: {
//                datasets: [
//                    {
//                        data: [18.24, 6.5, 9.15],
//                        backgroundColor: ["#F7604D", "#4ED6B8", "#A8D582"],
//                        label: "Storage"
//                    }
//                ],
//                labels: [
//                    "Used Storage (18.240GB)",
//                    "System Storage (6.500GB)",
//                    "Available Storage (9.150GB)"
//                ]
//            },
//            options: optionsPie
//        };

//        pieChart = new Chart(ctxPie, configPie);
//    }
//}

//function updateLineChart() {
//    if (lineChart) {
//        lineChart.options = optionsLine;
//        lineChart.update();
//    }
//}

//function updateBarChart() {
//    if (barChart) {
//        barChart.options = optionsBar;
//        barChart.update();
//    }
//}
