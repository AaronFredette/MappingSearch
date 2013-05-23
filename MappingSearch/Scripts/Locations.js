
/*
	VARIABLE INIT
*/
var eventAggregator = _.extend({},Backbone.Events);

var Location = Backbone.Model.extend({});

var Locations = Backbone.Collection.extend({
	url: function(){
		if(!this.query)return '/Location/AllLocations';
		
		return (this.queryType == 'StateQuery')? '/Location/SearchStateLocations/' + this.query : '/Location/SearchDistance/'+this.query;
	},
	model: Location,
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

	
/*
	VIEWS
*/
var AllLocationsView = Backbone.View.extend({
	tagName : 'div',
	initialize : function(){
		this.collection.on('reset',function(){
			this.render();
		},this);
	},
	render : function(){
		this.$el.html($('#AllLocationsTemplate').html());
		_(this.collection.models).each(function(location){
			this.$el.find('#allLocationsList').append(new LocationListView({model:location}).render().el);
		},this);
		return this;
	}	
});

var SearchByStateView = Backbone.View.extend({
	tagName : 'div',
	render : function(){
		var template = $("#SearchByStateTemplate").html();
		this.$el.html(template);
		return this;
	},
	events : {
		'change #searchState' : 'handleStateSearch',
		'click #clearSearch' : 'clearSearch',
		'click #searchDistanceBtn' : 'handleDistanceSearch'
	},

	handleDistanceSearch : function(){
		var urlPath = 'search/'+$("#searchZip").val() + '/'+ $('#searchMiles').val();
		router.navigate(urlPath,{trigger:true});
	},

	handleStateSearch : function(){
		if($("#searchState").prop("selectedIndex")==0){
			this.clearSearch();	
		} else{
			var urlPath = 'search/'+ $('#searchState').val();
			router.navigate(urlPath,{trigger:true});
		}
	},

	clearSearch : function(){
		allLocationsView.collection.query = null;
		allLocationsView.collection.fetch({
			reset:true,
			async: false,
			success: function(){
				console.log(JSON.stringify(allLocations));
			},
			error: function(){
				console.log("ERROR");
			 }
		});	
		router.navigate('locations');
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
		},
		'mouseover' : function(){
			this.$el.addClass('hoverClass');
		},
		'mouseout' : function(){
			this.$el.removeClass('hoverClass');
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

/*
	ROUTING AND EVENTS
*/
var allLocationsView = new AllLocationsView({collection:allLocations});
var searchByStateView = (new SearchByStateView());
var LocationRouter = Backbone.Router.extend({
	routes : {
		'locations' : 'locations',
		'view/:id' : 'locationDetails',
		'search/:state': 'stateSearchResults',
		'search/:zip/:distance':'distanceSearchResults'
	},
	locations : function (){
		$('#contentHead').empty().append(searchByStateView.render().el);
		$('#contentBody').empty().append(allLocationsView.render().el);

	},
	locationDetails : function(id){
		var selectedLocation = _(allLocationsView.collection.models).find(function(location){
			return location.get('Id') == id;
		});
		$('#contentBody').empty().append(new LocationDetailsView({model:selectedLocation}).render().el);
	},
	stateSearchResults : function(state){
		allLocationsView.collection.queryType = 'StateQuery';
		allLocationsView.collection.query = state;
		allLocationsView.collection.fetch({reset:true});
	},
	distanceSearchResults : function(zip,distance){
		allLocationsView.collection.queryType = 'DistanceQuery';
		allLocationsView.collection.query = zip + '/' + distance;
		allLocationsView.collection.fetch({reset:true});
	}
});

eventAggregator.on('location:selected', function(location){
	var urlPath = 'view/' + location.get('Id');
	router.navigate(urlPath,{trigger:true});
});



var router = new LocationRouter();
Backbone.history.start();


if(router.routes[Backbone.history.fragment] == null || router.routes[Backbone.history.fragment] =='locations')
{
	router.navigate('locations',{trigger:true});
}