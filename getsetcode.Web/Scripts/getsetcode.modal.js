
(function ($) {

    $(document).ready(function () {

        $.modal = new GetSetCodeModal(); // singleton instance
    });

    function GetSetCodeModal() {

        this._container = $('#modal');
        this._heading;
        this._content;
        this._exists = this._container.length > 0;
        if (this._exists) {
            this._heading = $('h3.modal-heading', this._container);
            this._content = $('div.modal-body', this._container);
            this._trigger = $('#modal-trigger');
        }
    }

    $.extend(GetSetCodeModal.prototype, {

        show: function (title, content) {
            if (this._exists) {
                this._heading.html(title);
                this._content.html(content);
                this._trigger.click();
            } else {
                alert(this.strip(content));
            }
        },

        strip: function (html) {
            var tmp = document.createElement("DIV");
            tmp.innerHTML = html;
            return tmp.textContent || tmp.innerText;
        }
    });

})(jQuery);