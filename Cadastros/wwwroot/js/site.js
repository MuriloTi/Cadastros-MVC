// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function MascaraCEP(cep) {

    var v = cep.value;

    if (isNaN(v[v.length - 1])) {
        cep.value = v.substring(0, v.length - 1);
        return;
    }

    if (v.length == 5) cep.value += "-";
}

function MascaraTelefone(telefone) {

    var v = telefone.value;

    if (isNaN(v[v.length - 1])) {
        telefone.value = v.substring(0, v.length - 1);
        return;
    }

    if (v.length == 1) telefone.value = "(" + telefone.value;
    if (v.length == 3) telefone.value += ") ";
    if (v.length == 10) telefone.value += "-";
}