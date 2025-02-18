using System;
using System.Drawing.Printing;

namespace Programming_03_Assignment
{
    /// <summary>
    /// Provides functionality to print a DataGridView with dynamic font scaling/column adjustments.
    /// Intialises a new instance of the <see cref="DataGridPrinter"/> class.
    /// </summary>
    /// <param name="dataGridView">The DataGridView to print.</param>
    public class DataGridPrinter(DataGridView dataGridView)
    {
        private readonly DataGridView _dataGridView = dataGridView ?? throw new ArgumentNullException(nameof(dataGridView));

        /// <summary>
        /// Prints the DataGridView content on a print page.
        /// </summary>
        /// <param name="e">The PrintPageEventArgs containing the graphics and margin information.</param>
        public void PrintGridView(PrintPageEventArgs e)
        {
            ArgumentNullException.ThrowIfNull(e.Graphics, nameof(e.Graphics));

            // Intialises fonts.
            Font headerFont = new("Arial", 12, FontStyle.Bold);
            Font rowFont = new("Arial", 8);

            StringFormat format = new()
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near,
                FormatFlags = StringFormatFlags.LineLimit,
                Trimming = StringTrimming.Character
            };

            // Determine font sizes/column widths.
            (headerFont, rowFont, float[] columnWidths) = TryIncreaseFontSizes(e.Graphics, e.MarginBounds.Width, headerFont, rowFont);

            _ = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;

            // Calculate header height.
            float headerHeight = 0;
            for (int i = 0; i < _dataGridView.Columns.Count; i++)
            {
                string headerText = _dataGridView.Columns[i].HeaderText;
                SizeF headerSize = e.Graphics.MeasureString(headerText, headerFont, (int)columnWidths[i], format);
                headerHeight = Math.Max(headerHeight, headerSize.Height);
            }

            // Print the headers.
            float x = e.MarginBounds.Left;
            for (int i = 0; i < _dataGridView.Columns.Count; i++)
            {
                string headerText = _dataGridView.Columns[i].HeaderText;
                Font fittedHeaderFont = GetFittedFont(e.Graphics, headerText, headerFont, columnWidths[i], headerHeight, format);
                DrawCell(e.Graphics, headerText, fittedHeaderFont, x, y, columnWidths[i], headerHeight, true, format);
                x += columnWidths[i];
            }

            y += headerHeight;
            _ = e.MarginBounds.Left;

            // Print the rows.
            foreach (DataGridViewRow row in _dataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    float rowHeight = 0;

                    for (int i = 0; i < _dataGridView.Columns.Count; i++)
                    {
                        string cellValue = row.Cells[i].Value?.ToString() ?? string.Empty;
                        SizeF requiredSize = e.Graphics.MeasureString(cellValue, rowFont, (int)columnWidths[i], format);
                        rowHeight = Math.Max(rowHeight, requiredSize.Height);
                    }

                    // Draw the cells using fitted fonts.
                    float currentX = e.MarginBounds.Left;
                    for (int i = 0; i < _dataGridView.Columns.Count; i++)
                    {
                        string cellValue = row.Cells[i].Value?.ToString() ?? string.Empty;
                        Font fittedRowFont = GetFittedFont(e.Graphics, cellValue, rowFont, columnWidths[i], rowHeight, format);
                        DrawCell(e.Graphics, cellValue, fittedRowFont, currentX, y, columnWidths[i], rowHeight, false, format);
                        currentX += columnWidths[i];
                    }

                    y += rowHeight;

                    // Check for page overflow.
                    if (y > e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                }
            }
            e.HasMorePages = false;
        }

        /// <summary>
        /// Measures the optimal widths for all columns.
        /// </summary>
        /// <param name="graphics">Abstracts different display/resolutions to draw.</param>
        /// <param name="headerFont">The font of the headers.</param>
        /// <param name="rowFont">The font of the row content.</param>
        /// <returns>Returns the measured width for all columns.</returns>
        private float[] MeasureColumnWidths(Graphics graphics, Font headerFont, Font rowFont)
        {
            int columnCount = _dataGridView.Columns.Count;
            float[] columnWidths = new float[columnCount];

            for (int i = 0; i < columnCount; i++)
            {
                var column = _dataGridView.Columns[i];

                // Measure header width.
                float headerWidth = graphics.MeasureString(column.HeaderText, headerFont).Width;

                // Measure max cell width for this column.
                float maxCellWidth = 0;
                foreach (DataGridViewRow row in _dataGridView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var cell = row.Cells[i];
                        string cellValue = cell.Value?.ToString() ?? string.Empty;
                        float cellWidth = graphics.MeasureString(cellValue, rowFont).Width;
                        maxCellWidth = Math.Max(maxCellWidth, cellWidth);
                    }
                }

                columnWidths[i] = Math.Max(headerWidth, maxCellWidth);
            }

