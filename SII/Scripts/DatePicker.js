$(document).ready(function () {
    var iniDate = $('#InitialDate').pickadate({
        formatSubmit: 'dd/mm/yyyy',
        firstDay: 2,
        min: new Date()
    });

    var finalDate = $('#FinalDate').pickadate({
        formatSubmit: 'dd/mm/yyyy',
        firstDay: 2,
        min: new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate() + 1)
    });
    
});