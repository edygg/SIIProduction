
$('.parte2').hide();

$('.next').on('click', function () {
    if ($('.parte2').css('display') === "none") {
        $('.parte1').hide();
        $('.parte2').show();
    }
});

$('.back').on('click', function () {
    if ($('.parte1').css('display') === "none") {
        $('.parte2').hide();
        $('.parte1').show();
    }
});

var $tipo_fecha = $('input[name^=tipo_fecha]')
$tipo_fecha.on('change', function () {
    if ($($tipo_fecha).filter('.fecha_unica').is(':checked') === true) {
        $('#FinalDate').val($('#InitialDate').val()).attr('disabled', true);
    } else {
        $('#FinalDate').attr('disabled', false);
    }
});

$('.semana').on('change', function () {
    var self = this;
    if ($(self).is(':checked')) {
        $('.dia').prop('checked', true)
        $('.dia').attr('disabled', true);
    } else {
        $('.dia').prop('checked', false)
        $('.dia').attr('disabled', false);
    }
});

$('form').on('submit', function () {
    console.log(1);
});

$('.agregar').on('click', function ()
{
    var to_d = $('.duplicate').html()
    $('.row.duplicate').parent().append("<div class='row duplicate'>" + to_d + "</div>");
});

$('.guardar').on('click', function () {

});

