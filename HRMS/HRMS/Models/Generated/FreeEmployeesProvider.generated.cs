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
using System.Data;

using CMS.Base;
using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.Helpers;

namespace CMS.DocumentEngine.Types
{
	/// <summary>
	/// Provides methods for retrieving pages of type FreeEmployees.
	/// </summary>
	public partial class FreeEmployeesProvider
	{
		/// <summary>
		/// Returns a query that selects published pages of type FreeEmployees.
		/// </summary>
		public static DocumentQuery<FreeEmployees> GetFreeEmployees()
		{
			return DocumentHelper.GetDocuments<FreeEmployees>().PublishedVersion().Published();
		}


		/// <summary>
		/// Returns a published page of type FreeEmployees that matches the specified criteria.
		/// </summary>
		/// <param name="nodeId">The identifier of the content tree node that represents the page.</param>
		/// <param name="siteName">The name of the site where the page belongs.</param>
		/// <param name="cultureName">The name of the language, e.g. en-US, that determines which localized version should be retrieved.</param>
		public static DocumentQuery<FreeEmployees> GetFreeEmployees(int nodeId, string cultureName, string siteName)
		{
			return GetFreeEmployees().OnSite(siteName).Culture(cultureName).WhereEquals("NodeID", nodeId);
		}


		/// <summary>
		/// Returns a published page of type FreeEmployees that matches the specified criteria.
		/// </summary>
		/// <param name="nodeGuid">The globally unique identifier of the content tree node that represents the page.</param>
		/// <param name="siteName">The name of the site where the page belongs.</param>
		/// <param name="cultureName">The name of the language, e.g. en-US, that determines which localized version should be retrieved.</param>
		public static DocumentQuery<FreeEmployees> GetFreeEmployees(Guid nodeGuid, string cultureName, string siteName)
		{
			return GetFreeEmployees().OnSite(siteName).Culture(cultureName).WhereEquals("NodeGUID", nodeGuid);
		}


		/// <summary>
		/// Returns a published page of type FreeEmployees that matches the specified criteria.
		/// </summary>
		/// <param name="nodeAliasPath">The alias path to the content tree node that represents the page.</param>
		/// <param name="siteName">The name of the site where the page belongs.</param>
		/// <param name="cultureName">The name of the language, e.g. en-US, that determines which localized version should be retrieved.</param>
		public static DocumentQuery<FreeEmployees> GetFreeEmployees(string nodeAliasPath, string cultureName, string siteName)
		{
			return GetFreeEmployees().OnSite(siteName).Culture(cultureName).Path(nodeAliasPath);
		}
	}
}