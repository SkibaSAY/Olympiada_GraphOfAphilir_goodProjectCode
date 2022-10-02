using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafOfOphilir.Class
{
    public class Matrix<T>:IComparable<Matrix<T>> where T: IComparable<T>
    {
        private T[,] data;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Matrix(int width, int height)
        {
            Width = width;
            Height = height;
            data = new T[width, height];
        }

        public Matrix(T[,] data, int width, int height)
        {
            this.data = data;
            this.Height = height;
            this.Width = width;
        }

        //индексатор
        public T this[int x, int y]
        {
            get
            {
                if (x >= Width || y >= Height || x < 0 || y < 0)
                {
                    throw new ArgumentException("index is not definded");
                }

                return data[x, y];
            }
            set
            {
                if (x >= Width || y >= Height || x < 0 || y < 0)
                {
                    throw new ArgumentException("index is not definded");
                }

                data[x, y] = value;
            }
        }

        /// <summary>
        /// Вывод матрицы
        /// </summary>
        /// <param name="writer"></param>
        public void PrintMatrix(IWriter writer)
        {
            var listOut = ToStringList();
            writer.Write(listOut.ToArray());
        }

        /// <summary>
        /// получение всех строк матрицы
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        public List<String> ToStringList(string separator = " ")
        {
            var outList = new List<string>();
            for (int i = 0; i < Width; i++)
            {
                var items = new List<T>();
                for (var j = 0; j < Height; j++)
                {
                    items.Add(data[i, j]);
                }
                outList.Add(String.Join(separator,items));
            }

            return outList;
        }

        /// <summary>
        /// Транспозиция матрицы
        /// </summary>
        /// <returns></returns>
        public Matrix<T> Transposition()
        {
            var newMatrix = new Matrix<T>(this.Height, this.Width);
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                    newMatrix[j, i] = this[i, j];
            }

            return newMatrix;
        }

        /// <summary>
        /// Слияние матриц, начиная с заданной точки
        /// </summary>
        /// <param name="anotherMatrix"></param>
        /// <param name="startPoint">Точка относительно верхнего левого края исходной матрицы, куда будет подставлен верхний левый край другой матрицы</param>
        public Matrix<T> Merge(Matrix<T> anotherMatrix, Point startPoint)
        {
            //размеры обьединённой матрицы
            var newWight = Math.Max(this.Width,startPoint.X + anotherMatrix.Width);
            newWight = Math.Max(newWight, this.Width - startPoint.X);

            var newHeight = Math.Max(this.Height, startPoint.Y + anotherMatrix.Height);
            newHeight = Math.Max(newHeight, this.Height - startPoint.Y);

            Matrix<T> newMatrix = new Matrix<T>(newWight, newHeight);

            //заполняем из исходной матрицы
            for (var i = 0; i < this.Width; i++)
            {
                for (var j = 0; j < this.Height; j++)
                {
                    //учесть возможную ссылочность, тк они будут ссылаться на один элемент, что может быть плохо
                    
                    //параметры смещения, в зависимости от начальной точки
                    var a = startPoint.X < 0 ? startPoint.X : 0;
                    var b = startPoint.Y < 0 ? startPoint.Y : 0;
                    newMatrix[i-a, j-b] = this[i, j];
                }
            }

            //заполняем из добавочной матрицы
            for (var i = 0; i < anotherMatrix.Width; i++)
            {
                for (var j = 0; j < anotherMatrix.Height; j++)
                {
                    var a = startPoint.X > 0 ? startPoint.X : 0;
                    var b = startPoint.Y > 0 ? startPoint.Y : 0;

                    newMatrix[i+a, j+b] = anotherMatrix[i, j];
                }
            }

            //если получилась ситуация, когда добавочная пытается затереть исходную то, действуем в зависимости от опций
            //опции - последовательность, определяющая как действовать в случае, когда добавочная пытается затереть исходную

            //пока буду возвращать с перезатиранием
            return newMatrix;
        }

        public int CompareTo(Matrix<T> other)
        {
            if (other.Height == this.Height && other.Width == this.Width)
            {
                for (var i = 0; i < other.Width; i++)
                {
                    for (int j = 0; j < other.Height; j++)
                    {
                        var flag = other[i, j].CompareTo(this[i, j]);
                        if (flag != 0) return flag;
                    }
                }

                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
