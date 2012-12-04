(function ($) {

    $.fn.extend({

        getSetCodeForm: function (s) {

            if (!$.event._gscfCache) $.event._gscfCache = [];

            // initialise the controller with the relevant settings...
            s = $.extend({}, $.fn.getSetCodeForm.defaults, s);

            return this.each(function () {
                var $this = $(this);

                if (!this._gscfId) {
                    this._gscfId = $.guid++;
                    $.event._gscfCache[this._gscfId] = new GetSetCodeForm(this);
                }

                var controller = $.event._gscfCache[this._gscfId];

                controller.init(s);
            })
        }

    });

    $.fn.getSetCodeForm.defaults = {
        requiredClass: 'required',
        errorClass: 'error',
        errorBlockSelector: '.alert-error',
        buttonLoadingImageSource: null
    };

    function GetSetCodeForm(ele) {
        this.ele = ele;
        this.settings = {};
        this.errors = [];
        this.buttonLoadingImage = null;
    };
    $.extend(
		GetSetCodeForm.prototype, {
		    init: function (s) {
		        this.settings = s;
		        this.initSubmitButton();
		        if ($(this.ele).length > 0) {
		            // Force any contact form buttons to open as modal
		            $('.open-contact-form').attr('href', '#' + $(this.ele).attr('id')).bind('click', { form: $(this.ele) }, function (e) {
		                var focus = $('input,select,textarea', e.data.form).not('[type=hidden]').first();
		                setTimeout(function () {
		                    focus.focus();
		                }, 1000);
		            });
		        }

		        if (s.buttonLoadingImageSource != null) {
		            var img = $('<img />').attr({ 'src': s.buttonLoadingImageSource, 'alt': 'Loading...' }).bind('load', { form: this }, function (e) {
		                e.data.form.buttonLoadingImage = $(this);
		            });
		        }
		    },
		    buttonLoading: function (btn) {
		        var form = this;
		        btn.addClass('disabled');
		        setTimeout(function () {
		            var loader = $('<button>').addClass(btn.attr('class')).css('width', btn.outerWidth()).append(form.buttonLoadingImage).bind('click', {}, function (e) {
		                return false;
		            });
		            btn.replaceWith(loader);
		        }, 1);
		    },
		    initSubmitButton: function () {
		        $('input:submit', $(this.ele)).bind('click', { form: this }, function (e) {
		            if (!e.data.form.validate()) {
		                e.data.form.showErrors();
		                return false;
		            } else {
		                e.data.form.buttonLoading($(this));
		            }
		        });
		    },
		    showErrors: function () {
		        var eBlock = $(this.settings.errorBlockSelector, $(this.ele));
		        var ul = $('ul:first', eBlock);
		        if (this.errors.length == 0) {
		            eBlock.hide()
		            ul.empty();
		        } else {
		            var newUl = $('<ul />');
		            $.each(this.errors, function (i, v) {
		                newUl.append($('<li />').html(v));
		            });
		            ul.replaceWith(newUl);
		            eBlock.fadeIn('fast');
		        }
		    },
		    validate: function () {
		        var form = this;
		        form.errors = [];
		        $.each($('.control-group', $(this.ele)), function (a, b) {
		            var lblText = $('label:first', $(b)).html();
		            var required = $(b).hasClass(form.settings.requiredClass);
		            // This is required
		            if ($(b).hasClass('email')) {
		                // Validate as email - assume text field
		                form.doValidation($(b), lblText, $('input:text', $(b)), form.emailError, required);
		            } else if (required) {
		                var txt = $('input:text,textarea', $(b));
		                // Assert text field contains text
		                form.doValidation($(b), lblText, txt, form.requiredTextError, true);
		            }
		        });
		        return (form.errors.length == 0);
		    },
		    doValidation: function (group, lbl, element, validator, required) {
		        var msg = validator(lbl, element, required);
		        if (msg != null) {
		            group.addClass(this.settings.errorClass);
		            this.errors.push(msg);
		        } else {
		            group.removeClass(this.settings.errorClass);
		        }
		    },
		    emailError: function (errPrefix, element, required) {
		        if (!required && element.val().length == 0)
		            return null;
		        else {
		            var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
		            if (re.test(element.val()))
		                return null;
		            else
		                return element.data('val-required') ? element.data('val-required') : errPrefix + ': invalid email address';
		        }
		    },
		    requiredTextError: function (errPrefix, element, required) {
		        if (element.val().length > 0 || (!required && element.val().length == 0))
		            return null;
		        else
		            return element.data('val-required') ? element.data('val-required') : errPrefix + ': required field';
		    }
		}
    );
})(jQuery);