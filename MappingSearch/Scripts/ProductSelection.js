/*****************************************************
				MODELS AND COLLECTIONS
*******************************************************/
var DisplayFilters = new Backbone.Model({
	Brand :'',
	Subcategory:'',
	Page:0,
	Category:$('#categoryName').val()
});


var Facets = Backbone.Model.extend({
	url:function(){
		return "/ProductApi/GetProductFacets?id="+DisplayFilters.attributes.Category;
	},
	
});

var AllProducts = Backbone.Collection.extend({
	url: function(){
		return '/ProductApi/GetAllProducts?id='+DisplayFilters.attributes.Page +
				'&category='+DisplayFilters.attributes.Category +
				'&subcategory='+DisplayFilters.attributes.Subcategory +
				'&brand='+DisplayFilters.attributes.Brand;
	},
});

var allProducts = new AllProducts();
allProducts.fetch({
	async: false,
	success: function(){
		console.log(JSON.stringify(allProducts));
	},
	error: function(){
		console.log("ERROR");
	}
});

var allFacets = new Facets();
allFacets.fetch({
	async: false,
	reset:true,
	success: function(){
		console.log(JSON.stringify(allFacets));
	},
	error: function(){
		console.log("ERROR");
	}
});

DisplayFilters.on('change',function() {
	allProducts.fetch({
		async: false,
		reset:true,
		success: function(){
			console.log(JSON.stringify(allProducts));
		},
		error: function(){
			console.log("ERROR");
		}
	});
});

/*****************************************************
				VIEWS
*******************************************************/
var AllProductsView = Backbone.View.extend({
	tagName : 'div',	
	initialize : function(){
		this.collection.on('reset',function(){
			this.render();
		},this);
	},
	render : function(){
		//this.$el.html($('AllProductsViewTemplate').html());
		this.$el.empty();
		$('#noProductsFound').hide();
		if(this.collection.models.length > 0)
		{
			_(this.collection.models).each(function(product){
				this.$el.append(new ProductView({model:product}).render().el);
			},this);
		}else{
			$('#noProductsFound').show();
		}

		return this;
	}
});

var ProductView = Backbone.View.extend({
	tagName : 'div',
	render : function(){
		var template = $('#ProductsViewTemplate').html();
		this.$el.html(_.template(template,this.model.attributes));
		return this;	
	}
});


var BrandsFacetsView = Backbone.View.extend({
	tagName : 'select', 
	className:'offset2',
	id : 'brandFacets',
	render : function(){
		if(this.model.length > 0)
		{
			this.$el.append('<option value="">All Brands</option>');
			_(this.model).each(function(facet){
				this.$el.append(new SelectOptionView({model:facet}).render().el);
			},this);
		}

		return this;
	},
	events: {
		'change' : 'handleBrandChange'
	}, 
	handleBrandChange: function(){
		DisplayFilters.set('Brand', $('#brandFacets').val());
	}
});

var SubcategoriesFacetsView = Backbone.View.extend({
	tagName : 'select', 
	id:'subcategoryFacets',
	render : function(){
		if(this.model.length > 0)
		{
			this.$el.append('<option value="">All Subcategories</option>');
			_(this.model).each(function(facet){
				this.$el.append(new SelectOptionView({model:facet}).render().el);
			},this);
		}
		//this.$el.change(handleSubcategoryChange);
		return this;
	},
	events : {
		'change' : 'handleSubcategoryChange'
	},
	handleSubcategoryChange :function (){
		DisplayFilters.set('Subcategory',$('#subcategoryFacets').val());
	}
});

var SelectOptionView = Backbone.View.extend({
	tagName:'option',
	className: 'capitalize',
	render : function(){
		this.$el.val(this.model);		
		this.$el.html(this.model);

		return this;
	}
});

/*****************************************************
				INITS
*******************************************************/
var allProductsView = new AllProductsView({collection:allProducts});
var subcategoriesFacetsView = new SubcategoriesFacetsView({model:allFacets.attributes.Subcategories});
var brandFacetsView = new BrandsFacetsView({model:allFacets.attributes.Brands});
$('#contentBody').append(allProductsView.render().el);
$('#filterContainer').append(subcategoriesFacetsView.render().el);
$('#filterContainer').append(brandFacetsView.render().el);
