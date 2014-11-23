$(document).ready(function () {
    var iniDate = $('#InitialDate').pickadate({
        formatSubmit: 'yyyy/mm/dd'
    });

    var finalDate = $('#FinalDate').pickadate({
        formatSubmit: 'yyyy/mm/dd'
    });
});