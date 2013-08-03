
var errorsDictionary = {
	'Name' : 'nameError',
	'Details' : 'detailsError',
	'Zip' : 'zipError',
	'State' : 'stateError',
	'City' : 'cityError',
	'Street' : 'streetError'
}

var NewLocationModel = Backbone.Model.extend({
	validate : function(attrs){
		var errorKeys = [];
		if(!attrs.TrackName){
			errorKeys.push("Name");
		}

		if(!attrs.City){
			errorKeys.push("City")
		}
		if(!attrs.State){
			errorKeys.push("State")
		}
		if(!attrs.StreetAddress){
			errorKeys.push("Street")
		}
		if(!attrs.Zip){
			errorKeys.push("Zip")
		}

		return errorKeys.length ? errorKeys : false;
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

$('#addLocationButton').live('click',function(){
	$(".text-error").hide();
	var newLocation = new NewLocationModel();
	$('.field-validation-error').hide();
	newLocation.on('invalid', function(model,errors){
		_.each(errors, function(errorKey){
			$('#' + errorsDictionary[errorKey]).show();
		});
	});
	
	newLocation.set({StreetAddress : $('#streetTextBox').val()});
	newLocation.set({City : $('#cityTextBox').val()});
	newLocation.set({State : $('#stateDropDown').val()});
	newLocation.set({Zip : $('#zipTextBox').val()});
	newLocation.set({TrackName : $('#nameTextBox').val()});
	newLocation.set({Details : $('#detailsTextBox').val()});
	newLocation.set({TrackWebsite : $('#websiteTextBox').val()})
	
	newLocation.save(null,
	{
		success : function(model,response,opts){
			window.location.href = response;
		},
		error : function(){
			console.log("Error");
		}
	});
});

$('#content').empty().append(new AddLocationView().render().el);


