$(document).ready(function() {
    if(window.location.href.indexOf('novaReserva') != -1) {
        toastr.success('Esta pessoa acabou de ser cadastrada. Verifique as informações faltantes.', 'Sucesso!');
    }
})