            return columnWidths;
        }

        /// <summary>
        /// Scales column widths proportionally to fit possible width.
        /// </summary>
        /// <param name="columnWidths">The width of columns.</param>
        /// <param name="availableWidth">The available width for columns.</param>
        private static void ScaleColumnWidths(float[] columnWidths, float availableWidth)
        {
            float totalWidth = columnWidths.Sum();

            if (totalWidth > 0 && totalWidth != availableWidth)
            {
                float scaleFactor = availableWidth / totalWidth;
                for (int i = 0; i < columnWidths.Length; i++)
                {
                    columnWidths[i] *= scaleFactor;
                }
            }
        }

        /// <summary>
        /// Draws a single cell on the graphics object.
        /// </summary>
        /// <param name="graphics">Abstracts different display/resolutions to draw.</param>
        /// <param name="text">The text to be drawn.</param>
        /// <param name="font">The font of the content.</param>
        /// <param name="x">The x axis.</param>
        /// <param name="y">The y axis.</param>
        /// <param name="width">The width of the drawn cells.</param>
        /// <param name="height">The height of the drawn cells.</param>
        /// <param name="isHeader"><c>true</c> if header; otherwise <c>false</c>.</param>
        /// <param name="format">The format of the drawn cells.</param>
        private static void DrawCell(Graphics graphics, string text, Font font, float x, float y, float width, float height, bool isHeader, StringFormat format)
        {
            if (isHeader)
            {
                graphics.FillRectangle(Brushes.LightGray, x, y, width, height);
                graphics.DrawRectangle(Pens.Black, x, y, width, height);
            }

            graphics.DrawString(text, font, Brushes.Black, new RectangleF(x, y, width, height), format);

            if (!isHeader)
            {
                graphics.DrawRectangle(Pens.Black, x, y, width, height);
            }
        }

        /// <summary>
        /// Fits font to available width by re-sizing content.
        /// </summary>
        /// <param name="graphics">Abstracts different display/resolutions to draw.</param>
        /// <param name="text">The text to be drawn.</param>
        /// <param name="baseFont">The initial font type.</param>
        /// <param name="maxWidth">The maximum width.</param>
        /// <param name="maxHeight">The maximum height.</param>
        /// <param name="format">The format of the fitted font.</param>
        /// <returns>Returns the minimal possible font size.</returns>
        private static Font GetFittedFont(Graphics graphics, string text, Font baseFont, float maxWidth, float maxHeight, StringFormat format)
        {
            float fontSize = baseFont.Size;
            float minFontSize = 0.5f;
            Font testFont = baseFont;

            while (fontSize >= minFontSize)
            {
                SizeF size = graphics.MeasureString(text, testFont, (int)maxWidth, format);
                if (size.Width <= maxWidth && size.Height <= maxHeight)
                {
                    return new Font(baseFont.FontFamily, fontSize, baseFont.Style);
                }

                // Reduce the font size and try again.
                fontSize -= 0.5f;
                testFont = new Font(baseFont.FontFamily, fontSize, baseFont.Style);
            }

            // If no fit was found, return the smallest font.
            return new Font(baseFont.FontFamily, minFontSize, baseFont.Style);
        }

        /// <summary>
        /// Dynamically adjusts font sizes to maximize readability.
        /// </summary>
        /// <param name="graphics">Abstracts different display/resolutions to draw.</param>
        /// <param name="availableWidth">The available width.</param>
        /// <param name="headerFont">The header font.</param>
        /// <param name="rowFont">The row font.</param>
        /// <returns>Returns font scaled to available size depending on available space.</returns>
        private (Font headerFont, Font rowFont, float[] columnWidths) TryIncreaseFontSizes(
        Graphics graphics, float availableWidth, Font headerFont, Font rowFont)
        {
            float increment = 1f;
            bool canIncrease = true;

            // Measure initial natural widths.
            float[] columnWidths = MeasureColumnWidths(graphics, headerFont, rowFont);
            _ = columnWidths.Sum();

            // While increase is true, enlarge.
            while (canIncrease)
            {
                // Check if size can increase and still fit.
                float newHeaderSize = headerFont.Size + increment;
                float newRowSize = rowFont.Size + increment;

                Font testHeaderFont = new(headerFont.FontFamily, newHeaderSize, headerFont.Style);
                Font testRowFont = new(rowFont.FontFamily, newRowSize, rowFont.Style);

                float[] testWidths = MeasureColumnWidths(graphics, testHeaderFont, testRowFont);
                float testTotalWidth = testWidths.Sum();

                // If increasing still fits.
                if (testTotalWidth <= availableWidth)
                {
                    // Accept new fonts.
                    headerFont = testHeaderFont;
                    rowFont = testRowFont;
                    columnWidths = testWidths;
                }
                else
                {
                    // Can't fit, stop increasing.
                    canIncrease = false;
                }
            }

            ScaleColumnWidths(columnWidths, availableWidth);

            return (headerFont, rowFont, columnWidths);
        }
    }
}