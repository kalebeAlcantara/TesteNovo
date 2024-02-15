// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function salvar_personalizado(url, param, salvar_ok, salvar_erro) {
    $.ajax({
        type: "POST",
        processData: false,
        contentType: false,
        data: param,
        url: url,
        dataType: "json",
        success: (response) => {
            salvar_ok(response, get_param);
        },
        error: (response) => {
            salvar_erro();
        }
    });
}
function Confirmar(mensagem) {

    dialog.setTitle(new GwtMessage().getMessage('Confirmation'));
    dialog.setPreference('body', new GwtMessage().format("Your message"));
    dialog.setPreference('focusTrap', true);
    dialog.setPreference('onPromptComplete', doComplete);
    dialog.setPreference('onPromptCancel', doCancel);
    dialog.render();
}

function doComplete() {
    callback(true);
}

function doCancel() {
    callback(false);
}