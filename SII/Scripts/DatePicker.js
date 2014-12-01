$(document).ready(function () {
    var iniDate = $('#InitialDate').pickadate({
        min: new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate()),
        formatSubmit: 'yyyy/mm/dd'
    });

    var finalDate = $('#FinalDate').pickadate({
        min: new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate() + 1),
        formatSubmit: 'yyyy/mm/dd'
    });

    $.validate();
});