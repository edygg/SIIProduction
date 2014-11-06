var init = 0;
$(function () {
    $('.parte2').hide();
    $('.resumen').hide();
    $('#FinalDate').attr('disabled', true);
    $('.dias_semana input').attr('disabled', true);

    $('.tipo_entrada').attr('name', 'tipo_entrada[' + init + ']');
    $('.duplicate').data('current', init);


});

$('.next').on('click', function () {
    if ($('.parte2').css('display') === "none") {
        if ($('#InitialDate').val() != "") {
            $('.parte1').hide();
            $('.parte2').show();
        } else {
            alert("Ingrese una fecha para la visita");
        }
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

        var d = new Date($('#InitialDate').val());
        var weekday = new Array(7);
        weekday[0] = "L";
        weekday[1] = "M";
        weekday[2] = "X";
        weekday[3] = "J";
        weekday[4] = "V";
        weekday[5] = "S";
        weekday[6] = "D";
        var dayOfWeek = d.getDay() - 1 < 0 ? 6 : d.getDay() - 1;
        console.log(dayOfWeek);
        var n = weekday[dayOfWeek];
        $('input.dia').attr('checked', false);
        $('input[value^=' + n + ']').attr('checked', true);
        $('input[value^=' + n + ']').attr('disables', false);
    }
});

var $tipo_fecha = $('input[name^=tipo_fecha]')
$tipo_fecha.on('change', function () {
    if ($($tipo_fecha).filter('.fecha_unica').is(':checked') === true) {
        $('#FinalDate').val($('#InitialDate').val()).attr('disabled', true);
        $('.dias_semana input').attr('disabled', true);
        $('.dias_semana input').attr('checked', false);
    } else {
        $('#FinalDate').attr('disabled', false);
        $('.dias_semana input').attr('disabled', false);
        $('.dia').each(function (index, el) {
            if (index >= 0 && index <= 4)
            {
                $($('.dia')[index]).attr('checked', true);
            }
        })
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
    
});

$('.agregar').on('click', function ()
{

    $($('.duplicate')[0]).clone().appendTo($('.duplicate').parent());
    var current = $('.duplicate').data('current');
    current++;
    var $to_d = $($('.duplicate')[current]);
    $($('.duplicate')[current]).find('input.tipo_entrada').attr('name', 'tipo_entrada[' + current + ']');
    $('.duplicate').data('current', current);

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

$('.autorizar').on('click', function ()
{
    if (confirm("Al momento autorizar la entrada a estas personas se hacer responsable de los daños que pudiesen causar"))
    {
        console.log("Entre");
        $('form').submit();
    }
});