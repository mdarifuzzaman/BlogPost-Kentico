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

[assembly: RegisterDocumentType(MenuFolder.CLASS_NAME, typeof(MenuFolder))]

namespace CMS.DocumentEngine.Types.HouseRestaurant
{
	/// <summary>
	/// Represents a content item of type MenuFolder.
	/// </summary>
	public partial class MenuFolder : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "HouseRestaurant.MenuFolder";


		/// <summary>
		/// The instance of the class that provides extended API for working with MenuFolder fields.
		/// </summary>
		private readonly MenuFolderFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// MenuFolderID.
		/// </summary>
		[DatabaseIDField]
		public int MenuFolderID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("MenuFolderID"), 0);
			}
			set
			{
				SetValue("MenuFolderID", value);
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
		/// Gets an object that provides extended API for working with MenuFolder fields.
		/// </summary>
		[RegisterProperty]
		public MenuFolderFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with MenuFolder fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class MenuFolderFields : AbstractHierarchicalObject<MenuFolderFields>
		{
			/// <summary>
			/// The content item of type MenuFolder that is a target of the extended API.
			/// </summary>
			private readonly MenuFolder mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="MenuFolderFields" /> class with the specified content item of type MenuFolder.
			/// </summary>
			/// <param name="instance">The content item of type MenuFolder that is a target of the extended API.</param>
			public MenuFolderFields(MenuFolder instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// MenuFolderID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.MenuFolderID;
				}
				set
				{
					mInstance.MenuFolderID = value;
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
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="MenuFolder" /> class.
		/// </summary>
		public MenuFolder() : base(CLASS_NAME)
		{
			mFields = new MenuFolderFields(this);
		}

		#endregion
	}
}