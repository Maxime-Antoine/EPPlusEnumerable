using System;

namespace EPPlusEnumerable
{
    /// <summary>
    /// Use this attribute to denote that cells in an exported Excel workbook should be linked
    /// to another location in the workbook.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class SpreadsheetLinkAttribute : Attribute
    {
        #region Properties

        public string WorksheetName { get; set; }

        public string ColumnHeaderValue { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Link the cell to the specified worksheet and column containing the same value (i.e.
        /// a "User" cell with a value of "John Smith" could link to a worksheet named "Users"
        /// with a column name of "Name" where the value is also "John Smith").
        /// </summary>
        /// <param name="worksheetName">The name of the worksheet to link to</param>
        /// <param name="columnHeaderValue">The column header of the column to link to (i.e. the value of the first row of the column).</param>
        public SpreadsheetLinkAttribute(string worksheetName, string columnHeaderValue)
        {
            WorksheetName = worksheetName;
            ColumnHeaderValue = columnHeaderValue;
        }

        #endregion
    }
}
