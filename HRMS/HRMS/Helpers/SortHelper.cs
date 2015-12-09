using System.Collections.Generic;

namespace HRMS.Helpers
{
    public class SortHelper
    {
        public static void SortByColumn(CMS.DocumentEngine.IDocumentQuery query, string sortOrder)
        {
            if (sortOrder.Contains("_desc"))
            {
                query.OrderByColumns = sortOrder.Replace("_desc", " DESC");
            }
            else
            {
                query.OrderByColumns = sortOrder;
            }
        }
        private static string DefaultSortOrder
        {
            get { return "NodeId"; }
        }
        private static void ValidateSortOrder(ref string sortOrder)
        {
            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = DefaultSortOrder;
            }
        }
        public static List<string> GetEmployeesSortViewBagFields(ref string sortOrder)
        {
            ValidateSortOrder(ref sortOrder);
            List<string> viewBagFields = new List<string>();
            string firstNameSortParam = sortOrder == "FirstName" ? "FirstName_desc" : "FirstName";
            string lastNameSortParam = sortOrder == "LastName" ? "LastName_desc" : "LastName";
            string positionSortParam = sortOrder == "Position" ? "Position_desc" : "Position";
            viewBagFields.Add(firstNameSortParam);
            viewBagFields.Add(lastNameSortParam);
            viewBagFields.Add(positionSortParam);
            return viewBagFields;
        }
        public static List<string> GetTeamsSortViewBagFields(ref string sortOrder)
        {
            ValidateSortOrder(ref sortOrder);
            List<string> viewBagFields = new List<string>();
            string nameSortParam = sortOrder == "TeamName" ? "TeamName_desc" : "TeamName";
            string deliverySortParam = sortOrder == "Delivery" ? "Delivery_desc" : "Delivery";
            viewBagFields.Add(nameSortParam);
            viewBagFields.Add(deliverySortParam);
            return viewBagFields;
        }
    }
}