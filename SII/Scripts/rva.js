﻿$(document).ready(function () {
    // -------------------------- PART 1 ----------------------------------------------------------------------------
    // Initial state
    $('.parte2').hide();
    $('.resumen').hide();
    $('#FinalDate').attr('disabled', true);
    $('.dias_semana > input').attr('disabled', true);
    $('.nombres').attr('name', 'nombre[' + 0 + ']')
    $('.tipo_entrada').attr('name', 'tipo_entrada[' + 0 + ']');
    $('.duplicate').data('current', 0);

    // Only date or Date range
    $('.fecha_unica').on('change', function () {
        if ($(this).is(':checked')) {
            $('#FinalDate').attr('disabled', true);
            $('.dias_semana input').attr('disabled', true);
            $('.dias_semana input').attr('checked', false);
            $('#InitialDate').trigger('change');
            $('#InitialDate').val("");
            $('#FinalDate').val("");
        }
    });

    $('.fecha_multi').on('change', function () {
        if ($(this).is(':checked')) {
            $('#FinalDate').attr('disabled', false);
            $('.dias_semana input').attr('disabled', false);
            $('.dia').each(function (index, el) {
                if (index >= 0 && index <= 4) {
                    $(el).attr('checked', true);
                }
            });
            $('#InitialDate').val("");
            $('#FinalDate').val("");
        }
    });
    
    // Date fields
    $('#InitialDate').on('change', function () {
        if ($('#FinalDate').attr('disabled') === 'disabled') {
            $('#FinalDate').val($(this).val());

            var iniDate = new Date($('#InitialDate').val());
            var weekday = new Array(7);

            weekday[0] = "L";
            weekday[1] = "M";
            weekday[2] = "X";
            weekday[3] = "J";
            weekday[4] = "V";
            weekday[5] = "S";
            weekday[6] = "D";

            var dayOfWeek = iniDate.getDay() - 1 < 0 ? 6 : iniDate.getDay() - 1;
            var day = weekday[dayOfWeek];

            $('input.dia').attr('checked', false);
            $('input[value=' + day + ']').attr('checked', true);
        }
    });

    // All Week checkbox
    $('.semana').on('change', function () {
        if ($(this).is(':checked')) {
            $('.dia').prop('checked', true);
            $('.dia').attr('disabled', true);
        } else {
            $('.dia').prop('checked', false);
            $('.dia').attr('disabled', false);
            $('.dia').each(function (index, el) {
                if (index >= 0 && index <= 4) {
                    $(el).attr('checked', true);
                }
            })
        }
    });

    // Days checkboxes
    $('.dia').on('change', function () {
        if (!$('.dia').is(':checked')) {
            $('.semana').prop('checked', true);
            $('.semana').trigger('change');
        }
    });

    // Validations first frame
    $('.next').on('click', function () {
        //Delete all error message
        $('.empty-date').remove();
        $('.invalid-date-range').remove();
        //Dates are not empty
        if ($('.fecha_multi').is(':checked')) {
            if ($('#InitialDate').val() == "" || $('#FinalDate').val() == "") {
                $('#date-range').after($('<div class="row"><div class="alert-box alert empty-date">El rango de fechas es un campo requerido.</div></div>'));
                return false;
            }

            //Date range invalid
            var iniDate = $('input[name=InitialDate_submit]').val();
            var finalDate = $('input[name=FinalDate_submit]').val();

            iniDate = Date.parse(iniDate);
            finalDate = Date.parse(finalDate);
            if (iniDate >= finalDate) {
                $('#date-range').after($('<div class="row"><div class="alert-box alert invalid-date-range">Revise que la fecha inicial sea menor que la fecha final. Rango de fechas inválido.</div></div>'));
                return false;
            }
        } else {
            if ($('#InitialDate').val() == "") {
                $('#date-range').after($('<div class="row"><div class="alert-box alert empty-date">La fecha es requerida.</div></div>'));
                return false;
            }
        }

        $('.parte1').hide();
        $('.parte2').show();
    });
   
    // ---------------------------------- PART 2 ---------------------------------------

    $('.back').on('click', function () {
        $('.parte2').hide();
        $('.parte1').show();
    });

    $('.agregar').on('click', function () {
        $('.no-name-error').remove();
        $('.duplicate').find('input.nombres').trigger('blur');
        if ($('.agregar').attr("disabled") == "disabled") return;

        $($('.duplicate')[0]).clone().appendTo($('.duplicate').parent());
        var current = $('.duplicate').data('current');
        current++;
        var $to_d = $($('.duplicate')[current]);
        $($('.duplicate')[current]).find('input.nombres').attr('name', 'nombre[' + current + ']');
        $($('.duplicate')[current]).find('input.tipo_entrada').attr('name', 'tipo_entrada[' + current + ']');
        $($('.duplicate')[current]).find('input.nombres').attr('readonly', true);
        $($($('.duplicate')[0]).find('input.tipo_entrada')[0]).attr('checked', true);
        $($($('.duplicate')[0]).find('input.nombres')[0]).val("");
        $('.duplicate').data('current', current);

        $('.agregar').each(function (index, el) {
            if (index !== 0) {
                $(el).removeClass('tiny agregar').addClass('alert delete');
                $(el).removeClass('fi-plus');
                $(el).html("<i class=" + "fi-x" + "></i>");
            }
        });

        $('.button.delete').on('click', function () {
            $(this).parents('.duplicate').remove();
            $('.duplicate').each(function (index, el) {
                $(el).find('input.nombres').attr('name', 'nombre[' + index + ']');
                $(el).find('input.tipo_entrada').attr('name', 'tipo_entrada[' + index + ']');
                $('.duplicate').data('current', index);
            });
        });
    });

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

    $('.multiple_names').on('blur', function () {
        var currentNames = $(this).val().split("\n");
        var regexp = /^[a-z\s]{5,100}$/i;
        var txtArea = $(this);
        var hasError = false;

        currentNames.forEach(function (el, index) {
            if (!regexp.test(el)) {
                hasError = true;
                txtArea.parent().children('small.error').remove();
                txtArea.addClass("error");
                txtArea.parent().append($('<small class="error">Uno o varios de los nombres ingresados no contienen de 5 a 100 caracteres solamente letras. Revise además saltos de línea innecesarios.</small>'));
                $('.guardar').attr("disabled", "disabled");
            }
        });

        if (!hasError) {
            $(this).removeClass("error");
            $('.no-name-error').remove();
            $(this).parent().children('small.error').remove();
            $('.guardar').removeAttr("disabled", "disabled");
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

    $('.guardar').on('click', function () {
        if ($('.duplicate').length == 1 && $('.multiple_names').val() == "") {
            $('.no-name-error').remove();
            var error = $('<div class="row"><div class="alert-box alert no-name-error">Ingrese al menos un nombre.</div></div>')
            $('.tabs').parent().append(error);
            return false;;
        }

        if ($(this).attr('disabled')) {
            if ($('.duplicate').length <= 1 && $('.multiple_names').val() == "") {
                return false;
            }
        }

        $('.parte2').hide();
        $('.resumen').show();

        $('.campus').text($('select option:selected').text());
        $('.initial_date').text($('#InitialDate').val());
        $('.final_date').text($('#FinalDate').val());

        if ($('input.semana').is(':checked')) {
            $('.dias').text('Todos los días');
        } else {
            var el = $('.dias_semana input:checked').next();
            var txt = " ";
            $(el).each(function (index, el) {
                if (index === $(el).length - 1) {
                    txt += $(el).text();

                } else {
                    txt += $(el).text() + ", ";
                }
            })
            $('.dias').text(txt);
        }
        $('.listado').empty();

        if ($('dd.active a').attr('href') !== '#panel1' || $('.multiple_names').val() !== '') {
            //muchas personas
            var nombres = $('.multiple_names').val().split('\n');
            $(nombres).each(function (index, el) {
                $('.listado').append('<tr><td>' + el + '</td><td>' + $('.tipo_entrada_m:checked').val().substr(2, 12).toUpperCase() + '</td></tr>');
            });
        } else {
            //individuales
            $('.duplicate').find('.nombres').each(function (index, element) {
                if ($(element).val() != "")
                    $('.listado').append('<tr><td>' + $(element).val() + '</td><td>' + $(element).parent().parent().parent().find('input:checked.tipo_entrada').val() + '</td></tr>');
            });
        }

        $('.observaciones').text($('#Observations').val());
    });

    // ------------------ PART 3 ----------------------------------------
    $('.cancelar').on('click', function () {
        $('.parte1').show();
        $('.parte2').hide();
        $('.resumen').hide();
    });

    $('.autorizar').on('click', function () {
        $('form').submit();
    });
    
});