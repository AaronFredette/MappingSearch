/******************************
	MODELS AND COLLECTIONS
******************************/
var errorsDictionary = {
	'ProductName' :'productNameError',
	'Subcategory' : 'subcategoryError',
	'Brand' : 'brandError',
	'OtherBrand' :'otherBrandError',
	'Displacement' : 'displacementError',
	'Price' : 'priceError'
};


var NewMotorcycleModel = Backbone.Model.extend({
	validate : function(attrs){
		var errors =[];
		if(!attrs.Displacement)
		{
			errors.push('Displacement');
		}
		if(!attrs.ProductName)
		{
			errors.push('ProductName');
		}
		if(!attrs.Subcategory || attrs.Subcategory == "Select")
		{
			errors.push('Subcategory');
		}
		if(!attrs.Brand || attrs.Brand == "Select")
		{
			errors.push('Brand')
		}
		if(attrs.Brand == 'Other..' && !attrs.OtherBrand)
		{
			errors.push('OtherBrand');
		}
		if(attrs.Price && !attrs.Price.match(/^(\d+\.?\d{0,9}|\.\d{1,9})$/))
		{
			errors.push('Price');
		}
		return errors.length ? errors : false;
	},
	url : '/ProductApi/AddMotorcycle'
});

$("#submitNewGear").live('click', function(){

	var motorcycleModel = new NewMotorcycleModel();
	$('.field-validation-error').hide();

	motorcycleModel.on('invalid', function(model,errors){
		_.each(errors, function(errorKey){
			$('#' + errorsDictionary[errorKey]).show();
		});
	});

	motorcycleModel.set({ProductName : $('#ProductName').val()});
	motorcycleModel.set({Subcategory : $('#Subcategory').val()});
	motorcycleModel.set({Brand : $('#Brand').val()});
	motorcycleModel.set({OtherBrand : $('#OtherBrand').val()});
	motorcycleModel.set({Displacement: $('#Displacement').val()});
	motorcycleModel.set({Price: $('#Price').val()});
	motorcycleModel.set({Torque: $('#Torque').val()});
	motorcycleModel.set({TopSpeed: $('#TopSpeed').val()});
	motorcycleModel.set({EngineType: $('#EngineType').val()});
	motorcycleModel.set({Gears: $('#Gears').val()});


	motorcycleModel.save(null,
	{
		success: function(model,response,opts){
			window.location.href =response;
		},
		error: function(){
			$("#globalFormError").show();
		}
	});

});

$("#Brand").on('change', function(){

	if(this.selectedIndex == this.length-1)
	{
		//$('#otherBrandContainer').show();
		$('#otherBrandContainer').toggle('highlight');
	}else 
	{
		$('#otherBrandContainer').hide();
		$('#otherBrandError').hide();
	}
})