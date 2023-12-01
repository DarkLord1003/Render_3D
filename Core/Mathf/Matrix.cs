using System;

namespace Render_3D.Core.Mathf
{
    public class Matrix
    {
        private float[,] _values;
        public int CountRows { get; private set; }
        public int CountCols { get; private set; }

        public float this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= CountRows)
                    throw new ArgumentOutOfRangeException("row");

                if(column < 0 || column >= CountCols)
                    throw new ArgumentOutOfRangeException("column");

                return _values[row, column];
            }

            set
            {
                if (row < 0 || row >= CountRows)
                    throw new ArgumentOutOfRangeException("row");

                if (column < 0 || column >= CountCols)
                    throw new ArgumentOutOfRangeException("column");

                _values[row, column] = value;
            }
        }

        public Matrix(int rows = 4, int cols = 4)
        {
            if (rows < 0 || cols < 0) 
                throw new ArgumentOutOfRangeException("rows or cols");

            CountRows = rows;
            CountCols = cols;
            _values = new float[CountRows, CountCols];
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1 == null || m2 == null)
                return null;

            if (m1.CountRows != m2.CountRows || m1.CountCols != m2.CountCols)
                throw new InvalidOperationException("These matrixes not equals");

            Matrix result = new Matrix(m2.CountRows, m2.CountCols);

            for(int i = 0; i < m1.CountRows; i++)
            {
                for(int j = 0; j < m1.CountCols; j++)
                {
                    result[i, j] = m1[i, j] + m2[i, j];
                }
            }

            return result;
        }
        
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1 == null || m2 == null)
                return null;

            if (m1.CountRows != m2.CountRows || m1.CountCols != m2.CountCols)
                throw new InvalidOperationException("These matrixes not equals");

            Matrix result = new Matrix(m2.CountRows, m2.CountCols);

            for(int i = 0; i < m1.CountRows; i++)
            {
                for(int j = 0; j < m1.CountCols; j++)
                {
                    result[i, j] = m1[i, j] - m2[i, j];
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1 == null || m2 == null)
                return null;

            if (m1.CountCols != m2.CountRows)
                throw new InvalidOperationException("These matrixes dont mult");

            Matrix result = new Matrix(m1.CountRows, m2.CountCols);

            for(int i = 0; i < m1.CountRows; i++)
            {
                for(int j = 0; j < m2.CountCols; j++)
                {
                    for(int k = 0; k < m2.CountRows; k++)
                    {
                        result[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }
            
            return result;
        }

        public static Matrix operator *(Matrix m, float scalar)
        {
            if(m == null)
                return null;

            Matrix result = new Matrix(m.CountRows, m.CountCols);

            for(int i = 0; i < m.CountRows; i++)
            {
                for(int j = 0;j < m.CountCols; j++)
                {
                    result[i, j] = m[i, j] * scalar;
                }
            }

            return result;
        } 
        
        public static Matrix operator *(float scalar, Matrix m)
        {
            if(m == null)
                return null;

            Matrix result = new Matrix(m.CountRows, m.CountCols);

            for(int i = 0; i < m.CountRows; i++)
            {
                for(int j = 0;j < m.CountCols; j++)
                {
                    result[i, j] = m[i, j] * scalar;
                }
            }

            return result;
        }

        public Matrix GetMinor(int row, int column)
        {
            if (row < 0 || row >= CountRows)
                throw new ArgumentOutOfRangeException("row");

            if(column < 0 || column >= CountCols)
                throw new ArgumentOutOfRangeException("column");

            Matrix result = new Matrix(CountRows - 1, CountCols - 1);

            for(int i = 0, p = 0; i < CountRows; i++)
            {
                if (row == i)
                    continue;


                for(int j = 0, q = 0; j < CountCols; j++)
                {
                    if(column == j)
                        continue;

                    result[p, q] = _values[i, j];
                    q++;
                }

                p++;
            }

            return result;
        }

        public float Determinant()
        {
            if (CountRows != CountCols)
                throw new InvalidOperationException("This matrix is not equals");

            if(CountCols == 1)
                return _values[0, 0];

            float determinat = 0f;
            int sign = 1;

            for(int i = 0; i < CountCols; i++)
            {
                var minor = GetMinor(0, i);
                determinat += _values[0, i] * sign * minor.Determinant();
                sign = -sign;
            }

            return determinat;
        }

        public Matrix GetAdjointMatrix()
        {
            Matrix result = new Matrix(CountRows, CountCols);

            int sign = 1;

            for(int i = 0; i < CountRows; i++)
            {
                for(int j = 0; j < CountCols; j++)
                {
                    var minor = GetMinor(i, j);
                    sign = ((i + j) % 2 == 0) ? 1 : -1;

                    result[i, j] = sign * minor.Determinant();
                }
            }

            return result;
        }

        public Matrix GetInverseMatrix()
        {
            float determinant = Determinant();

            if (determinant == 0)
                return null;

            Matrix adjoint = GetAdjointMatrix();
            Matrix result = (1f / determinant) * adjoint.Transpose();

            return result;
        }

        public Matrix Transpose()
        {
            Matrix result = new Matrix(CountRows, CountCols);

            for(int i = 0; i < CountRows; i++)
            {
                for(int j = 0; j < CountCols; j++)
                {
                    result[j, i] = _values[i, j];
                }
            }

            return result;
        }

        public static Matrix GetUnitMatrix(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0)
                throw new ArgumentOutOfRangeException("rows or cols");

            Matrix result = new Matrix(rows, cols);

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    if (i == j)
                        result[i, j] = 1f;
                }
            }

            return result;
        }

        public override string ToString()
        {
            string matrixStr = string.Empty;

            for(int i = 0; i < CountRows; i++)
            {
                matrixStr += "[";
                
                for(int j = 0; j < CountCols; j++)
                {
                    matrixStr += _values[i, j] + "\t";
                }

                matrixStr += "]";
            }

            return matrixStr;
        }
    }
}
