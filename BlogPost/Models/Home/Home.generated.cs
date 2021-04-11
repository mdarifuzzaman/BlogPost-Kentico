﻿//--------------------------------------------------------------------------------------------------
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

[assembly: RegisterDocumentType(Home.CLASS_NAME, typeof(Home))]

namespace CMS.DocumentEngine.Types.HouseRestaurant
{
	/// <summary>
	/// Represents a content item of type Home.
	/// </summary>
	public partial class Home : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "HouseRestaurant.Home";
		public const string NodeGuidId = "0a111c6d-b3e1-4a67-b920-0a2fd4de6afe";
		public const string PageGuidId = "54ecf1f4-133b-4a05-a091-9cc941809ce8";
		public const int PageId = 99;

		/// <summary>
		/// The instance of the class that provides extended API for working with Home fields.
		/// </summary>
		private readonly HomeFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// HomeID.
		/// </summary>
		[DatabaseIDField]
		public int HomeID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("HomeID"), 0);
			}
			set
			{
				SetValue("HomeID", value);
			}
		}


		/// <summary>
		/// Title.
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
		/// Description.
		/// </summary>
		[DatabaseField]
		public string Description
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Description"), @"");
			}
			set
			{
				SetValue("Description", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with Home fields.
		/// </summary>
		[RegisterProperty]
		public HomeFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with Home fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class HomeFields : AbstractHierarchicalObject<HomeFields>
		{
			/// <summary>
			/// The content item of type Home that is a target of the extended API.
			/// </summary>
			private readonly Home mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="HomeFields" /> class with the specified content item of type Home.
			/// </summary>
			/// <param name="instance">The content item of type Home that is a target of the extended API.</param>
			public HomeFields(Home instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// HomeID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.HomeID;
				}
				set
				{
					mInstance.HomeID = value;
				}
			}


			/// <summary>
			/// Title.
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
			/// Description.
			/// </summary>
			public string Description
			{
				get
				{
					return mInstance.Description;
				}
				set
				{
					mInstance.Description = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="Home" /> class.
		/// </summary>
		public Home() : base(CLASS_NAME)
		{
			mFields = new HomeFields(this);
		}

		#endregion
	}
}