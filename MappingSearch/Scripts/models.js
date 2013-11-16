var app = app || {};



(function (models) { 

	models.UnapprovedTracks = Backbone.Model.extend({
		url: function(){return '/Location/ApproveTracks'}		
	});

})(app.models = app.models || {});