var DisplayFilters = DisplayFilters || {};

var PageNumberView = Backbone.View.extend({
	tagName: 'li',
	className: 'paginationTab',
	render: function(){

		this.$el.html('<a href="#" title="Skip to this page">' + (this.model+1) + '</a>');
		
		if(this.model == DisplayFilters.attributes.Page){
			this.$el.addClass('active');
		}


		return this;
	},
	events : {'click' : 'setpage'},
	setpage : function()
	{
	    $('.active').removeClass('active');
	    this.$el.addClass('active');
		DisplayFilters.set('Page', this.model);
	}
});


var PaginationList = Backbone.View.extend({
    tagName: 'ul',
    render: function () {
        this.model = DisplayFilters.attributes.TotalPages;
        this.$el.empty();
		for(var i =0; i< this.model; i++)
		{
			this.$el.append(new PageNumberView({model:i}).render().el);
		}

		return this;
	}
});

var paginationList = new PaginationList();

DisplayFilters.on('change', function () {
    $('.pagination').empty().append(paginationList.render().el);
});
