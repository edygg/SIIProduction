$(document).ready(function () {
    var iniDate = $('#InitialDate').pickadate({
        formatSubmit: 'yyyy-mm-dd',
        firstDay: 2,
        min: new Date()
    });

    var finalDate = $('#FinalDate').pickadate({
        formatSubmit: 'yyyy-mm-dd',
        firstDay: 2,
        min: new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate() + 1)
    });
    
});