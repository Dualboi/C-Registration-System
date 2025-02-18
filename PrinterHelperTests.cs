using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using Programming_03_Assignment;
using System.Reflection.Metadata;

namespace Project_Testing
{
    public class PrinterHelperTester
    {
        /// <summary>
        /// Test Initialization of the DataGridPrinter
        /// <returns>
        /// No argument if true. If false 
        /// Constructor_ThrowsArgumentNullException_WhenDataGridViewIsNull
        /// </returns>
        [Fact]
        public void DataGridViewIsNullErrorTest()
        {
            ///  Act & Assert
            Assert.Throws<ArgumentNullException>(() => new DataGridPrinter(null));
        }

        /// <summary>
        /// Tests PrintGridView Handles Null Graphics.
        /// </summary>
        /// <returns>
        ///  No argument if true. If false ThrowsArgumentNullException_WhenGraphicsIsNull.
        /// </returns>
        [Fact]
        public void PrintGridViewTest()
        {
            /// Arrange: Creates a new DataGridView using the DataGridView class.
            var dataGridView = new DataGridView();
            var dataGridPrinter = new DataGridPrinter(dataGridView);
            /// Arrange: Initilises a new Null instance of the PrintPageEventArgs class with the args of Rectangle.
            var printEventArgs = new PrintPageEventArgs(null, new Rectangle(), new Rectangle(), null);

            /// Act & Assert: Checks that when null is passed as printEventArgs, 
            /// the PrintGridView method correctly throws an ArgumentNullException.
            Assert.Throws<ArgumentNullException>(() => dataGridPrinter.PrintGridView(printEventArgs));
        }

        /// <summary>
        /// Test Column Width Calculation using reflection as the method is private.
        /// </summary>
        [Fact]
        public void MeasureColumnWidthsTest()
        {
            /// Arrange: Initilises a new instance of DataGridView.
            var dataGridView = new DataGridView();
            /// Arrange: Adds a table with two columns two headers 
            /// and two cells to the new dataGridView instance.
            dataGridView.Columns.Add("Column1", "Header1");
            dataGridView.Columns.Add("Column2", "Header2");
            dataGridView.Rows.Add("Cell1", "Cell2");

            /// Arrange: A new var is made called graphics thats assigned 
            /// a graphical image 100x100 bits in size,
            /// To be later passed to the private MeasureColumnWidths method.
            using var graphics = Graphics.FromImage(new Bitmap(100, 100));
            /// Arrange: Var created called dataGridPrinter with the class 
            /// of DataGridPrinter and value assigned to the dataGridView. 
            var dataGridPrinter = new DataGridPrinter(dataGridView);

            /// Arrange: Use reflection to access the private MeasureColumnWidths method 
            /// to measure the column width of DataGridPrinter's value.
            var methodInfo = typeof(DataGridPrinter).GetMethod("MeasureColumnWidths",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            /// Act: Adds font information to a new var called columnWidths.
            var columnWidths = (float[])methodInfo.Invoke(dataGridPrinter, new object[]
            { graphics, new Font("Arial", 12), new Font("Arial", 8) });

            /// Assert: The var colmnWidths is not Null.
            Assert.NotEmpty(columnWidths);
            /// Assert: columnWidths is equal to 2 in column value.
            Assert.Equal(2, columnWidths.Length);
            /// Assert: Verify that widths are calculated.
            Assert.True(columnWidths[0] > 0);
            Assert.True(columnWidths[1] > 0);
        }

        /// <summary>
        /// Tests Scaling of Column Widths using reflection as the method is private.
        /// </summary>
        [Fact]
        public void ScaleColumnWidthsTest()
        {
            /// Arrange: Initilises a new instance of DataGridView.
            var dataGridView = new DataGridView();
            /// Arrange: Adds a table with two columns two headers and two cells to the new dataGridView instance.
            dataGridView.Columns.Add("Column1", "Header1");
            dataGridView.Columns.Add("Column2", "Header2");
            dataGridView.Rows.Add("Cell1", "Cell2");

            /// Arrange: A new var is made called graphics thats assigned a graphical image 100x100 bits in size,
            /// To be later passed to the private ScaleColumnWidths method.
            using var graphics = Graphics.FromImage(new Bitmap(100, 100));
            var dataGridPrinter = new DataGridPrinter(dataGridView);

            /// Use reflection to access the private ScaleColumnWidths method to scale the column width 
            /// of DataGridPrinter's value.
            var methodInfo = typeof(DataGridPrinter).GetMethod("ScaleColumnWidths",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            /// Arrange: Initial column widths (without scaling)
            var initialColumnWidths = new float[] { 200f, 150f };  /// Example widths.
            var availableWidth = 300f;  /// Total available width to scale columns to.

            /// Act: Invoke the ScaleColumnWidths method with the initial column widths and available width.
            methodInfo.Invoke(null, new object[] { initialColumnWidths, availableWidth });

            /// Assert:  After scaling, the total width should equal the available width
            var totalWidthAfterScaling = initialColumnWidths.Sum();
            Assert.Equal(availableWidth, totalWidthAfterScaling, 1); /// Allowing for minor floating-point errors

            /// Assert: Verify that the individual column widths have been adjusted
            Assert.True(initialColumnWidths[0] > 0);
            Assert.True(initialColumnWidths[1] > 0);
            Assert.True(initialColumnWidths[0] + initialColumnWidths[1] <= availableWidth);
        }


        /// <summary>
        /// Integration Test: Printing.
        /// </summary>
        /// by testing that PrintGridView is Printing Data Correctly.
        [Fact]
        public void PrintGridViewTest_UsingBitmap()
        {
            /// Arrange: Initilises a new instance of DataGridView.
            var dataGridView = new DataGridView();
            /// Arrange: Adds a table with two columns two headers and two cells to the new dataGridView instance.
            dataGridView.Columns.Add("Column1", "Header1");
            dataGridView.Columns.Add("Column2", "Header2");
            dataGridView.Rows.Add("Row1Cell1", "Row1Cell2");

            /// Arrange: Initilises a new Null instance of the PrintPageEventArgs class with the args of Rectangle.
            /// This allows the data from dataGridVew to be outputted onto the null page
            using var bitmap = new Bitmap(800, 600);
            using var graphics = Graphics.FromImage(bitmap);
            var printEventArgs = new PrintPageEventArgs(graphics, new Rectangle(0, 0, 800, 600),
                new Rectangle(0, 0, 800, 600), null);
            var dataGridPrinter = new DataGridPrinter(dataGridView);

            /// Act: Calls the PrintGridView method to print the data of printEventArgs.
            dataGridPrinter.PrintGridView(printEventArgs);

            /// Assert: Since Graphics doesn't directly allow asserting the output, ensure no exceptions occurred
            Assert.False(printEventArgs.HasMorePages);
        }

    }
}
