$(document).ready(function () {
    var iniDate = $('#InitialDate').pickadate({
        formatSubmit: 'yyyy/mm/dd'
    });

    var finalDate = $('#FinalDate').pickadate({
        formatSubmit: 'yyyy/mm/dd'
    });

    $('.date-range-form').on('submit', function () {
        ini = $('#InitialDate');
        final = $('#FinalDate');
        errorDiv = $('.errors');

        errorDiv.empty();

        if (ini.val() == "" || final.val() == "") {
            var error = $('<div class="alert-box alert empty-date">El rango de fechas es un campo requerido.</div>');
            errorDiv.append(error);
            return false;
        }

        var iniDate = Date.parse($('input[name=InitialDate_submit]').val());
        var finalDate = Date.parse($('input[name=FinalDate_submit]').val());

        if (iniDate > finalDate) {
            var error = $('<div class="alert-box alert empty-date">La fecha inicial es mayor que la final. Revise el rango de fechas.</div>');
            errorDiv.append(error);
            return false;
        }
    });
});