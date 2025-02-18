using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Programming_03_Assignment;
using Microsoft.Data.Sqlite;
using Xunit;
using Microsoft.VisualBasic;

namespace Project_Testing
{
    /// <summary>
    /// This file contains tests for the CSVHelper class and its method.
    /// </summary>
    public class CSVHelperTests
    {
        /// <summary>
        /// Tests the ExportDataGridViewToCsv method.
        /// </summary>
        [Fact]
        public void ExportDataGridViewToCsvTest()
        {
            /// Arrange: Creates a temporary file path for the export.
            string filePath = Path.GetTempFileName();

            /// Arrange: Creates a new DataGridView using the DataGridView class.
            var dataGridView = new DataGridView();

            /// Arrange: Adds a table with two columns two headers 
            /// and two cells to the new dataGridView instance.
            dataGridView.Columns.Add("Column1", "Header1");
            dataGridView.Columns.Add("Column2", "Header2");
            dataGridView.Rows.Add("Cell1", "Cell2");
            dataGridView.Rows.Add("Cell3", "Cell4");

            /// Act: Calls the PrintGridView method to print the data of printEventArgs.
            CSVHelper.ExportDataGridViewToCsv(dataGridView, filePath);

            var fileContent = File.ReadAllLines(filePath);

            /// Assert: Validate the file is created.
            Assert.True(File.Exists(filePath), "The CSV file should be created.");

            /// Assert: Validate the contents of the file.
            Assert.Equal("Header1,Header2", fileContent[0]); /// Column headers
            Assert.Equal("Cell1,Cell2", fileContent[1]);    /// First row
            Assert.Equal("Cell3,Cell4", fileContent[2]);    /// Second row

            /// Cleanup: Delete the temporary file.
            File.Delete(filePath);
        }
    }
}