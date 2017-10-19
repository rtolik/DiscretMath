using System;

namespace DiscreteMath
{
    static class DiscretPlural<T> where T:IComparable<T>
    {
        public static T[] Without(ref T[] a, ref T[] b)
        {
            int[] sameA;
            int[] sameB;
            FindSame(ref a, ref b, out sameA, out sameB);
            T[] rezult = new T[0];
            WriteNotSame(ref a, ref sameA, ref rezult);
            return rezult;
        }

        public static T[] AlterUnion(ref T[] a, ref T[] b)
        {
            int[] sameA;
            int[] sameB;
            FindSame(ref a, ref b, out sameA, out sameB);
            T[] rezult = new T[0];
            WriteNotSame(ref a, ref sameA, ref rezult);
            WriteNotSame(ref b, ref sameB, ref rezult);
            return rezult;
        }

        public static T[] Intersection(ref T[] a, ref T[] b)
        {
            int[] sameA;
            int[] sameB;
            FindSame(ref a, ref b, out sameA, out sameB);
            T[] rezult = new T[0];
            for (int i = 0; i < sameA.Length; i++)
            {
                Array.Resize(ref rezult, rezult.Length + 1);
                rezult[i] = a[sameA[i]];
            }
            return rezult;
        }

        public static T[] Union(ref T[] a, ref T[] b)
        {
            int[] sameA;
            int[] sameB;
            int rezInd = 0;
            FindSame(ref a, ref b, out sameA, out sameB);
            T[] rezult = new T[0];
            for (int i = 0; i < a.Length; i++)
            {
                Array.Resize(ref rezult, rezult.Length + 1);
                rezult[rezInd] = a[i];
                rezInd++;
            }
            WriteNotSame(ref b, ref sameB, ref rezult);
            return rezult;
        }

        public static Relation<T>[] Decart(ref T[] a, ref T[] b)
        {
            DeleteRepeat(ref a);
            DeleteRepeat(ref b);
            Relation<T>[] result = new Relation<T>[0];
            int resInd = 0;
            foreach (T elA in a)
            {
                foreach (T elB in b)
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[resInd] = new Relation<T>(elA, elB);
                    resInd++;
                }
            }
            DeleteRepeat(ref result);
            return result;
        }

        private static void WriteNotSame(ref T[] a, ref int[] sameA, ref T[] rezult)
        {
            int rezInd = rezult.Length;
            bool check = false;
            for (int i = 0; i < a.Length; i++)
            {
                for (int y = 0; y < sameA.Length; y++)
                {
                    if (Equals(i, sameA[y]))
                    {
                        check = true;
                        break;
                    }
                }
                if (!check)
                {
                    Array.Resize(ref rezult, (rezult.Length + 1));
                    rezult[rezInd] = a[i];
                    rezInd++;
                }
                check = false;
            }
        }

        private static void FindSame(ref T[] a, ref T[] b, out int[] sameA, out int[] sameB)
        {
            DeleteRepeat(ref a);
            DeleteRepeat(ref b);
            sameA = new int[0];
            sameB = new int[0];
            bool isSame = false;
            int indB = 0, indA = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int y = 0; y < b.Length; y++)
                {
                    if (Equals(a[i], b[y]))
                    {
                        Array.Resize(ref sameB, sameB.Length + 1);
                        isSame = true;
                        sameB[indB] = y;
                        indB++;
                    }
                }
                if (isSame)
                {
                    Array.Resize(ref sameA, sameA.Length + 1);
                    sameA[indA] = i;
                    indA++;
                }
                isSame = false;
            }
        }

        private static void DeleteRepeat<type>(ref type[] mas)
        {
            type[] checkmas = new type[mas.Length];
            checkmas = mas;
            type tmp;
            int endInd = mas.Length - 1, reptime = 0;
            for (int i = 0; i < checkmas.Length; i++)
            {
                type check = checkmas[i];
                for (int y = 0; y < mas.Length; y++)
                {
                    if (Equals(check, mas[y]) && reptime != 0)
                    {
                        tmp = mas[y];
                        mas[y] = mas[endInd];
                        mas[endInd] = tmp;
                        Array.Resize(ref mas, mas.Length - 1);
                        endInd = mas.Length - 1;
                        reptime++;
                    }
                    else
                        if (Equals(check, mas[y]) && reptime == 0)
                        reptime++;
                }
                reptime = 0;
            }
        }
    }
}