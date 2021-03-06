//--------------------------------------------------------------------------------------------------
// <auto-generated>
//
//     This code was generated by code generator tool.
//
//     To customize the code use your own partial class. For more info about how to use and customize
//     the generated code see the documentation at http://docs.kentico.com.
//
// </auto-generated>
//--------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using CMS;
using CMS.Helpers;
using CMS.DataEngine;
using CMS.DocumentEngine.Types;
using CMS.DocumentEngine;

[assembly: RegisterDocumentType(Team.CLASS_NAME, typeof(Team))]

namespace CMS.DocumentEngine.Types
{
	/// <summary>
	/// Represents a content item of type Team.
	/// </summary>
	public partial class Team : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "HRMS.Team";


		/// <summary>
		/// The instance of the class that provides extended API for working with Team fields.
		/// </summary>
		private readonly TeamFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// TeamID.
		/// </summary>
		[DatabaseIDField]
		public int TeamID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("TeamID"), 0);
			}
			set
			{
				SetValue("TeamID", value);
			}
		}


		/// <summary>
		/// Name of the team.
		/// </summary>
		[DatabaseField]
		public string TeamName
		{
			get
			{
				return ValidationHelper.GetString(GetValue("TeamName"), "");
			}
			set
			{
				SetValue("TeamName", value);
			}
		}


		/// <summary>
		/// Team delivery.
		/// </summary>
		[DatabaseField]
		public string Delivery
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Delivery"), "");
			}
			set
			{
				SetValue("Delivery", value);
			}
		}


		/// <summary>
		/// Available positions.
		/// </summary>
		[DatabaseField]
		public string AvailablePositions
		{
			get
			{
				return ValidationHelper.GetString(GetValue("AvailablePositions"), "");
			}
			set
			{
				SetValue("AvailablePositions", value);
			}
		}


		/// <summary>
		/// Team description.
		/// </summary>
		[DatabaseField]
		public string Description
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Description"), "");
			}
			set
			{
				SetValue("Description", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with Team fields.
		/// </summary>
		public TeamFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with Team fields.
		/// </summary>
		public partial class TeamFields
		{
			/// <summary>
			/// The content item of type Team that is a target of the extended API.
			/// </summary>
			private readonly Team mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="TeamFields" /> class with the specified content item of type Team.
			/// </summary>
			/// <param name="instance">The content item of type Team that is a target of the extended API.</param>
			public TeamFields(Team instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// TeamID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.TeamID;
				}
				set
				{
					mInstance.TeamID = value;
				}
			}


			/// <summary>
			/// Name of the team.
			/// </summary>
			public string Name
			{
				get
				{
					return mInstance.TeamName;
				}
				set
				{
					mInstance.TeamName = value;
				}
			}


			/// <summary>
			/// Team delivery.
			/// </summary>
			public string Delivery
			{
				get
				{
					return mInstance.Delivery;
				}
				set
				{
					mInstance.Delivery = value;
				}
			}


			/// <summary>
			/// Available positions.
			/// </summary>
			public string AvailablePositions
			{
				get
				{
					return mInstance.AvailablePositions;
				}
				set
				{
					mInstance.AvailablePositions = value;
				}
			}


			/// <summary>
			/// Team description.
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
		/// Initializes a new instance of the <see cref="Team" /> class.
		/// </summary>
		public Team() : base(CLASS_NAME)
		{
			mFields = new TeamFields(this);
		}

		#endregion
	}
}