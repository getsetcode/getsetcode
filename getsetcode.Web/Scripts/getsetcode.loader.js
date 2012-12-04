(function ($) {

    $.fn.extend({

        postLoader: function (s) {

            if (!$.event._plCache) $.event._plCache = [];

            // initialise the history loader controller with the relevant settings...
            s = $.extend({}, $.fn.postLoader.defaults, s);

            return this.each(function () {
                var $this = $(this);

                if (!this._plId) {
                    this._plId = $.guid++;
                    $.event._plCache[this._plId] = new PostLoader(this);
                }

                var controller = $.event._plCache[this._plId];

                controller.init(s);
            })
        }

    });

    $.fn.postLoader.defaults = {
        type: 'history',
        loadingSelector: '.loading',
        loadMoreClass: 'btn btn-large load-more',
        loadMoreText: '<i class="icon-circle-arrow-down"></i> Load more',
        items: 5,
        syntaxHighlight: false
    };

    function PostLoader(ele) {
        this.ele = ele;
        this.settings = {};
        this.loaded = 0; // Number of items loaded
        this.type;
        this.syntaxHighlight;
        this.loading; // Loading indicator
        this.loadMore; // The anchor for loading more records
        this.last = null; // Each load updates this so subsequent loads know where to start from
        this.killScroll = false;
        this.loadComplete = false;
    };
    $.extend(
		PostLoader.prototype,
		{
		    init: function (s) {
		        this.setType(s.type);
		        this.setSyntaxHighlight(s.syntaxHighlight);
		        this.setItemNumber(s.items);
		        this.appendLoadMore(s.loadMoreClass, s.loadMoreText);
		        this.setLoadingIndicator(s.loadingSelector);
		        this.loadItems();
		        this.setScollLoad();
		    },
		    getNextLoadUrl: function () {
		        if (this.type == 'history')
		            return '/history/items/' + this.items + (this.last ? '/?last=' + this.last : '');
		        else if (this.type == 'blog')
		            return '/blog/items/' + this.items + '/' + this.loaded;
		    },
		    loadItems: function () {
		        var pl = this;
		        var ele = $(pl.ele);
		        var url = this.getNextLoadUrl();
		        $.ajax({
		            type: 'GET',
		            url: url,
		            dataType: 'json',
		            success: function (data) {
		                pl.last = data.Last;
		                pl.loaded = pl.loaded += data.Items;
		                var latest = $(data.Html);
		                pl.loading.before(latest.hide()).hide();
		                setPopovers(latest);
		                if (pl.syntaxHighlight) {
		                    $('pre', latest).addClass('prettyprint').addClass('linenums');
		                    window.prettyPrint && prettyPrint();
		                    $('pre.prettyprint').removeClass('prettyprint').removeClass('linenums');
		                }
		                latest.fadeIn('slow');
		                if (data.MoreAvailable) {
		                    pl.loadMore.fadeIn('fast');
		                } else
		                    pl.loadComplete = true;
		                pl.killScroll = false;
		            },
		            error: function () {
		                pl.loadMore.show();
		                pl.killScroll = false;
		            }
		        });
		    },
		    setType: function (t) {
		        if (t) {
		            this.type = t;
		        }
		    },
		    setSyntaxHighlight: function (h) {
		        if (h && typeof h === 'boolean')
		            this.syntaxHighlight = h;
		        else
		            this.syntaxHighlight = false;
		    },
		    setItemNumber: function (i) {
		        if (i && !isNaN(i)) {
		            this.items = i;
		        }
		    },
		    setLoadingIndicator: function (s) {
		        if (s) this.loadingSelector = s;
		        this.loading = $(this.loadingSelector);
		        if (this.loading.length > 0)
		            this.loading.show();
		        else {
		            this.loading = $('<span>Loading...</span>');
		            this.loadMore.before(this.loading);
		        }
		    },
		    appendLoadMore: function (c, t) {

		        if (c) this.loadMoreClass = c;
		        if (t) this.loadMoreText = t;

		        this.loadMore = $('<a />').addClass(this.loadMoreClass).attr({ 'href': '#', title: 'Load more' }).html(this.loadMoreText);

		        $(this.ele).append(this.loadMore.hide());

		        this.loadMore.bind('click', { pl: this }, function (e) {
		            if (!e.data.pl.loadComplete) {
		                e.data.pl.killScroll = true;
		                e.data.pl.loadItems();
		                $(this).hide();
		                e.data.pl.loading.show();
		            }
		            return false;
		        });
		    },
		    setScollLoad: function () {
		        // Detect that we are at bottom of page, and call autoloading function
		        var pl = this;
		        $(window).scroll(function () {
		            if (!pl.killScroll && $(window).scrollTop() + 100 >= ($(document).height() - ($(window).height()))) {
		                pl.loadMore.trigger('click');
		            }
		        });
		    }
		}
    );

})(jQuery);