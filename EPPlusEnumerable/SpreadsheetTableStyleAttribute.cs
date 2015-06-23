using OfficeOpenXml.Table;
using System;

namespace EPPlusEnumerable
{
    /// <summary>
    /// Use this attribute to denote the table style EPPlus should use on the worksheet.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class SpreadsheetTableStyleAttribute : Attribute
    {
        #region Properties

        public TableStyles TableStyle { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Apply the given TableStyles option to the worksheet for this collection type.
        /// </summary>
        /// <param name="tableStyle">The style to apply to the data on the worksheet for this type.</param>
        public SpreadsheetTableStyleAttribute(TableStyles tableStyle)
        {
            TableStyle = tableStyle;
        }

        #endregion
    }
}
