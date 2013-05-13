var NewLocationModel = Backbone.Model.extend({
	validate : function(attrs){
		var errors = [];
		if(!attrs.Name){
			errors.push("Name is required");
		}

		if(!attrs.Details){
			errors.push("Det")
		}
		if(!attrs.City){
			errors.push("City")
		}
		if(!attrs.State){
			errors.push("State")
		}
		if(!attrs.StreetAdd){
			errors.push("Street Address")
		}
		if(!attrs.Zip){
			errors.push("Zip")
		}

		return errors.length ? errors : false;
	},
	url: '/Location/AddLocation'

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
		alert(JSON.stringify(error));
	});

	newLocation.set({StreetAdd : $('#streetTextBox').val()});
	newLocation.set({City : $('#cityTextBox').val()});
	newLocation.set({State : $('#stateTextBox').val()});
	newLocation.set({Zip : $('#zipTextBox').val()});
	newLocation.set({Name : $('#nameTextBox').val()});
	newLocation.set({Details : $('#detailsTextBox').val()});
	
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


