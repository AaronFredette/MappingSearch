var errorsDictionary = {
	'Rating' :'ratingError',
	'ReviewText' : 'reviewTextError',
	'LengthOfUse' : 'lenghtError',
};



/**************************************
	MODELS AND COLLECTIONS
********************************************/

var DisplayFilters = new Backbone.Model({
	SortMethod :'',
	Page:0,
	TotalPages:0,
	ProductId:$('#productId').val(),
	IsTrack : $("#categoryId").val() == 'Track',
	IsProduct : $("#categoryId").val() == 'Product',
});

var ReviewCollection = Backbone.Collection.extend({});

var ViewData = Backbone.Model.extend({
	url : function (){
		if(DisplayFilters.attributes.IsProduct)
		{
		return '/ReviewApi/GetAllReviewsForPage?id='+DisplayFilters.attributes.ProductId+
				'&sortMethod='+DisplayFilters.attributes.SortMethod+
				'&pageNumber='+DisplayFilters.attributes.Page;
		}else if(DisplayFilters.attributes.IsTrack)
		{
			return '/ReviewApi/GetAllTrackReviewsForPage?id='+DisplayFilters.attributes.ProductId+
				'&sortMethod='+DisplayFilters.attributes.SortMethod+
				'&pageNumber='+DisplayFilters.attributes.Page;
		}
	}
})



var viewData = new ViewData();


var allReviews = new ReviewCollection(viewData.attributes.Model);

var ReviewModel = Backbone.Model.extend({
	validate: function(attrs){
		var errorKeys = [];
		if(!attrs.Rating){
			errorKeys.push("Rating");
		}

		if(!attrs.ReviewText){
			errorKeys.push("ReviewText")
		}
		if(  DisplayFilters.attributes.IsProduct && (!attrs.LengthOfUse || attrs.LengthOfUse.indexOf('Select') != -1 || attrs.LengthOfUse == " " )){
			errorKeys.push("LengthOfUse")
		}
		if(!attrs.ProductId){
			errorKeys.push("ProductId")
		}
		return errorKeys.length ? errorKeys : false;
    },
    url :function(){
		     if(DisplayFilters.attributes.IsProduct)
				{
				 return "/ReviewApi/AddReview";
				}
				else if(DisplayFilters.attributes.IsTrack)
				{
					return "/ReviewApi/AddTrackReview"
				}
			}

});

DisplayFilters.on('change', function () {
    FetchViewData(true);
});

$('#submitReviewBtn').live('click',function(){
	var newReview = new ReviewModel();
	$('#reviewForm .serverError').hide();
	$('#reviewForm .text-error').hide();
	newReview.on('invalid', function(model,errors){
		_.each(errors, function(errorKey){
			$('#' + errorsDictionary[errorKey]).show();
		});
	});

	newReview.set({Rating : $("input:hidden[name ='score']").val()});
	newReview.set({ReviewText: $("textarea#reviewArea").val()});

	if(DisplayFilters.get('IsProduct'))
		newReview.set({LengthOfUse: $("select#durationQuantity").val().replace(/\s+/g, ' ')+ " " + $("select#durationUnit").val().replace(/\s+/g, ' ')});
	newReview.set({ProductId: $("#productId").val()});
	if(DisplayFilters.get('IsTrack'))
		newReview.set({NumberOfVisits : $("select#numberOfVisitis").val()})

	newReview.save(null,
		{
		success : function(model,response,opts){
			FetchViewData(true);
			$('#reviewForm').modal('hide');
			$("#showReviewBtnContainer").empty().html("<p>Your review has been posted. Thank you.");
		},
		error : function(){
			$('#reviewForm .serverError').show();
			console.log("Error");
		}
	});
});






/*************************************
	VIEWS
***********************************/

var AllReviewsView = Backbone.View.extend({
	tagName:'div',
	initialize: function(){
		this.collection.on('reset',function(){
			this.render();
		},this);
	},
	render :function(){
		this.$el.empty();
		$("#noReviewsFound").hide();
		if(this.collection.models.length > 0 )
		{
			_(this.collection.models).each(function(review){
				this.$el.append(new ReviewView({model:review}).render().el);
			},this)

			this.$el.find(".ratyStarReadOnly").raty({ 
			 	score: function(){
			 		return $(this).attr('data-rating');
			 	},
			 	readOnly: true,
			 	half    : true,
			  	starHalf: '/Scripts/libs/img/star-half.png',
			  	starOn: '/Scripts/libs/img/star-on.png',
			  	starOff: '/Scripts/libs/img/star-off.png'});
		}else
		{
			$("#noReviewsFound").show();
		}
		return this;
	}
});

var ReviewView = Backbone.View.extend({
	tagName: 'div',
	render : function(){
		var template = $('#individualRewviewTemplate').html();
		this.$el.html(_.template(template,this.model.attributes));
		return this;
	}
})
/*********************************
	INITS
************************************/
$(document).ready(function(){
    
    var allReviewsView = new AllReviewsView({ collection: allReviews });
	$('#reviewsContainer').append(allReviewsView.render().el);
	FetchViewData(true);//INITIAL PAGE LOAD

 

$(".ratyStarInput").raty({ 
  	starHalf: '/Scripts/libs/img/star-half.png',
  	starOn: '/Scripts/libs/img/star-on.png',
  	starOff: '/Scripts/libs/img/star-off.png'});
});

//Functions 
var FetchViewData = function(reset){
	viewData.fetch({
		async: false,
		reset:reset,
		success: function(){
			allReviews.reset(viewData.attributes.Model);
			DisplayFilters.set('TotalPages',viewData.attributes.PageCount);
			console.log(JSON.stringify(viewData));
		},
		error: function(){
			console.log("ERROR");
		}
});
};