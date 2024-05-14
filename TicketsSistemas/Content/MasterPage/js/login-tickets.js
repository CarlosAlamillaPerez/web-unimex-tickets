$('#enviar').click(function (event) {
    event.preventDefault();
    var boton = $(this);
    boton.prop('disabled', true);

    var _user = $('#user').val();
    var _pass = $('#pass').val();

    enviarFormulario();
    function enviarFormulario() {
        $.ajax({
            type: 'POST',
            url: 'Login.aspx/Btn_Enviar_Login',
            data: JSON.stringify({ user: _user, pass: _pass }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                if (response.d.Success) {
                    alert_mini(response.d.Message, "success");
                    setTimeout(function () {
                        window.location.href = response.d.RedirectUrl;
                    }, 1200);
                } else {
                    alert_mini(response.d.Message, "error");
                }
                boton.prop('disabled', false);
            },
            error: function (xhr, status, error) {
                alert_mini("Error al iniciar sesion", "error");
                console.log('Respuesta del servidor: ' + xhr.responseText);
                boton.prop('disabled', false);
            }
        });
    }
});
function alert_mini(text, type) {
    const Toast = Swal.mixin({
        toast: true,
        position: "top-end",
        showConfirmButton: false,
        timer: 1350,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.onmouseenter = Swal.stopTimer;
            toast.onmouseleave = Swal.resumeTimer;
        }
    });
    Toast.fire({
        icon: type,
        title: text
    });
}