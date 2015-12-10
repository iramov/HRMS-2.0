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

[assembly: RegisterDocumentType(Projects.CLASS_NAME, typeof(Projects))]

namespace CMS.DocumentEngine.Types
{
    /// <summary>
    /// Represents a content item of type Projects.
    /// </summary>
    public partial class Projects : TreeNode
    {
        #region "Constants and variables"

        /// <summary>
        /// The name of the data class.
        /// </summary>
        public const string CLASS_NAME = "HRMS.Projects";


        /// <summary>
        /// The instance of the class that provides extended API for working with Projects fields.
        /// </summary>
        private readonly ProjectsFields mFields;

        #endregion


        #region "Properties"

        /// <summary>
        /// ProjectsID.
        /// </summary>
        [DatabaseIDField]
        public int ProjectsID
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("ProjectsID"), 0);
            }
            set
            {
                SetValue("ProjectsID", value);
            }
        }


        /// <summary>
        /// Projects name.
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
        /// Description.
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
        /// Gets an object that provides extended API for working with Projects fields.
        /// </summary>
        public ProjectsFields Fields
        {
            get
            {
                return mFields;
            }
        }


        /// <summary>
        /// Provides extended API for working with Projects fields.
        /// </summary>
        public partial class ProjectsFields
        {
            /// <summary>
            /// The content item of type Projects that is a target of the extended API.
            /// </summary>
            private readonly Projects mInstance;


            /// <summary>
            /// Initializes a new instance of the <see cref="ProjectsFields" /> class with the specified content item of type Projects.
            /// </summary>
            /// <param name="instance">The content item of type Projects that is a target of the extended API.</param>
            public ProjectsFields(Projects instance)
            {
                mInstance = instance;
            }


            /// <summary>
            /// ProjectsID.
            /// </summary>
            public int ID
            {
                get
                {
                    return mInstance.ProjectsID;
                }
                set
                {
                    mInstance.ProjectsID = value;
                }
            }


            /// <summary>
            /// Projects name.
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
        /// Initializes a new instance of the <see cref="Projects" /> class.
        /// </summary>
        public Projects() : base(CLASS_NAME)
        {
            mFields = new ProjectsFields(this);
        }

        #endregion
    }
}