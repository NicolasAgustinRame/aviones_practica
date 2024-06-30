$(document).ready(function() {
    $('#formActualizar').validate({
        rules: {
            id: {
                required: true
            },
            modelo: {
                required: true
            },
            cantAsientos: {
                required: true
            },
            cantMotores: {
                required: true
            },
            datosvarios: {
                required: true
            },

        },
        messages: {
            id: {
                required: 'Ingresar Usuario'
            },
            modelo: {
                required: 'Ingresar Password'
            },
            cantAsientos: {
                required: 'Ingrese una cantidad de asientos'
            },
            cantMotores: {
                required: 'Ingrese una cantidad de motores'
            },
            datosvarios: {
                required: 'Ingresar datos'
            }
        },
        errorClass: "text-danger mt-2"
    });

    $('#btnActualizar').click(function() {
        if($('#formActualizar').valid()){
            actualizarAviones()
        }
    })
})

function actualizarAviones() {
    const url = 'https://localhost:44309/aviones/PutAvion'
    const id = $('#id').val()
    const modelo = $('#idModelo').val()
    const cantAsientos = $('#idCantidadAsientos').val()
    const cantMotores = $('#idMotores').val()
    const datosVarios = $('#idDatosVarios').val()

    fetch(url, {
        method: 'PUT',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            id: id,
            modelo: modelo,
            cantidadAsientos:cantAsientos,
            motores: cantMotores,
            datosVarios: datosVarios
        })
    })
    .then(response => response.json())
    .then(response => {
        if(!response.success){
            Swal.fire({
                icon: "error",
                title: `${response.errorMessage}`,
                showConfirmButton: false,
                timer: 2500
            });
            $('#id').val('')
            $('#idModelo').val('')
            $('#idCantidadAsientos').val('')
            $('#idMotores').val('')
            $('#idDatosVarios').val('')
        } else {
            const avion = response.data

            Swal.fire({
                icon: "success",
                title: `${avion.modelo} actualizado`,
                showConfirmButton: false,
                timer: 2500
            });

            $('#id').val('')
            $('#idModelo').val('')
            $('#idCantidadAsientos').val('')
            $('#idMotores').val('')
            $('#idDatosVarios').val('')
        }
    })
    .catch(error => {
        console.log(error)
    })
}