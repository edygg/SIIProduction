$(document).ready(function () {
    var iniDate = $('#InitialDate').pickadate({
        min: new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate() + 1)
    });

    var finalDate = $('#FinalDate').pickadate({
        min: new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate() + 2)
    });
});