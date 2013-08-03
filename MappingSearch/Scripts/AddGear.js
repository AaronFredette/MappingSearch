/******************************
	MODELS AND COLLECTIONS
******************************/
var errorsDictionary = {
	'ProductName' :'productNameError',
	'Subcategory' : 'subcategoryError',
	'Brand' : 'brandError',
	'OtherBrand' :'otherBrandError',
	'Price' : 'priceError'
};


var NewGearModel = Backbone.Model.extend({
	validate : function(attrs){
		var errors =[];
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
	url : '/ProductApi/AddGear'
});

$("#submitNewGear").live('click', function(){

	var gearModel = new NewGearModel();
	$('.field-validation-error').hide();

	gearModel.on('invalid', function(model,errors){
		_.each(errors, function(errorKey){
			$('#' + errorsDictionary[errorKey]).show();
		});
	});

	gearModel.set({ProductName : $('#ProductName').val()})
	gearModel.set({Subcategory : $('#Subcategory').val()})
	gearModel.set({Brand : $('#Brand').val()})
	gearModel.set({OtherBrand : $('#OtherBrand').val()})
	gearModel.set({Price: $('#Price').val()})

	gearModel.save(null,
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