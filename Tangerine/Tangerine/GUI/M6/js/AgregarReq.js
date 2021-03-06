﻿$(document).ready(function () {

});

function actualizarIdPrecondiciones() {
    escenarios = $("[id^=precondicion_]");
    for (i = 0; i < escenarios.length; i++) {
        escenario = escenarios[i];
        escenario.id = "precondicion_" + i;
        escenario.name = "precondicion_" + i;
    }
}

function agregarPrecondicion() {
    child = document.getElementById("div-precondiciones").lastElementChild.lastElementChild;
    child.innerHTML = "<button type=\"button\" class=\"btn btn-danger btn-circle glyphicon glyphicon-remove\" onclick=\"eliminarCampo(this)\"></button>";
    codigo = "<div class=\"form-group\">" +
			"    <div class=\"col-sm-12 col-md-12 col-lg-12\" style=\"margin-left:-30px;\"> " +
			"        <input type=\"text\" runat\"server\" placeholder=\"Requerimiento\" class=\"form-control precondicion\" id=\"precondicion_n\" name=\"precondicion_n\" required onblur = \"onBlurDeInputs(this.id)\"" +
            "           oninvalid=\"setCustomValidity('Campo obligatorio, no puede tener numeros ni simbolos')\" oninput=\"setCustomValidity('')\" title=\"Descripcion\" pattern=\"^[A-z ,.()0-9]+$\" />" +
			"    </div>" +
			"    <div class=\"col-sm-1 col-md-1 col-lg-1\" style=\"margin-left:-20px;\" >" +
			"        <button type=\"button\" class=\"btn btn-default btn-circle glyphicon glyphicon-plus\" onclick=\"agregarPrecondicion()\"></button>" +
			"    </div>" +
			"</div>";
    $("#div-precondiciones").append(codigo);
    actualizarIdPrecondiciones();
}

function eliminarCampo(caller) {
    var parent = caller.parentElement.parentElement;
    parent.parentElement.removeChild(parent);
}

function contarElementos() {
    var campos = $("#div-precondiciones").find(".form-control");
    var requerimientos = [];
    for (var i = 0; i < campos.length; i++) {
        requerimientos[i] = campos.eq(i).val();
    }
}

function crearPrecondicionArr() {

    var values = "";
    // escenarios = $("[id^=precondicion_]");
    $('.arrPrecondicion').val("");
    $('.precondicion').each(function () {
        //   alert($(this).val());
        values = values + $(this).val() + ";";
        //   $('#precondicion_arr').val($('#precondicion_arr').val() + ";" + $(this).val());

    });

    // alert(values);
    $('.arrPrecondicion').val(values);
    /* for (i = 0; i < escenarios.length; i++) {
         values += escenarios[i].value + ";";
     }*/
    //$('#precondicion_arr').val(values);

}

function doSearch() {
    var tableReg = document.getElementById('example2');
    var searchText = document.getElementById('searchTerm').value.toLowerCase();
    for (var i = 1; i < tableReg.rows.length; i++) {
        var cellsOfRow = tableReg.rows[i].getElementsByTagName('td');
        var found = false;
        for (var j = 0; j < cellsOfRow.length && !found; j++) {
            var compareWith = cellsOfRow[j].innerHTML.toLowerCase();
            if (searchText.length == 0 || (compareWith.indexOf(searchText) > -1)) {
                found = true;
            }
        }
        if (found) {
            tableReg.rows[i].style.display = '';
        } else {
            tableReg.rows[i].style.display = 'none';
        }
    }
}

//Ayuda para el Usuario de saber si lo que introdujo es correcto
function onBlurDeInputs(inputId) {
    var input = document.getElementById(inputId);

    regex = new RegExp("^[A-z ,.()0-9]+$");

    var resultado = regex.test(input.value);

    if (resultado == false && input.value != "") {
        input.style.borderColor = "red";
    }
    else if (resultado == false && input.value == "") {
        input.style.borderColor = "#ccc";
    }
    else {
        input.style.borderColor = "#00FF00"
    }

}