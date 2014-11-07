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
            var iniDate = $('input[name=InitialDate_submit]').val().split("/");
            var finalDate = $('input[name=FinalDate_submit]').val().split("/");

            iniDate = new Date(parseInt(iniDate[0]), parseInt(iniDate[1]), parseInt(iniDate[2]));
            finalDate = new Date(parseInt(finalDate[0]), parseInt(finalDate[1]), parseInt(finalDate[2]));
            if (iniDate > finalDate && $('.fecha_multi').is(':checked')) {
                alert("La fecha final es mayor que la fecha inicial.");
            } else {
                $('.parte1').hide();
                $('.parte2').show();
            }
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
    if ($('.agregar').attr("disabled") == "disabled") return;

    $($('.duplicate')[0]).clone().appendTo($('.duplicate').parent());
    var current = $('.duplicate').data('current');
    current++;
    var $to_d = $($('.duplicate')[current]);
    $($('.duplicate')[current]).find('input.tipo_entrada').attr('name', 'tipo_entrada[' + current + ']');
    $($('.duplicate')[current]).find('input.nombres').attr('disabled', 'disabled');
    $($($('.duplicate')[0]).find('input.tipo_entrada')[0]).attr('checked', true);
    $($($('.duplicate')[0]).find('input.nombres')[0]).val("");
    $('.duplicate').data('current', current);

    $('.agregar').each(function (index, el)
    {
        if (index !== 0) {
            $(el).removeClass('tiny agregar').addClass('alert');
            $(el).removeClass('fi-plus');
            $(el).html("<i class="+"fi-x"+"></i>");
        }
    });

    $('.alert').on('click', function () {
        $(this).parents().eq(2).remove();
        if ($('.alert').length !== $('.duplicate').data('current')) {
            $($('.duplicate')[$('.alert').length]).find('input.tipo_entrada').attr('name', 'tipo_entrada[' + $('.alert').length + ']');1
            $('.duplicate').data('current', $('.duplicate').data('current') - 1);
        }
    });
    

});

$('.guardar').on('click', function () {
    if ($('.duplicate').length == 1) {
        alert("Ingrese los nombres de las visitas.");
        return;
    }
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
    $('.listado').empty();
    $('.duplicate').find('.nombres').each(function (index, element) {
        if ($(element).val() != "")
            $('.listado').append('<tr><td>' + $(element).val() + '</td><td>' + $(element).parent().parent().parent().find('input:checked.tipo_entrada').val() + '</td></tr>');
    });

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
    if (confirm("Al momento autorizar la entrada a estas personas se hace responsable de los daños que pudiesen causar"))
    {
        $('form').submit();
    }
});

$(document).ready(function () {
    $('.nombres').on('blur', function () {
        var currentName = $(this).val();
        var regexp = /^[a-z\s]{5,100}$/i;
        if (!regexp.test(currentName)) {
            $(this).parent().children('small.error').remove();
            $(this).addClass("error");
            $(this).parent().append('<small class="error">El nombre solo debe contener hasta 100 letras.</small>');
            $('.agregar').attr("disabled", "disabled");
        } else {
            $(this).removeClass("error");
            $(this).parent().children('small.error').remove();
            $('.agregar').removeAttr("disabled", "disabled");
        }
    });

    $('.observations').on('blur', function () {
        var currentVal = $(this).val();
        var regexp = /^[a-z0-9\s\.\_\-\,\@]{0,150}$/i;
        if (!regexp.test(currentVal)) {
            $(this).parent().children('small.error').remove();
            $(this).addClass("error");
            $(this).parent().append('<small class="error">Las observaciones pueden contener hasta 150 caracteres entre letras, números, guiones y arrobas.</small>');
            $('.guardar').attr("disabled", "disabled");
        } else {
            $(this).removeClass("error");
            $(this).parent().children('small.error').remove();
            $('.guardar').removeAttr("disabled", "disabled");
        }
    });
});