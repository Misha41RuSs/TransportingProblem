using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Matrix
    {
        private int sizeRow;
        private int sizeColumn;
        private int potentialI;
        private int potentialJ;
        private int func;
        private bool way = false;
        private char symbol = '-';
        private List<int> minVec = new List<int>();
        private int minimalElement;
        private int[,] matrix;
        private int[,] priceMatrix;
        private int[,] freeMatrix;
        private char[,] matrixPlusMinus;
        private List<int> resources;
        private List<int> consumers;

        public Matrix(int sizeRow, int sizeColumn, List<int> supply, List<int> demand, int[,] cost)
        {
            this.sizeRow = sizeRow;
            this.sizeColumn = sizeColumn;
            this.resources = supply;
            this.consumers = demand;
            this.priceMatrix = cost;
            this.matrix = new int[sizeRow, sizeColumn];
            this.freeMatrix = new int[sizeRow, sizeColumn];
            this.matrixPlusMinus = new char[sizeRow, sizeColumn];

            // Initialize matrixPlusMinus with '0'
            for (int i = 0; i < sizeRow; i++)
            {
                for (int j = 0; j < sizeColumn; j++)
                {
                    matrixPlusMinus[i, j] = '0';
                }
            }
        }

        public void MinimumCost()
        {
            List<int> tempResources = new List<int>(resources);
            List<int> tempConsumers = new List<int>(consumers);
            int[,] tempPriceMatrix = (int[,])priceMatrix.Clone();

            while (tempResources.Any(c => c > 0) && tempConsumers.Any(c => c > 0))
            {
                int minCost = int.MaxValue;
                int minI = -1, minJ = -1;

                for (int i = 0; i < sizeRow; i++)
                {
                    for (int j = 0; j < sizeColumn; j++)
                    {
                        if (tempResources[i] > 0 && tempConsumers[j] > 0 && tempPriceMatrix[i, j] < minCost)
                        {
                            minCost = tempPriceMatrix[i, j];
                            minI = i;
                            minJ = j;
                        }
                    }
                }

                if (minI == -1) break;

                int transfer = Math.Min(tempResources[minI], tempConsumers[minJ]);
                matrix[minI, minJ] = transfer;
                tempResources[minI] -= transfer;
                tempConsumers[minJ] -= transfer;

                if (tempResources[minI] == 0)
                {
                    for (int j = 0; j < sizeColumn; j++)
                    {
                        tempPriceMatrix[minI, j] = int.MaxValue;
                    }
                }

                if (tempConsumers[minJ] == 0)
                {
                    for (int i = 0; i < sizeRow; i++)
                    {
                        tempPriceMatrix[i, minJ] = int.MaxValue;
                    }
                }
            }
        }

        public void NorthwestCorner()
        {
            List<int> tempResources = new List<int>(resources);
            List<int> tempConsumers = new List<int>(consumers);
            int i = 0, j = 0;

            while (i < sizeRow && j < sizeColumn)
            {
                int transfer = Math.Min(tempResources[i], tempConsumers[j]);
                matrix[i, j] = transfer;
                tempResources[i] -= transfer;
                tempConsumers[j] -= transfer;

                if (tempResources[i] == 0)
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }
        }

        public void PrintMatrix(DataGridView dataGrid, List<int> uVec, List<int> vVec, bool printPotentials = false)
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
            dataGrid.RowHeadersVisible = false;

            // Initialize columns
            if (printPotentials)
            {
                dataGrid.Columns.Add("", ""); // First column for u potentials
                for (int j = 0; j < sizeColumn; j++)
                {
                    dataGrid.Columns.Add($"v{j + 1}", $"v{j + 1}");
                }
            }
            else
            {
                for (int j = 0; j < sizeColumn; j++)
                {
                    dataGrid.Columns.Add($"Col{j + 1}", $"Col{j + 1}");
                }
            }
            dataGrid.ColumnHeadersVisible = printPotentials;

            // Add rows
            if (printPotentials)
            {
                // Add the row for v potentials
                string[] vRow = new string[sizeColumn + 1];
                vRow[0] = "";
                for (int j = 0; j < sizeColumn; j++)
                {
                    vRow[j + 1] = vVec[j].ToString();
                }
                dataGrid.Rows.Add(vRow);
            }

            for (int i = 0; i < sizeRow; i++)
            {
                string[] row = new string[sizeColumn + (printPotentials ? 1 : 0)];
                if (printPotentials)
                {
                    row[0] = uVec[i].ToString();
                }
                for (int j = 0; j < sizeColumn; j++)
                {
                    row[printPotentials ? j + 1 : j] = matrix[i, j].ToString();
                }
                dataGrid.Rows.Add(row);
            }
            if (printPotentials)
            {
                dataGrid.Rows[0].HeaderCell.Value = "";
                for (int i = 0; i < sizeRow; i++)
                {
                    dataGrid.Rows[i + 1].HeaderCell.Value = $"u{i + 1}";
                }
                dataGrid.RowHeadersVisible = true;
            }

        }

        public void PrintPriceMatrix(DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();

            for (int i = 0; i < sizeRow; i++)
            {
                string[] row = new string[sizeColumn];
                for (int j = 0; j < sizeColumn; j++)
                {
                    row[j] = priceMatrix[i, j].ToString();
                }
                dataGrid.Rows.Add(row);
            }
        }

        public bool Potentials(ref List<int> uVec, ref List<int> vVec)
        {
            bool[] boolU = new bool[sizeRow];
            bool[] boolV = new bool[sizeColumn];

            uVec = new List<int>(new int[sizeRow]);
            vVec = new List<int>(new int[sizeColumn]);

            boolU[0] = true;

            bool updated = true;
            while (updated)
            {
                updated = false;
                for (int i = 0; i < sizeRow; i++)
                {
                    for (int j = 0; j < sizeColumn; j++)
                    {
                        if (matrix[i, j] != 0)
                        {
                            if (boolU[i] && !boolV[j])
                            {
                                vVec[j] = priceMatrix[i, j] - uVec[i];
                                boolV[j] = true;
                                updated = true;
                            }
                            else if (!boolU[i] && boolV[j])
                            {
                                uVec[i] = priceMatrix[i, j] - vVec[j];
                                boolU[i] = true;
                                updated = true;
                            }
                        }
                    }
                }
            }

            return Delta(uVec, vVec);
        }

        private bool Delta(List<int> uVec, List<int> vVec)
        {
            int negative = 0;
            for (int i = 0; i < sizeRow; i++)
            {
                for (int j = 0; j < sizeColumn; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        freeMatrix[i, j] = priceMatrix[i, j] - (uVec[i] + vVec[j]);
                        if (freeMatrix[i, j] < 0 && freeMatrix[i, j] < negative)
                        {
                            negative = freeMatrix[i, j];
                            potentialI = i;
                            potentialJ = j;
                        }
                    }
                }
            }
            return negative < 0;
        }

        public void TargetFunc(TextBox textBoxForF)
        {
            this.func = 0;
            for (int i = 0; i < sizeRow; i++)
            {
                for (int j = 0; j < sizeColumn; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        this.func += matrix[i, j] * priceMatrix[i, j];
                    }
                }
            }
            textBoxForF.Text = $"F = {this.func}";
        }

        public void MinFunc()
        {
            minVec.Clear();
            for (int i = 0; i < sizeRow; i++)
            {
                for (int j = 0; j < sizeColumn; j++)
                {
                    if (matrixPlusMinus[i, j] == '-')
                    {
                        minVec.Add(matrix[i, j]);
                    }
                }
            }
            if (minVec.Any())
            {
                minimalElement = minVec.Min();
                minVec.Clear();
            }
        }

        public void SearchLoop(int i, int j)
        {
            way = false;
            symbol = '-';
            for (int row = 0; row < sizeRow; row++)
            {
                for (int col = 0; col < sizeColumn; col++)
                {
                    matrixPlusMinus[row, col] = '0';
                }
            }
            matrixPlusMinus[i, j] = '+';
            if (j != 0 && !way)
            {
                GoLeft(i, j - 1);
            }
            if (j != sizeColumn - 1 && !way)
            {
                GoRight(i, j + 1);
            }
            if (i != 0 && !way)
            {
                GoUp(i - 1, j);
            }
            if (i != sizeRow - 1 && !way)
            {
                GoDown(i + 1, j);
            }
        }

        private void GoDown(int i, int j)
        {
            if (i == potentialI && j == potentialJ)
            {
                way = true;
                return;
            }
            if (i != sizeRow - 1 && !way)
            {
                GoDown(i + 1, j);
            }
            if (j != 0 && matrix[i, j] != 0 && !way)
            {
                GoLeft(i, j - 1);
                if (way && matrixPlusMinus[i, j] == '0')
                {
                    matrixPlusMinus[i, j] = symbol;
                    symbol = (symbol == '+') ? '-' : '+';
                    return;
                }
            }
            if (j != sizeColumn - 1 && matrix[i, j] != 0 && !way)
            {
                GoRight(i, j + 1);
                if (way && matrixPlusMinus[i, j] == '0')
                {
                    matrixPlusMinus[i, j] = symbol;
                    symbol = (symbol == '+') ? '-' : '+';
                    return;
                }
            }
        }

        private void GoUp(int i, int j)
        {
            if (i == potentialI && j == potentialJ)
            {
                way = true;
                return;
            }
            if (i != 0 && !way)
            {
                GoUp(i - 1, j);
            }
            if (j != 0 && matrix[i, j] != 0 && !way)
            {
                GoLeft(i, j - 1);
                if (way && matrixPlusMinus[i, j] == '0')
                {
                    matrixPlusMinus[i, j] = symbol;
                    symbol = (symbol == '+') ? '-' : '+';
                    return;
                }
            }
            if (j != sizeColumn - 1 && matrix[i, j] != 0 && !way)
            {
                GoRight(i, j + 1);
                if (way && matrixPlusMinus[i, j] == '0')
                {
                    matrixPlusMinus[i, j] = symbol;
                    symbol = (symbol == '+') ? '-' : '+';
                    return;
                }
            }
        }

        private void GoRight(int i, int j)
        {
            if (i == potentialI && j == potentialJ)
            {
                way = true;
                return;
            }
            if (j != sizeColumn - 1 && !way)
            {
                GoRight(i, j + 1);
            }
            if (i != 0 && matrix[i, j] != 0 && !way)
            {
                GoUp(i - 1, j);
                if (way && matrixPlusMinus[i, j] == '0')
                {
                    matrixPlusMinus[i, j] = symbol;
                    symbol = (symbol == '+') ? '-' : '+';
                    return;
                }
            }
            if (i != sizeRow - 1 && matrix[i, j] != 0 && !way)
            {
                GoDown(i + 1, j);
                if (way && matrixPlusMinus[i, j] == '0')
                {
                    matrixPlusMinus[i, j] = symbol;
                    symbol = (symbol == '+') ? '-' : '+';
                    return;
                }
            }
        }

        private void GoLeft(int i, int j)
        {
            if (i == potentialI && j == potentialJ)
            {
                way = true;
                return;
            }
            if (j != 0 && !way)
            {
                GoLeft(i, j - 1);
            }
            if (i != 0 && matrix[i, j] != 0 && !way)
            {
                GoUp(i - 1, j);
                if (way && matrixPlusMinus[i, j] == '0')
                {
                    matrixPlusMinus[i, j] = symbol;
                    symbol = (symbol == '+') ? '-' : '+';
                    return;
                }
            }
            if (i != sizeRow - 1 && matrix[i, j] != 0 && !way)
            {
                GoDown(i + 1, j);
                if (way && matrixPlusMinus[i, j] == '0')
                {
                    matrixPlusMinus[i, j] = symbol;
                    symbol = (symbol == '+') ? '-' : '+';
                    return;
                }
            }
        }

        public void Calculating()
        {
            for (int i = 0; i < sizeRow; i++)
            {
                for (int j = 0; j < sizeColumn; j++)
                {
                    if (matrixPlusMinus[i, j] == '-')
                    {
                        matrix[i, j] -= minimalElement;
                    }
                    else if (matrixPlusMinus[i, j] == '+')
                    {
                        matrix[i, j] += minimalElement;
                    }
                }
            }
            minimalElement = 0;
        }

        public void Start(DataGridView dataGridForPotents, TextBox textBoxForF)
        {
            List<int> uVec = new List<int>(new int[sizeRow]);
            List<int> vVec = new List<int>(new int[sizeColumn]);

            while (Potentials(ref uVec, ref vVec))
            {
                PrintMatrix(dataGridForPotents, uVec, vVec, true);
                SearchLoop(potentialI, potentialJ);
                MinFunc();
                Calculating();
            }
            TargetFunc(textBoxForF);
            PrintMatrix(dataGridForPotents, uVec, vVec, true);
        }

        public static void CheckAndBalance(ref List<int> supply, ref List<int> demand, ref int[,] cost)
        {
            int totalSupply = supply.Sum();
            int totalDemand = demand.Sum();

            if (totalSupply < totalDemand)
            {
                // Add a dummy supplier
                supply.Add(totalDemand - totalSupply);
                int newSize = demand.Count;
                int[,] newCost = new int[supply.Count, newSize];

                for (int i = 0; i < supply.Count - 1; i++)
                {
                    for (int j = 0; j < newSize; j++)
                    {
                        newCost[i, j] = cost[i, j];
                    }
                }
                for (int j = 0; j < newSize; j++)
                {
                    newCost[supply.Count - 1, j] = 0; // Fill the transportation cost of the dummy supplier with zeros
                }

                cost = newCost;
                Console.WriteLine($"Добавлен фиктивный поставщик с объемом {totalDemand - totalSupply}");
            }
            else if (totalSupply > totalDemand)
            {
                // Add a dummy consumer
                demand.Add(totalSupply - totalDemand);
                int newSize = supply.Count;
                int[,] newCost = new int[newSize, demand.Count];

                for (int i = 0; i < newSize; i++)
                {
                    for (int j = 0; j < demand.Count - 1; j++)
                    {
                        newCost[i, j] = cost[i, j];
                    }
                    newCost[i, demand.Count - 1] = 0; // Fill the transportation cost of the dummy consumer with zeros
                }

                cost = newCost;
                Console.WriteLine($"Добавлен фиктивный потребитель с объемом {totalSupply - totalDemand}");
            }
        }
    }
}