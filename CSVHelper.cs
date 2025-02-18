using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_03_Assignment
{
    public class CSVHelper
    {
        /// <summary>
        /// Exports DataGridView to a CSV file.
        /// </summary>
        /// <param name="dataGridView">The DataGridView object.</param>
        /// <param name="filePath">The file path to export the data.</param>
        public static void ExportDataGridViewToCsv(DataGridView dataGridView, string filePath)
        {
            try
            {
                StringBuilder csvContent = new();

                // Add column headers.
                var columnNames = dataGridView.Columns.Cast<DataGridViewColumn>()
                    .Select(column => column.HeaderText);
                csvContent.AppendLine(string.Join(",", columnNames));

                // Add row data.
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var cellValues = row.Cells.Cast<DataGridViewCell>()
                            .Select(cell => cell.Value?.ToString() ?? string.Empty);
                        csvContent.AppendLine(string.Join(",", cellValues));
                    }
                }

                File.WriteAllText(filePath, csvContent.ToString());

                MessageBox.Show("Data exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while exporting the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
