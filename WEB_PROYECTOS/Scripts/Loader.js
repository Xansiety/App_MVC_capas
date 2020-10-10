function LoadingOverlayShow(id) {
    $(id).LoadingOverlay("show", {
        color: "rgba(255,255,255, 0.5)",
        image: "/Content/Loaders/tenor.gif",
        imageResizeFactor: 0.6
    });
}


function LoadingOverlayHide(id) {
    $(id).LoadingOverlay("hide");
}


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

            return myCallback(result.data);
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


