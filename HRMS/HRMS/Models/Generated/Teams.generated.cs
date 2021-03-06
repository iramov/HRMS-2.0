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

[assembly: RegisterDocumentType(Teams.CLASS_NAME, typeof(Teams))]

namespace CMS.DocumentEngine.Types
{
    /// <summary>
    /// Represents a content item of type Teams.
    /// </summary>
    public partial class Teams : TreeNode
    {
        #region "Constants and variables"

        /// <summary>
        /// The name of the data class.
        /// </summary>
        public const string CLASS_NAME = "HRMS.Teams";


        /// <summary>
        /// The instance of the class that provides extended API for working with Teams fields.
        /// </summary>
        private readonly TeamsFields mFields;

        #endregion


        #region "Properties"

        /// <summary>
        /// TeamsID.
        /// </summary>
        [DatabaseIDField]
        public int TeamsID
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("TeamsID"), 0);
            }
            set
            {
                SetValue("TeamsID", value);
            }
        }


        /// <summary>
        /// Section name.
        /// </summary>
        [DatabaseField]
        public string SectionName
        {
            get
            {
                return ValidationHelper.GetString(GetValue("SectionName"), "");
            }
            set
            {
                SetValue("SectionName", value);
            }
        }


        /// <summary>
        /// 
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
        /// Gets an object that provides extended API for working with Teams fields.
        /// </summary>
        public TeamsFields Fields
        {
            get
            {
                return mFields;
            }
        }


        /// <summary>
        /// Provides extended API for working with Teams fields.
        /// </summary>
        public partial class TeamsFields
        {
            /// <summary>
            /// The content item of type Teams that is a target of the extended API.
            /// </summary>
            private readonly Teams mInstance;


            /// <summary>
            /// Initializes a new instance of the <see cref="TeamsFields" /> class with the specified content item of type Teams.
            /// </summary>
            /// <param name="instance">The content item of type Teams that is a target of the extended API.</param>
            public TeamsFields(Teams instance)
            {
                mInstance = instance;
            }


            /// <summary>
            /// TeamsID.
            /// </summary>
            public int ID
            {
                get
                {
                    return mInstance.TeamsID;
                }
                set
                {
                    mInstance.TeamsID = value;
                }
            }


            /// <summary>
            /// Section name.
            /// </summary>
            public string SectionName
            {
                get
                {
                    return mInstance.SectionName;
                }
                set
                {
                    mInstance.SectionName = value;
                }
            }


            /// <summary>
            /// 
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
        /// Initializes a new instance of the <see cref="Teams" /> class.
        /// </summary>
        public Teams()
            : base(CLASS_NAME)
        {
            mFields = new TeamsFields(this);
        }

        #endregion
    }
}