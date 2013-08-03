var errorsDictionary = {
	'Rating' :'ratingError',
	'ReviewText' : 'reviewTextError',
	'LengthOfUse' : 'lenghtError',
};



/**************************************
	MODELS AND COLLECTIONS
********************************************/

var DisplayManager = new Backbone.Model({
	SortMethod :'',
	Page:0,
	ProductId:$('#productId').val(),
	IsTrack : $("#categoryId").val() == 'Track',
	IsProduct : $("#categoryId").val() == 'Motorcycle',
});


var AllReviews = Backbone.Collection.extend({
	url : function (){
		if(DisplayManager.attributes.IsProduct)
		{
		return '/ReviewApi/GetAllReviewsForPage?id='+DisplayManager.attributes.ProductId+
				'&sortMethod='+DisplayManager.attributes.SortMethod+
				'&pageNumber='+DisplayManager.attributes.Page;
		}else if(DisplayManager.attributes.IsTrack)
		{
			return '/ReviewApi/GetAllTrackReviewsForPage?id='+DisplayManager.attributes.ProductId+
				'&sortMethod='+DisplayManager.attributes.SortMethod+
				'&pageNumber='+DisplayManager.attributes.Page;
		}
	}
})

var allReviewsCollection = new AllReviews();
allReviewsCollection.fetch({
	async: false,
	success: function(){
		console.log(JSON.stringify(allReviewsCollection));
	},
	error: function(){
		console.log("ERROR");
	}
});



var ReviewModel = Backbone.Model.extend({
	validate: function(attrs){
		var errorKeys = [];
		if(!attrs.Rating){
			errorKeys.push("Rating");
		}

		if(!attrs.ReviewText){
			errorKeys.push("ReviewText")
		}
		if(  DisplayManager.attributes.IsProduct && (!attrs.LengthOfUse || attrs.LengthOfUse.indexOf('Select') != -1 || attrs.LengthOfUse == " " )){
			errorKeys.push("LengthOfUse")
		}
		if(!attrs.ProductId){
			errorKeys.push("ProductId")
		}
		return errorKeys.length ? errorKeys : false;
    },
    url :function(){
		     if(DisplayManager.attributes.IsProduct)
				{
				 return "/ReviewApi/AddReview";
				}
				else if(DisplayManager.attributes.IsTrack)
				{
					return "/ReviewApi/AddTrackReview"
				}
			}

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

	newReview.set({Rating : $("input:radio[name ='overallRating']:checked").val()});
	newReview.set({ReviewText: $("textarea#reviewArea").val()});
	if(DisplayManager.IsProduct)
		newReview.set({LengthOfUse: $("select#durationQuantity").val().replace(/\s+/g, ' ')+ " " + $("select#durationUnit").val().replace(/\s+/g, ' ')});
	newReview.set({ProductId: $("#productId").val()});
	if(DisplayManager.IsTrack)
		newReview.set({NumberOfVisits : $("select#numberOfVisitis").val()})

	newReview.save(null,
		{
		success : function(model,response,opts){
			allReviewsCollection.fetch({
				async: false,
				reset:true,
				success: function(){
					console.log(JSON.stringify(allReviewsCollection));
				},
				error: function(){
					console.log("ERROR");
				}
			});
			$('#reviewForm').modal('hide');
			$("#showReviewBtnContainer").empty().html("<p>Your review has been posted. Thank you.");
		},
		error : function(){
			$('#reviewForm .serverError').show();
			console.log("Error");
		}
	});
});

DisplayManager.on('change',function(){
	allReviewsCollection.fetch({
		async: false,
		reset:true,
		success: function(){
			console.log(JSON.stringify(allReviewsCollection));
		},
		error: function(){
			console.log("ERROR");
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
var allReviewsView = new AllReviewsView({collection:allReviewsCollection});
$('#reviewsContainer').append(allReviewsView.render().el);