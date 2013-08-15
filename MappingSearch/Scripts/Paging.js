var DisplayFilters = DisplayFilters || {};

var PageNumberView = Backbone.View.extend({
	tagName: 'li',
	className: 'paginationTab',
	render: function(){

		this.$el.html('<a href="#" title="Skip to this page">' + (this.model+1) + '</a>');
		
		if(this.model == DisplayFilters.Page){
			this.$el.addClass('active');
		}


		return this;
	},
	events : {'click' : 'setpage'},
	setpage : function()
	{
		alert(DisplayFilters.attributes.Page);
		DisplayFilters.set('Page', this.model);
		alert(DisplayFilters.attributes.Page);
	}
});

var PaginationList = Backbone.View.extend({
	tagName : 'ul',
	render :function(){
		
		for(var i =0; i< this.model; i++)
		{
			this.$el.append(new PageNumberView({model:i}).render().el);
		}

		return this;
	}
});

$(document).ready(function(){
	var paginationList = new PaginationList({model:DisplayFilters.attributes.TotalPages});
	$('.pagination').empty().append(paginationList.render().el);
});