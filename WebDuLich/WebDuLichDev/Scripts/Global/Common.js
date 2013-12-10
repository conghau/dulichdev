(function ($) {
    $.fn.extend({
        filter_inputDateTime: function (format) {
            var inputAll = $(this);
            $.each(inputAll, function (k, input) {
                //$(input).mask(toMaskedFormat(format));
                $(input).change(function () {
                    var id = '#h' + input.id.toString();
                    // ReFormat DateTime to yyyy/mm/dd format
                    $(id).val(getDateTimeDefaultFormat(format, $(this).val()));
                    // Regular Check Valid Datime
                    var string = $(id).val();

                    if (string == null || string == '____/__/__')
                        string = '';
                    var word = /^(19|20)\d\d[-\/.](((0[13578]|(10|12))[-\/.](0[1-9]|[1-2][0-9]|3[0-1]))|(02[-\/.](0[1-9]|[1-2][0-9]))|((0[469]|11)[-\/.](0[1-9]|[1-2][0-9]|30)))$/ //regular expression defining datetime yyyy/mm/dd
                    if (string != '' && string.search(word) == -1) //if match failed
                    {
                        jAlert('Invalid Date Time', 'Message');
                        $(this).attr("value", "");
                        $(id).val('');
                    }
                    // ------Regular Check Valid Datime

                    $('form').load();
                });
                $(function () {
                    var id = '#h' + input.id.toString();
                    $(id).val(getDateTimeDefaultFormat(format, $(input).val()));

                });
            });
        }
    });
})(jQuery);

$(function () {

    var currentURL = window.location.href.replace(/#[\w]*/g, '');
    var currertUrlAction = location.pathname;
    $('div.navbar-inner ul.nav li ul li a[href="' + currertUrlAction + '"]').parent().addClass('active');
    if ($('div.navbar-inner div.container ul.nav li ul li a[href="' + currertUrlAction + '"]').parent().hasClass('dropdown-item'))
    {
        $('div.navbar-inner div.container ul.nav li ul li a[href="' + currertUrlAction + '"]').parent().parent().parent().addClass('active');
    }

   var message = $('#messageBoxCode').val();
    if (message != '') {
        if (message.indexOf('ERR') >= 0 || message.indexOf('VAL') >= 0) {
            $('#messageBox').addClass('alert-error');
        }
        else {
            $('#messageBox').addClass('alert-success');
        }

        $('#messageBox').css('display', '');
    }
    else {
        $('#messageBox').css('display', 'none');
    }
    $(this).find('.itranparent_child').hide();
    $('.dropdown li').hover(
        function () {
            $('ul, img', this).show();
            $(this).find('.itranparent_child').show();
        },
        function () {
            $('ul, img', this).hide();
            $(this).find('.itranparent_child').hide();
        }
    );

    // active menu
    var currentLocation = $(location).attr('pathname');
    $("li.mainnav").each(function (i) {
        var submenu = $(this).children('ul.submenu');
        submenu.children('li').each(function (i) {
            var url = $(this).children('a').attr('href');
            if (currentLocation == url) {
                $(this).parent().parent('li.mainnav').children('a').first().addClass('ActiveMenu');
                return false;
            }
        });
    });

    $(".TableGrid th").click(function () {
        if ($(this).parent().parent().parent().attr("group") == 'Exception')
            return;
        if ($(this).parent().parent().parent().attr("group") == 'NoSort')
            return;
        if ($('#IsPrint').attr('id'))
            $('#IsPrint').val('false');
        var id = this.id;
        var orderBy = $('#orderBy');
        var orderDirection = $('#orderDirection');
        if (id == 'Selected') {
            //  $("INPUT[type='checkbox'][group='Selected']").attr('checked', $('#checkAll').is(':checked'));
        }
        else if (id == 'A_Selected') {
            $("INPUT[type='checkbox'][group='A_Selected']").attr('checked', $('#AcheckAll').is(':checked'));
        }
        else if (id == 'L_Selected') {
            $("INPUT[type='checkbox'][group='L_Selected']").attr('checked', $('#LcheckAll').is(':checked'));
        }
        else {
            if (orderBy.val() == id) {
                if ($('#orderDirection').val() == 'ASC')
                    $('#orderDirection').attr('value', 'DESC');
                else
                    $('#orderDirection').attr('value', 'ASC');
            }
            else {
                $('#orderDirection').attr('value', 'ASC');
                $('#orderBy').attr('value', id);
            }

            //$('#Action').val('');
            //$('.required').removeAttrs('min max');
            //$('.required').removeClass('required');

            $('#frmMain').submit();

        }

    });
    //style for odd row in table.
    //$("table.Metro>tr:odd").css("background-color", "#f9f9f9");
    // active menu
   
});

function gethostname()
{
    var urlHost = window.location.protocol + '//' + window.location.host;
    return urlHost
}

function formatConvert(format) {
    format = format.toLowerCase();
    format = format.replace("yyyy", "yy");
    format = format.replace("mmm", "M");
    return format;
}

function formatConvert(format) {
    format = format.toLowerCase();
    format = format.replace("yyyy", "yy");
    format = format.replace("mmm", "M");
    return format;
}

function getDateTimeDefaultFormat(format, datetime) {
    if (datetime.length < 4)
        return '';
    format = format.toLowerCase();
    pos11 = format.indexOf("d");
    pos12 = format.lastIndexOf("d");
    pos21 = format.indexOf("m");
    pos22 = format.lastIndexOf("m");
    pos31 = format.indexOf("y");
    pos32 = format.lastIndexOf("y");
    sep = "/";
    return datetime.substring(pos31, pos32 + 1) + sep + datetime.substring(pos21, pos22 + 1) + sep + datetime.substring(pos11, pos12 + 1)
}

function paging(value, pageNum) {
    if (value > 0 && value <= pageNum) {
        $('#Page').attr('value', value);
        $('.required').removeAttr('min');
        $('.required').removeClass('required');
        mergeForms();
    }
}

function mergeForms() {
    var forms = document.forms;
    var targetForm = forms['frmMain'];
    $.each(forms, function (i, f) {
        if (f != targetForm) {
            $(f).find('input, select, textarea').clone().appendTo($(targetForm)).hide();
        }
    });
    $('#frmMain').submit();
}

function sizeIViewer() {
    /*BEGIN fixed position invoice image*/
    //    $('.bor_img').css('height', $(window).height() * 0.84);
    //    $('.bor_img').css('width', $(window).width() * 0.575);
    $('.bor_img').css('height', $(window).height() * 0.84);
    $('.bor_img').css('width', $(window).width() * 0.525);
    var windw = $(window);
    $.fn.followTo = function (pos) {
        var $this = this,
				$window = $(windw);

        $window.scroll(function (e) {

            if ($window.scrollTop() > pos) {
                $this.css({
                    position: '',
                    top: pos
                });
            } else {
                if ($window.scrollTop() > ($(window).height() * 0.15)) {
                    $this.css({
                        position: 'relative',
                        top: $window.scrollTop() - ($(window).height() * 0.15)
                    });
                } else {
                    $this.css({
                        position: ''
                    });
                }
            }
        });
    };
    $('.wrap_invimg').followTo($(window).height() * 100);
    /*END fixed position invoice image*/
}

