
var eventAggregator = _.extend({},Backbone.Events);

var Location = Backbone.Model.extend({});
var Locations = Backbone.Collection.extend({
	url: '/Location/AllLocations',
	model: Location
});
var allLocations = new Locations();
allLocations.fetch({
	async: false,
	success: function(){
		console.log(JSON.stringify(allLocations));
		
	},
	error: function(){
		console.log("ERROR");
	}
});
	
var AllLocationsView = Backbone.View.extend({
	tagName : 'ul',
	render : function(){
		_(this.collection.models).each(function(location){
			this.$el.append(new LocationListView({model:location}).render().el);
		},this);
		return this;
	}
});

var LocationListView = Backbone.View.extend({
	tagName : 'li',
	render : function(){
		var template = $('#LocationListViewTemplate').html();
		this.$el.html(_.template(template,this.model.attributes));
		return this;
	},

	events : {
		'click' : function(){
			eventAggregator.trigger('location:selected',this.model);
		}
	}
});

var LocationDetailsView = Backbone.View.extend({
	render : function(){
		var template = $('#LocationDetailsTemplate').html();
		this.$el.append(_.template(template,this.model.attributes));
		return this;
	}
});


var LocationRouter = Backbone.Router.extend({
	routes : {
		'locations' : 'locations',
		'view/:id' : 'locationDetails'
	},
	locations : function (){
		$('#content').html(new AllLocationsView({collection:allLocations}).render().el);
	},
	locationDetails : function(id){
		var selectedLocation = _(allLocations).find(function(location){
			return location.get('id') === id;
		});
		$('#content').empty().append(new LocationDetailsView({model:selectedLocation}).render().el);
	}	
});

eventAggregator.on('location:selected', function(location){
	var urlPath = 'view/' + location.get('id');
	router.navigate(urlPath,{trigger:true});
});

var router = new LocationRouter();
Backbone.history.start();


if(router.routes[Backbone.history.fragment] == null || router.routes[Backbone.history.fragment] =='locations')
{
	router.navigate('locations',{trigger:true});
}
