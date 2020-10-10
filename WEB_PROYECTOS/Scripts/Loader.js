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