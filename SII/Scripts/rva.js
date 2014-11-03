
$('.parte2').hide();
$('.resumen').hide();
$('#FinalDate').attr('disabled', true);

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

$('#InitialDate').on('change', function ()
{
    var self = this;
    if ($('#FinalDate').attr('disabled') === "disabled")
    {
        $('#FinalDate').val($(self).val());
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
    $('.parte2').hide();
    $('.resumen').show();

    $('.campus').text($('select option:selected').text());
    $('.initial_date').text($('#InitialDate').val());
    $('.final_date').text($('#FinalDate').val());

    if ($('input.semana').is(':checked')) {
        $('.dias').text('Todos los días');
    } else
    {
        var el = $('.dias_semana input:checked').next();
        var txt = " ";
        $(el).each(function (index, el)
        {
            if (index === $(el).length)
            {
                txt += $(el).text();

            } else
            {
                txt += $(el).text() + ", ";
            }
        })
        $('.dias').text(txt);
    }

    $('.observaciones').text($('#Observations').val());
});

$('.cancelar').on('click', function ()
{
    $('.parte1').show();
    $('.parte2').hide();
    $('.resumen').hide();
});
