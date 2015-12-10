using System;
using System.Collections.Generic;

namespace HRMS.Helpers
{
    public class SortHelper
    {
        private const string DEFAULT_SORT_ORDER = "NodeId";

        private static string ValidateSortOrder(string sortOrder)
        {
            return string.IsNullOrEmpty(sortOrder) ? DEFAULT_SORT_ORDER : sortOrder;
        }
        public static void SortByColumn(CMS.DocumentEngine.IDocumentQuery query, string sortOrder)
        {
            string order = ValidateSortOrder(sortOrder);
            if (order.Contains("_desc"))
            {
                query.OrderByColumns = order.Replace("_desc", " DESC");
            }
            else
            {
                query.OrderByColumns = order;
            }
        }
        public static List<string> GetEmployeesSortViewBagFields(string sortOrder)
        {
            List<string> viewBagFields = new List<string>();
            string firstNameSortParam = sortOrder == "FirstName" ? "FirstName_desc" : "FirstName";
            string lastNameSortParam = sortOrder == "LastName" ? "LastName_desc" : "LastName";
            string positionSortParam = sortOrder == "Position" ? "Position_desc" : "Position";
            viewBagFields.Add(firstNameSortParam);
            viewBagFields.Add(lastNameSortParam);
            viewBagFields.Add(positionSortParam);
            return viewBagFields;
        }

        public static List<string> GetProjectsSortViewBagFields(string sortOrder)
        {
            List<string> viewBagFields = new List<string>();
            string nameSortParam = sortOrder == "ProjectName" ? "ProjectName_desc" : "ProjectName";
            string deliverySortParam = sortOrder == "Delivery" ? "Delivery_desc" : "Delivery";
            viewBagFields.Add(nameSortParam);
            viewBagFields.Add(deliverySortParam);
            return viewBagFields;
        }

        public static List<string> GetTeamsSortViewBagFields(string sortOrder)
        {
            List<string> viewBagFields = new List<string>();
            string nameSortParam = sortOrder == "TeamName" ? "TeamName_desc" : "TeamName";
            string deliverySortParam = sortOrder == "Delivery" ? "Delivery_desc" : "Delivery";
            viewBagFields.Add(nameSortParam);
            viewBagFields.Add(deliverySortParam);
            return viewBagFields;
        }
    }
}