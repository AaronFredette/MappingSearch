﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MappingSearch.Data
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="MotorcylceReview")]
	public partial class ReviewsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertReview(Review instance);
    partial void UpdateReview(Review instance);
    partial void DeleteReview(Review instance);
    partial void InsertProduct(Product instance);
    partial void UpdateProduct(Product instance);
    partial void DeleteProduct(Product instance);
    #endregion
		
		public ReviewsDataContext() : 
				base(global::MappingSearch.Data.Properties.Settings.Default.MotorcycleReviewConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ReviewsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ReviewsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ReviewsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ReviewsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<Review> Reviews
		{
			get
			{
				return this.GetTable<Review>();
			}
		}
		
		public System.Data.Linq.Table<Product> Products
		{
			get
			{
				return this.GetTable<Product>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _UserName;
		
		private string _Password;
		
		private string _Salt;
		
		private string _CurrentMotorcycle;
		
		private string _EmailAddress;
		
		private int _AdminLevel;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnSaltChanging(string value);
    partial void OnSaltChanged();
    partial void OnCurrentMotorcycleChanging(string value);
    partial void OnCurrentMotorcycleChanged();
    partial void OnEmailAddressChanging(string value);
    partial void OnEmailAddressChanged();
    partial void OnAdminLevelChanging(int value);
    partial void OnAdminLevelChanged();
    #endregion
		
		public User()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Salt", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Salt
		{
			get
			{
				return this._Salt;
			}
			set
			{
				if ((this._Salt != value))
				{
					this.OnSaltChanging(value);
					this.SendPropertyChanging();
					this._Salt = value;
					this.SendPropertyChanged("Salt");
					this.OnSaltChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CurrentMotorcycle", DbType="VarChar(50)")]
		public string CurrentMotorcycle
		{
			get
			{
				return this._CurrentMotorcycle;
			}
			set
			{
				if ((this._CurrentMotorcycle != value))
				{
					this.OnCurrentMotorcycleChanging(value);
					this.SendPropertyChanging();
					this._CurrentMotorcycle = value;
					this.SendPropertyChanged("CurrentMotorcycle");
					this.OnCurrentMotorcycleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmailAddress", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string EmailAddress
		{
			get
			{
				return this._EmailAddress;
			}
			set
			{
				if ((this._EmailAddress != value))
				{
					this.OnEmailAddressChanging(value);
					this.SendPropertyChanging();
					this._EmailAddress = value;
					this.SendPropertyChanged("EmailAddress");
					this.OnEmailAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AdminLevel", DbType="Int NOT NULL")]
		public int AdminLevel
		{
			get
			{
				return this._AdminLevel;
			}
			set
			{
				if ((this._AdminLevel != value))
				{
					this.OnAdminLevelChanging(value);
					this.SendPropertyChanging();
					this._AdminLevel = value;
					this.SendPropertyChanged("AdminLevel");
					this.OnAdminLevelChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Reviews")]
	public partial class Review : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ProductId;
		
		private int _ReviewId;
		
		private string _UserId;
		
		private string _Review1;
		
		private int _StarRating;
		
		private string _LengthOfUse;
		
		private System.DateTime _s;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnProductIdChanging(int value);
    partial void OnProductIdChanged();
    partial void OnReviewIdChanging(int value);
    partial void OnReviewIdChanged();
    partial void OnUserIdChanging(string value);
    partial void OnUserIdChanged();
    partial void OnReview1Changing(string value);
    partial void OnReview1Changed();
    partial void OnStarRatingChanging(int value);
    partial void OnStarRatingChanged();
    partial void OnLengthOfUseChanging(string value);
    partial void OnLengthOfUseChanged();
    partial void OnDatePostedChanging(System.DateTime value);
    partial void OnDatePostedChanged();
    #endregion
		
		public Review()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductId", DbType="Int NOT NULL")]
		public int ProductId
		{
			get
			{
				return this._ProductId;
			}
			set
			{
				if ((this._ProductId != value))
				{
					this.OnProductIdChanging(value);
					this.SendPropertyChanging();
					this._ProductId = value;
					this.SendPropertyChanged("ProductId");
					this.OnProductIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReviewId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ReviewId
		{
			get
			{
				return this._ReviewId;
			}
			set
			{
				if ((this._ReviewId != value))
				{
					this.OnReviewIdChanging(value);
					this.SendPropertyChanging();
					this._ReviewId = value;
					this.SendPropertyChanged("ReviewId");
					this.OnReviewIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Review", Storage="_Review1", DbType="VarChar(500) NOT NULL", CanBeNull=false)]
		public string Review1
		{
			get
			{
				return this._Review1;
			}
			set
			{
				if ((this._Review1 != value))
				{
					this.OnReview1Changing(value);
					this.SendPropertyChanging();
					this._Review1 = value;
					this.SendPropertyChanged("Review1");
					this.OnReview1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StarRating", DbType="Int NOT NULL")]
		public int StarRating
		{
			get
			{
				return this._StarRating;
			}
			set
			{
				if ((this._StarRating != value))
				{
					this.OnStarRatingChanging(value);
					this.SendPropertyChanging();
					this._StarRating = value;
					this.SendPropertyChanged("StarRating");
					this.OnStarRatingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LengthOfUse", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string LengthOfUse
		{
			get
			{
				return this._LengthOfUse;
			}
			set
			{
				if ((this._LengthOfUse != value))
				{
					this.OnLengthOfUseChanging(value);
					this.SendPropertyChanging();
					this._LengthOfUse = value;
					this.SendPropertyChanged("LengthOfUse");
					this.OnLengthOfUseChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_s", DbType="DateTime NOT NULL")]
		public System.DateTime DatePosted
		{
			get
			{
				return this._s;
			}
			set
			{
				if ((this._s != value))
				{
					this.OnDatePostedChanging(value);
					this.SendPropertyChanging();
					this._s = value;
					this.SendPropertyChanged("DatePosted");
					this.OnDatePostedChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Products")]
	public partial class Product : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ProductId;
		
		private string _Brand;
		
		private string _Category;
		
		private string _Description;
		
		private string _Image;
		
		private string _SubCategory;
		
		private string _SiteUrl;
		
		private string _Title;
		
		private decimal _MSRP;
		
		private bool _Approved;
		
		private string _SubmittedBy;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnProductIdChanging(int value);
    partial void OnProductIdChanged();
    partial void OnBrandChanging(string value);
    partial void OnBrandChanged();
    partial void OnCategoryChanging(string value);
    partial void OnCategoryChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnImageChanging(string value);
    partial void OnImageChanged();
    partial void OnSubCategoryChanging(string value);
    partial void OnSubCategoryChanged();
    partial void OnSiteUrlChanging(string value);
    partial void OnSiteUrlChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnMSRPChanging(decimal value);
    partial void OnMSRPChanged();
    partial void OnApprovedChanging(bool value);
    partial void OnApprovedChanged();
    partial void OnSubmittedByChanging(string value);
    partial void OnSubmittedByChanged();
    #endregion
		
		public Product()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ProductId
		{
			get
			{
				return this._ProductId;
			}
			set
			{
				if ((this._ProductId != value))
				{
					this.OnProductIdChanging(value);
					this.SendPropertyChanging();
					this._ProductId = value;
					this.SendPropertyChanged("ProductId");
					this.OnProductIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Brand", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Brand
		{
			get
			{
				return this._Brand;
			}
			set
			{
				if ((this._Brand != value))
				{
					this.OnBrandChanging(value);
					this.SendPropertyChanging();
					this._Brand = value;
					this.SendPropertyChanged("Brand");
					this.OnBrandChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Category", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Category
		{
			get
			{
				return this._Category;
			}
			set
			{
				if ((this._Category != value))
				{
					this.OnCategoryChanging(value);
					this.SendPropertyChanging();
					this._Category = value;
					this.SendPropertyChanged("Category");
					this.OnCategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Image", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				if ((this._Image != value))
				{
					this.OnImageChanging(value);
					this.SendPropertyChanging();
					this._Image = value;
					this.SendPropertyChanged("Image");
					this.OnImageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubCategory", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string SubCategory
		{
			get
			{
				return this._SubCategory;
			}
			set
			{
				if ((this._SubCategory != value))
				{
					this.OnSubCategoryChanging(value);
					this.SendPropertyChanging();
					this._SubCategory = value;
					this.SendPropertyChanged("SubCategory");
					this.OnSubCategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SiteUrl", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string SiteUrl
		{
			get
			{
				return this._SiteUrl;
			}
			set
			{
				if ((this._SiteUrl != value))
				{
					this.OnSiteUrlChanging(value);
					this.SendPropertyChanging();
					this._SiteUrl = value;
					this.SendPropertyChanged("SiteUrl");
					this.OnSiteUrlChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MSRP", DbType="Decimal(8,2) NOT NULL")]
		public decimal MSRP
		{
			get
			{
				return this._MSRP;
			}
			set
			{
				if ((this._MSRP != value))
				{
					this.OnMSRPChanging(value);
					this.SendPropertyChanging();
					this._MSRP = value;
					this.SendPropertyChanged("MSRP");
					this.OnMSRPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Approved", DbType="Bit NOT NULL")]
		public bool Approved
		{
			get
			{
				return this._Approved;
			}
			set
			{
				if ((this._Approved != value))
				{
					this.OnApprovedChanging(value);
					this.SendPropertyChanging();
					this._Approved = value;
					this.SendPropertyChanged("Approved");
					this.OnApprovedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubmittedBy", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string SubmittedBy
		{
			get
			{
				return this._SubmittedBy;
			}
			set
			{
				if ((this._SubmittedBy != value))
				{
					this.OnSubmittedByChanging(value);
					this.SendPropertyChanging();
					this._SubmittedBy = value;
					this.SendPropertyChanged("SubmittedBy");
					this.OnSubmittedByChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
