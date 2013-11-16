var app = app || {};

app.events = app.events || _.extend({}, Backbone.Events);

(function (views) {

    views.UnapprovedTracks = Backbone.View.extend({
        events: {
            'click .approve' : 'approveTracks'
        },
        approveTracks: function (e) {
        	e.preventDefault();
        	var allApprovedIds = Array();
        	var allChecked = $('[data-trackid]:checked').each(function(){
        	
        		allApprovedIds.push($(this).data('trackid'));
        	});

        	if(allApprovedIds.length > 0)
        	{
        		var model =new app.models.UnapprovedTracks();
					
                model.set({"ApprovedIds" : allApprovedIds});
	        	model.save(null,
	        	{
	        		success : function(data){
	        			alert(JSON.stringify(data));
	        		},
	        		error: function(x,y,z){
	        			alert(JSON.stringify(y.responseText));
	        			alert("Error approving selected tracks");
	        		}
	        	});
	        }
        },
        render:function()
        {
        	return this;
        }

    });

})(app.views = app.views || {});