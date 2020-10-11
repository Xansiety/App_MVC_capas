
/**
 * 
 * Uso del plugin de loader JS que muestra los loader en forma animada bloqueando el contenido y muetrs la imagen del servidor como carga
 */
function LoadingOverlayShow(id) {
    $(id).LoadingOverlay("show", {
        color: "rgba(255,255,255, 0.5)",
        image: "/Content/Loaders/tenor.gif",
        imageResizeFactor: 0.6
    });
}

/**
 *
 * Uso del plugin de loader JS que muestra los loader en forma animada bloqueando el contenido y muetrs la imagen del servidor como carga
 */
function LoadingOverlayHide(id) {
    $(id).LoadingOverlay("hide");
}


/**
 * 
*Validar las fechas que la fecha final no sea menor a la fecha de inicio del ptryecto
 */
function dateValidate(dateIni, dateFin) {
    var _dateIni = new Date(dateIni); //para convertirlos a fecha
    var _dateFin = new Date(dateFin);

    if (_dateFin < _dateIni) {
        return false;
    } else {
        return true;
    }
}

//USO DE CALLBACK PARA PODER AHACER UNA PETICION ASYNCRONA
function getDeptos(myCallback) {
    $.ajax({
        type: "GET",
        url: '/Departamento/getDeptos',
        dataType: 'json',
        success: function (result) {
            $.each(result.data, function (key, item) {
                $("#DepartamentoId").append('<option value= ' + item.DepartamentoId + '>' + item.NombreDepartamento + '</option>');
            });

           if (myCallback != undefined) {
                return myCallback(result.data);
            } 
        },
        error: function (data) {
            console.log(data);
            alert('Errror inesperado');
        }
    });
}


//function getDeptos() {
//    $.ajax({
//        type: "GET",
//        url: '/Departamento/getDeptos',
//        dataType: 'json',
//        success: function (result) {
//            $.each(result.data, function (key, item) {
//                $("#DepartamentoId").append('<option value= ' + item.DepartamentoId + '>' + item.NombreDepartamento + '</option>');
//            });
//        },
//        error: function (data) {
//            console.log(data);
//            alert('Errror inesperado');
//        }
//    });
//}


/**
 * 
 * Funciones para enlistar los datos en la asignacion del proyecto
 */
function ListarProyectos(myCallback) {
    $.ajax({
        type: "GET",
        url: '/Proyecto/Listarproyectos', //Controlador/Metodo 
        dataType: 'json',
        success: function (result) {
            $.each(result.data, function (key, item) {
                $("#ProyectoId").append('<option value= ' + item.ProyectoId + '>' + item.NombreProyecto + '</option>');
            });
            //para evitar errores en l llamada de los callback que no se necesitan
            if (myCallback != undefined) {
                return myCallback(result.data);
            } 
            
        },
        error: function (data) {
            console.log(data);
            alert('Errror inesperado');
        }
    });
}



function ListarEmpleados(myCallback) {
    $.ajax({
        type: "GET",
        url: '/Empleado/ListarEmpleados', //Controlador/Metodo 
        dataType: 'json',
        success: function (result) {
            $.each(result.data, function (key, item) {
                $("#EmpleadoId").append('<option value= ' + item.EmpleadoId + '>' + item.Apellidos + ' ' + item.Nombres + '</option>');
            });
            //para evitar errores en l llamada de los callback que no se necesitan
            if (myCallback != undefined) {
                return myCallback(result.data);
            }

        },
        error: function (data) {
            console.log(data);
            alert('Errror inesperado');
        }
    });
}


