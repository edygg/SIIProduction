$(document).ready(function () {
    $('#RoleName').on('change', function () {
        if ($(this).val() == "Guardia") {
            $('.guard-details').show();
        } else {
            $('.guard-details').hide();
        }
    });

    $('#RoleName').trigger('change');
});