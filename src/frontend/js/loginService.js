$(document).ready(function() {
    $('#formLogin').validate({
        rules: {
            usuario: {
                required: true
            },
            password: {
                required: true
            },
            flexRadioDefault: {
                required: true
            }
        },
        messages: {
            usuario: {
                required: 'Ingresar Usuario'
            },
            password: {
                required: 'Ingresar Password'
            },
            flexRadioDefault: {
                required: 'Seleccionar una opcion'
            }
        },
        errorClass: "text-danger mt-2"
    })

    $('#btnIngresar').click(function() {
        if($('#formLogin').valid()){
            login()
        }
    })
})

function login(){
    const url = 'https://localhost:44309/usuarios/login'
    const nombreUsuario = $('#idNombreUsuario').val()
    const password = $('#idPassword').val()

    fetch(url, {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                nombreUsuario: nombreUsuario,
                password: password
            })
        }
    )
    .then(response => response.json())
    .then(response => {
        if(!response.success){
            console.log(response.errorMessage)
        }
        else {
            const token = response.data.token
            localStorage.setItem("token", token)
            $(location).attr('href', 'http://127.0.0.1:5500/index.html')
        }
    })
    .catch(err => {
        console.log(err)
    })
}