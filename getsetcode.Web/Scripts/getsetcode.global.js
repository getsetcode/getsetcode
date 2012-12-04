jQuery(function ($) {
    setPopovers(null);
    $('.history-loader').postLoader({ type: 'history' });
    $('.blog-loader').postLoader({ type: 'blog', loadMoreClass: 'btn btn-large btn-inverse load-more', items: 3, syntaxHighlight: true });
    $('tr').rowLink();
    $('.more-content').moreContent();
    $('#contact-form').getSetCodeForm({ buttonLoadingImageSource: $('#button-loading-src').html() });
});

function setPopovers(wrapper) {
    $('.tip-me', wrapper).popover({
        trigger: 'hover',
        placement: popoverPlacement
    });
}

function popoverPlacement(context, source) {
    var width = $(window).width();
    var height = $(window).height();
    var position = $(source).position();
    var top = $(source).offset().top - $(window).scrollTop();
    if (top < 100)
        return 'bottom';
    if (height - top < 100)
        return 'top';
    if (width - $(source).offset().left > 400)
        return 'right';
    return 'left';
}

$.fn.rowLink = function () {
    $.each(this, function (i, v) {
        if ($(v).find('th').length == 0) {
            var a = $(v).find('a.row-link:first');
            if (a.length > 0) {
                $(v).css('cursor', 'pointer').click(function () {
                    document.location.href = a.attr('href');
                }).hover(function () {
                    $(this).addClass('highlight');
                }, function () {
                    $(this).removeClass('highlight');
                });
            }
        }
    });
}

$.fn.moreContent = function () {
    if ($(this).data('target')) {
        var target = $('#' + $(this).data('target'));
        target.hide();
        target.data('hidden', true);
        var showHtml = 'more <i class="icon-caret-down"></i>';
        var hideHtml = 'less <i class="icon-caret-up"></i>';
        $(this).show().html(showHtml).bind('click', { more: target, show: showHtml, hide: hideHtml }, function (e) {
            var hidden = e.data.more.data('hidden');
            if (hidden) {
                e.data.more.fadeIn('slow');
                $(this).html(e.data.hide);
            } else {
                e.data.more.fadeOut('fast');
                $(this).html(e.data.show);
            }
            e.data.more.data('hidden', !hidden);
        });
    } else {
        $(this).hide();
    }
}

$.fn.contactForm = function () {
    if (this.length > 0) {
        // Force any emailer buttons to open contact form in modal window
        $('.open-contact-form').attr('href', '#contact-form');
        $('#send-message').bind('click', {
            name: $('#contact-form-name'),
            email: $('#contact-form-email'),
            message: $('#contact-form-message')
        }, function (e) {
            var btn = $(this);
            var errors = false;
            if (e.data.name.val().length == 0) {
                errors = true;
                e.data.name.parents('.control-group:first').addClass('error');
            } else {
                alert(e.data.name.val().length);
                e.data.name.parents('.control-group:first').removeClass('error');
            }
            if (e.data.email.val().length == 0) {
                errors = true;
                e.data.email.parents('.control-group:first').addClass('error');
            } else {
                e.data.email.parents('.control-group:first').removeClass('error');
            }
            if (e.data.message.val().length == 0) {
                errors = true;
                e.data.message.parents('.control-group:first').addClass('error');
            } else {
                e.data.message.parents('.control-group:first').removeClass('error');
            }
            //$.modal.show('Incomplete form', 'Please provide a name, email address and message');
            if (errors) return false; 
            else {
                btn.addClass('disabled');
                setTimeout(function () {
                    btn.attr('disabled', 'disabled').buttonLoading();
                }, 1);
            }
        });
    }
}

$.fn.buttonLoading = function () {
    var img = $('<img />').attr('src', $('#button-loading-src').html());
    var loader = $('<button>').addClass($(this).attr('class')).addClass('disabled').css('width', $(this).outerWidth()).append(img);
    $(this).replaceWith(loader);
}