//--------------------------------------------------------------------------------------------------
// <auto-generated>
//
//     This code was generated by code generator tool.
//
//     To customize the code use your own partial class. For more info about how to use and customize
//     the generated code see the documentation at https://docs.xperience.io/.
//
// </auto-generated>
//--------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using CMS;
using CMS.Base;
using CMS.Helpers;
using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.HouseRestaurant;

[assembly: RegisterDocumentType(Dish.CLASS_NAME, typeof(Dish))]

namespace CMS.DocumentEngine.Types.HouseRestaurant
{
	/// <summary>
	/// Represents a content item of type Dish.
	/// </summary>
	public partial class Dish : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "HouseRestaurant.Dish";


		/// <summary>
		/// The instance of the class that provides extended API for working with Dish fields.
		/// </summary>
		private readonly DishFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// DishID.
		/// </summary>
		[DatabaseIDField]
		public int DishID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("DishID"), 0);
			}
			set
			{
				SetValue("DishID", value);
			}
		}


		/// <summary>
		/// Dish Title.
		/// </summary>
		[DatabaseField]
		public string Title
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Title"), @"");
			}
			set
			{
				SetValue("Title", value);
			}
		}


		/// <summary>
		/// Dish Summary.
		/// </summary>
		[DatabaseField]
		public string Summary
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Summary"), @"");
			}
			set
			{
				SetValue("Summary", value);
			}
		}


		/// <summary>
		/// Media selection.
		/// </summary>
		[DatabaseField]
		public string Image
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Image"), @"");
			}
			set
			{
				SetValue("Image", value);
			}
		}


		/// <summary>
		/// Price Original.
		/// </summary>
		[DatabaseField]
		public decimal OriginalPrice
		{
			get
			{
				return ValidationHelper.GetDecimal(GetValue("OriginalPrice"), 0);
			}
			set
			{
				SetValue("OriginalPrice", value);
			}
		}


		/// <summary>
		/// Discount.
		/// </summary>
		[DatabaseField]
		public decimal Discount
		{
			get
			{
				return ValidationHelper.GetDecimal(GetValue("Discount"), ValidationHelper.GetDecimal("0.0", 0));
			}
			set
			{
				SetValue("Discount", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with Dish fields.
		/// </summary>
		[RegisterProperty]
		public DishFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with Dish fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class DishFields : AbstractHierarchicalObject<DishFields>
		{
			/// <summary>
			/// The content item of type Dish that is a target of the extended API.
			/// </summary>
			private readonly Dish mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="DishFields" /> class with the specified content item of type Dish.
			/// </summary>
			/// <param name="instance">The content item of type Dish that is a target of the extended API.</param>
			public DishFields(Dish instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// DishID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.DishID;
				}
				set
				{
					mInstance.DishID = value;
				}
			}


			/// <summary>
			/// Dish Title.
			/// </summary>
			public string Title
			{
				get
				{
					return mInstance.Title;
				}
				set
				{
					mInstance.Title = value;
				}
			}


			/// <summary>
			/// Dish Summary.
			/// </summary>
			public string Summary
			{
				get
				{
					return mInstance.Summary;
				}
				set
				{
					mInstance.Summary = value;
				}
			}


			/// <summary>
			/// Media selection.
			/// </summary>
			public string Image
			{
				get
				{
					return mInstance.Image;
				}
				set
				{
					mInstance.Image = value;
				}
			}


			/// <summary>
			/// Price Original.
			/// </summary>
			public decimal OriginalPrice
			{
				get
				{
					return mInstance.OriginalPrice;
				}
				set
				{
					mInstance.OriginalPrice = value;
				}
			}


			/// <summary>
			/// Discount.
			/// </summary>
			public decimal Discount
			{
				get
				{
					return mInstance.Discount;
				}
				set
				{
					mInstance.Discount = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="Dish" /> class.
		/// </summary>
		public Dish() : base(CLASS_NAME)
		{
			mFields = new DishFields(this);
		}

		#endregion
	}
}