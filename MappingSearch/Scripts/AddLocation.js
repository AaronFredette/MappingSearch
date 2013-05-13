var NewLocationModel = Backbone.Model.extend({
	validate : function(attrs){
		var errors = [];
		if(!attrs.state){
			errors.push("State is required");
		}

		if(!attrs.name){
			errors.push("Name is required");
		}

		if(!attrs.details){
			errors.push("Name")
		}

		return errors.length ? errors : false;
	},
	url: '/AddLocation/AddLocation'

});

var AddLocationView = Backbone.View.extend({
	render : function(){
		var template = $("#AddLocationTemplate").html();
		this.$el.append(_.template(template));
		return this;
	}
});

$('#addLocationButton').on('click',function(){
	
	
	var newLocation = new NewLocationModel();
	newLocation.on('invalid', function(model,error){
		alert("there are errors");
	});

	newLocation.set({state : $('#stateTextBox').val()});
	newLocation.set({name : $('#nameTextBox').val()});
	newLocation.set({details : $('#detailsTextBox').val()});
	
	newLocation.save(null,
	{
		success : function(model,response,opts){
			console.log(JSON.stringify(response));
		},
		error : function(){
			console.log("Error");
		}
	});
});

$('#content').empty().append(new AddLocationView().render().el)


