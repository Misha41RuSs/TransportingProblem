using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<int> supply;
        private List<int> demand;
        private int[,] cost;

        public Form1()
        {
            InitializeComponent();

            // Initialize supply, demand, and cost
            supply = new List<int> { 51, 37, 84, 58, 145 };
            demand = new List<int> { 71, 87, 75, 85, 57 };
            cost = new int[,]
            {
                {3, 6, 4, 6, 4},
                {1, 1, 5, 3, 5},
                {3, 2, 8, 8, 1},
                {8, 2, 1, 3, 6},
                {5, 4, 3, 3, 3}
            };

            // Check and balance supply and demand
            Matrix.CheckAndBalance(ref supply, ref demand, ref cost);

            // Initialize DataGridViews after supply and demand are set
            InitializeDataGridView();

            // Set button texts
            buttonNW.Text = "Метод Северо-западного угла";
            buttonMinEL.Text = "Метод минимального элемента";
            buttonPotents.Text = "Метод потенциалов";
        }

        private void InitializeDataGridView()
        {
            int numRows = supply.Count;
            int numCols = demand.Count;

            // Initialize dataGridForResults (using dataGridForMinEL as the main grid)
            dataGridForMinEL.ColumnCount = numCols;
            dataGridForMinEL.ColumnHeadersVisible = true;
            dataGridForMinEL.RowHeadersVisible = true;
            for (int j = 0; j < numCols; j++)
            {
                dataGridForMinEL.Columns[j].Name = $"";
                dataGridForMinEL.Columns[j].HeaderText = $"b{j + 1}";
            }
            dataGridForMinEL.RowCount = numRows;
            for (int i = 0; i < numRows; i++)
            {
                dataGridForMinEL.Rows[i].HeaderCell.Value = $"a{i + 1}";
            }
        }

        private void buttonNW_Click(object sender, EventArgs e)
        {
            dataGridForMinEL.Rows.Clear();
            dataGridForMinEL.Columns.Clear();
            dataGridForMinEL.ColumnHeadersVisible = true;
            dataGridForMinEL.RowHeadersVisible = true;
            Matrix C = new Matrix(supply.Count, demand.Count, supply, demand, cost);
            C.NorthwestCorner();
            for (int j = 0; j < demand.Count; j++)
            {
                dataGridForMinEL.Columns.Add("", $"b{j + 1}");
                dataGridForMinEL.Columns[j].Name = $"";
            }
            for (int i = 0; i < supply.Count; i++)
            {
                dataGridForMinEL.Rows.Add();
                dataGridForMinEL.Rows[i].HeaderCell.Value = $"a{i + 1}";
            }
            C.PrintMatrix(dataGridForMinEL, new List<int>(), new List<int>());
            C.TargetFunc(textBoxForF);
        }

        private void buttonMinEL_Click(object sender, EventArgs e)
        {
            dataGridForMinEL.Rows.Clear();
            dataGridForMinEL.Columns.Clear();
            dataGridForMinEL.ColumnHeadersVisible = true;
            dataGridForMinEL.RowHeadersVisible = true;
            Matrix C = new Matrix(supply.Count, demand.Count, supply, demand, cost);
            C.MinimumCost();
            for (int j = 0; j < demand.Count; j++)
            {
                dataGridForMinEL.Columns.Add("", $"b{j + 1}");
                dataGridForMinEL.Columns[j].Name = $"";
            }
            for (int i = 0; i < supply.Count; i++)
            {
                dataGridForMinEL.Rows.Add();
                dataGridForMinEL.Rows[i].HeaderCell.Value = $"a{i + 1}";
            }
            C.PrintMatrix(dataGridForMinEL, new List<int>(), new List<int>());
            C.TargetFunc(textBoxForF);
        }

        private void buttonPotents_Click(object sender, EventArgs e)
        {
            dataGridForMinEL.Rows.Clear();
            dataGridForMinEL.Columns.Clear();
            Matrix C = new Matrix(supply.Count, demand.Count, supply, demand, cost);
            C.MinimumCost();
            C.Start(dataGridForMinEL, textBoxForF);

        }
    }
}