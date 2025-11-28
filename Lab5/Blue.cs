using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            answer = new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                answer[i] = 0;
                int d = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    d += (matrix[i, j] > 0 ? 1 : 0);
                    answer[i] += (matrix[i, j] > 0 ? matrix[i, j] : 0);
                }
                if (d > 0)
                    answer[i] /= d;
            }

   

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;
            int a = matrix.GetLength(0);
            int b = matrix.GetLength(1);
            answer = new int[a - 1, b - 1];
            int x = 0;
            int y = 0;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (matrix[i, j] > matrix[x, y])
                    {
                        x = i;
                        y = j;
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == x)
                    continue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == y)
                        continue;
                    answer[i - (i >= x ? 1 : 0), j - (j >= y ? 1 : 0)] = matrix[i, j];
                }
            }

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int y = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, y])
                        y = j;
                }

                for (int j = y; j + 1 < matrix.GetLength(1); j++)
                {
                    matrix[i, j] ^= matrix[i, j + 1];
                    matrix[i, j + 1] ^= matrix[i, j];
                    matrix[i, j] ^= matrix[i, j + 1];
                }
            }

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;
            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int mx = matrix[i, 0];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    answer[i, j + (j == matrix.GetLength(1) - 1 ? 1 : 0)] = matrix[i, j];
                    if (matrix[i, j] > mx)
                        mx = matrix[i, j];
                }
                answer[i, matrix.GetLength(1) - 1] = mx;
            }
            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            answer = new int[matrix.Length / 2];
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 1)
                        answer[cnt++] = matrix[i, j];
                }
            }

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            int mxI = 0, sI = -1;
            if (matrix.GetLength(0) != matrix.GetLength(1) || matrix.GetLength(0) == 0)
                return;
            for (int i = 0; i < matrix.GetLength(0); i++)
                if (matrix[mxI, mxI] < matrix[i, i])
                    mxI = i;
            for (int i = 0; i < matrix.GetLength(0); i++)
                if (matrix[i, k] < 0)
                {
                    sI = i;
                    break;
                }

            if (sI == -1)
                return;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                (matrix[mxI, i], matrix[sI, i]) = (matrix[sI, i], matrix[mxI, i]);
            }

        }
        public void Task7(int[,] matrix, int[] array)
        {

            if (matrix.GetLength(1) < 2)
                return;
            if (matrix.GetLength(1) != array.Length)
                return;
            int mx = matrix[0, 0], mxI = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                if (mx < matrix[i, matrix.GetLength(1) - 2])
                {
                    mx = matrix[i, matrix.GetLength(1) - 2];
                    mxI = i;
                }
            for (int i = 0; i < matrix.GetLength(1); i++)
                matrix[mxI, i] = array[i];

        }
        public void Task8(int[,] matrix)
        {

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int mxI = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > matrix[mxI, j])
                        mxI = i;
                }
                if (mxI < matrix.GetLength(0) / 2)
                {
                    matrix[0, j] = 0;
                    for (int i = mxI + 1; i < matrix.GetLength(0); i++)
                        matrix[0, j] += matrix[i, j];
                }

            }

        }
        public void Task9(int[,] matrix)
        {
            for (int i = 0; i + 1 < matrix.GetLength(0); i += 2)
            {
                int j1 = 0, j2 = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, j1])
                        j1 = j;
                    if (matrix[i + 1, j] > matrix[i + 1, j2])
                        j2 = j;
                }

                (matrix[i, j1], matrix[i + 1, j2]) = (matrix[i + 1, j2], matrix[i, j1]);
            }
        }
        public void Task10(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;
            int mxI = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > matrix[mxI, mxI])
                    mxI = i;
            }

            for (int i = 0; i < mxI; i++)
            {
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }
        public void Task11(int[,] matrix)
        {
            int[] cnt = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                        cnt[i]++;
                }
            }
            for (int i = 0; i + 1 < matrix.GetLength(0); i++)
            {
                int mI = i;
                for (int j = i + 1; j < matrix.GetLength(0); j++)
                {
                    if (cnt[j] > cnt[mI])
                        mI = j;
                }

                if (mI == i)
                    continue;

                for (int j = 0; j < matrix.GetLength(1); j++)
                    (matrix[i, j], matrix[mI, j]) = (matrix[mI, j], matrix[i, j]);

                (cnt[i], cnt[mI]) = (cnt[mI], cnt[i]);
            }
        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;
            double av = 0;
            int num = 0;

            foreach (var i in array)
            {
                foreach (var j in i)
                {
                    av += j;
                    num++;
                }
            }

            av /= num;

            int cnt = 0;

            foreach (var i in array)
            {
                double avc = 0;
                int numc = 0;
                foreach (var j in i)
                {
                    avc += j;
                    numc++;
                }
                if (avc / numc >= av)
                    cnt++;
            }

            answer = new int[cnt][];

            int ln = 0;
            foreach (var i in array)
            {
                int tmp = 0;
                double avc = 0;
                int num2 = 0;
                foreach (int j in i)
                {
                    avc += j;
                    num2++;
                }
                if (avc / num2 >= av)
                {
                    int[] arr = new int[i.Length];
                    foreach (var j in i)
                        arr[tmp++] = j;
                    answer[ln++] = arr;
                }
            }
            return answer;
        }
    }
}
