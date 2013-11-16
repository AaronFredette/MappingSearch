var app = app || {};

$(function () {
    var conditions = {
        '.unapprovedTracks': function ($el) {
            return new app.views.UnapprovedTracks({
                el:$el
            });
        }
    };

    var views = [];
    _(conditions).each(function (value, key) {

        $(key).each(function () {
            var $this = $(this);
            var view = value($this);
            if (!view.IRenderMyself) {
                views.push(view.render());
            } else {
                views.push(view);
            }
        });
    });

});