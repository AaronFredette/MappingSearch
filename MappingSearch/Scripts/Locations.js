﻿
/*
	VARIABLE INIT
*/
var allMaps = Array();
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
		if(this.collection.models.length > 0)
		{
			_(this.collection.models).each(function(location){
				this.$el.find('#allLocationsList').append(new LocationListView({model:location}).render().el);
			},this);
		}
		else
		{
			this.$el.find('#allLocationsList').append('<div class="alert alert-info">No locations found.</div>')
		}
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

	handleDistanceSearch: function () {
	    var zip = $("#searchZip").val();
	    var miles =$('#searchMiles').val();
	    if (zip.trim() == "" || miles.trim() == "") {
	        $("#searchDistError").show();
	    } else {
	        $("#searchDistError").hide();
	        var urlPath = 'search/' + zip + '/' + miles;
	        router.navigate(urlPath, { trigger: true });
	    }
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
		this.render();//reset view to clear fields
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
		initializeGoogleMaps();
		router.navigate('/');
	}
});

var LocationListView = Backbone.View.extend({
	tagName : 'li',
	className: 'clearfix',
	render : function(){
		var template = $('#LocationListViewTemplate').html();
		this.$el.html(_.template(template,this.model.attributes));
		

		this.buildGoogleMapObject();
		
		return this;
	},

	events : {
		'click' : function(event){
			if($(event.target).parents().hasClass('mapCanvas'))
			{
				return;
			}
			
			$('#contentPopUp').show();
			$('#contentPopUp').empty().append(new LocationDetailsView({model:this.model}).render().el);
		},
		'mouseover' : function(){
			this.$el.addClass('hoverClass');
		},
		'mouseout' : function(){
			this.$el.removeClass('hoverClass');
		}
	},

	 buildGoogleMapObject : function(){

        var map_options = {
          center: new google.maps.LatLng(this.model.attributes.Lat, this.model.attributes.Lon),
          zoom: 7,
          mapTypeId: google.maps.MapTypeId.ROADMAP
        }

        var myMapObject = {canvas : this.$el.find('.mapCanvas')[0] , options: map_options, Lat : this.model.attributes.Lat , Lon :this.model.attributes.Lon};
        allMaps.push(myMapObject);
	 }

});

var LocationDetailsView = Backbone.View.extend({
	render : function(){
		var template = $('#LocationDetailsTemplate').html();
		this.$el.append(_.template(template,this.model.attributes));
		return this;
	},
	events: {
		'click .closeLightBox' : 'closeLightBox'
	},
	closeLightBox : function()
	{
		$('#contentPopUp').hide();
	}
});

/*
	ROUTING AND EVENTS
*/
var allLocationsView = new AllLocationsView({collection:allLocations});
var searchByStateView = (new SearchByStateView({collection:allLocations}));
$('#contentHead').empty().append(searchByStateView.render().el);
$('#contentBody').empty().append(allLocationsView.render().el);
initializeGoogleMaps();

var LocationRouter = Backbone.Router.extend({
	routes : {
		'search/:state': 'stateSearchResults',
		'search/:zip/:distance':'distanceSearchResults'
	},
	
	stateSearchResults : function(state){
		allLocationsView.collection.queryType = 'StateQuery';
		allLocationsView.collection.query = state;
		allLocationsView.collection.fetch({reset:true,async:false});
		initializeGoogleMaps();
	},
	distanceSearchResults : function(zip,distance){
		allLocationsView.collection.queryType = 'DistanceQuery';
		allLocationsView.collection.query = zip + '/' + distance;
		allLocationsView.collection.fetch({reset:true,async:false});
		initializeGoogleMaps();
	}
});



var router = new LocationRouter();
Backbone.history.start();




function initializeGoogleMaps(){
	for(var i =0; i<allMaps.length; i++){
    	var map = new google.maps.Map(allMaps[i].canvas,allMaps[i].options);
    	var location = new google.maps.LatLng(allMaps[i].Lat, allMaps[i].Lon);
    	addMarker(map,location);
	}
}
function addMarker(map, location){
		marker = new google.maps.Marker({
            position: location,
            map: map
        });
}

