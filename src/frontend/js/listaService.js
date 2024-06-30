$(document).ready(function() {
    listadoAll()
    listadoByParams()
    listadoByEmpresa()

    $('#btnRedirectActualizar').click(function() {
        $(location).attr('href', 'http://127.0.0.1:5500/actualizarAvion.html')
    })
})

function listadoAll() {
    const url = 'https://localhost:44309/aviones/GetAll'
    fetch(url)
    .then(response => response.json())
    .then(response => {
        if(!response.success){
            console.log(response.errorMessage)
        } else {
            const cuerpoTabla = document.getElementById('tablaAll');

            response.data.forEach(avion => {
                const fila = document.createElement("tr")
                fila.innerHTML += `<td>${avion.modelo}</td>`
                fila.innerHTML += `<td>${avion.idFabricanteNavigation.nombre}</td>`
                fila.innerHTML += `<td>${avion.cantidadAsientos}</td>`
                fila.innerHTML += `<td>${avion.cantidadMotores}</td>`

                cuerpoTabla.append(fila)
                
            });
        }
    })
    .catch(error => {
        console.log(error)
    })
}

function listadoByParams() {
    const url = 'https://localhost:44309/aviones/GetByParams'
    fetch(url)
    .then(response => response.json())
    .then(response => {
        if(!response.success){
            console.log(response.errorMessage)
        } else {
            const cuerpoTabla = document.getElementById('tablaByParams')
            
            const avion = response.data
                const fila = document.createElement("tr")
                fila.innerHTML += `<td>${avion.modelo}</td>`
                fila.innerHTML += `<td>${avion.idFabricanteNavigation.nombre}</td>`
                fila.innerHTML += `<td>${avion.cantidadAsientos}</td>`
                fila.innerHTML += `<td>${avion.cantidadMotores}</td>`

                cuerpoTabla.append(fila)
                
            
        }
    })
    .catch(error => {
        console.log(error)
    })
}

function listadoByEmpresa() {
    const url = 'https://localhost:44309/aviones/GetByEmpresa'
    fetch(url)
    .then(response => response.json())
    .then(response => {
        if(!response.success){
            console.log(response.errorMessage)
        } else {
            const cuerpoTabla = document.getElementById('tablaByEmpresa');

            response.data.forEach(avion => {
                const fila = document.createElement("tr")
                fila.innerHTML += `<td>${avion.modelo}</td>`
                fila.innerHTML += `<td>${avion.idFabricanteNavigation.nombre}</td>`
                fila.innerHTML += `<td>${avion.cantidadAsientos}</td>`
                fila.innerHTML += `<td>${avion.cantidadMotores}</td>`

                cuerpoTabla.append(fila)
                
            });
        }
    })
    .catch(error => {
        console.log(error)
    })
}