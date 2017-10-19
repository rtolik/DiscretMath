using System;
using System.Linq;

namespace DiscreteMath
{
    static class DiscretRelation<T> where T : IComparable<T>
    {
        public static Relation<T>[] Pow(Relation<T>[] a, int power)
        {
            try
            {
                if (!CheckType(a))
                    throw new NotComperableTypes();
                Relation<T>[] result;
                if (power > 0)
                {
                    result = a;
                    for (int i = 0; i < power; i++)
                        result = Compose(result, a);
                    return result;
                }
                else
                {
                    int resInd = 0;
                    result = new Relation<T>[0];
                    foreach (Relation<T> el in a)
                    {
                        foreach (Relation<T> checkEl in a)
                        {
                            if (Equals(el.X, checkEl.Y) && Equals(el.Y, checkEl.X))
                            {
                                Array.Resize(ref result, result.Length + 1);
                                result[resInd] = el;
                                resInd++;
                            }
                        }
                    }
                    return result;
                }
            }
            catch (NotComperableTypes e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static Relation<T>[] Compose(Relation<T>[] a, Relation<T>[] b)
        {
            try
            {
                if(!CheckType(a))
                    throw new NotComperableTypes();
                DeleteRepeat(ref a);
                DeleteRepeat(ref b);
                Relation<T>[] result = new Relation<T>[0];
                int resInd = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    for (int y = 0; y < b.Length; y++)
                    {
                        if (Equals(a[i].Y, b[y].X))
                        {
                            Array.Resize(ref result, result.Length + 1);
                            result[resInd] = new Relation<T>(a[i].X, b[y].Y);
                            resInd++;
                        }
                    }
                }
                return result;
            }
            catch (NotComperableTypes e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public static Relation<T>[] AlterUnion(ref Relation<T>[] a, ref Relation<T>[] b)
        {
            try
            {
                if(!CheckType(a))
                    throw new NotComperableTypes();
                int[] sameA;
                int[] sameB;
                FindSame(ref a, ref b, out sameA, out sameB);
                Relation<T>[] rezult = new Relation<T>[0];
                WriteNotSame(ref a, ref sameA, ref rezult);
                WriteNotSame(ref b, ref sameB, ref rezult);
                return rezult;
            }
            catch (NotComperableTypes e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public static Relation<T>[] Intersection(ref Relation<T>[] a, ref Relation<T>[] b)
        {
            try
            {
                if(!CheckType(a))
                    throw new NotComperableTypes();
                int[] sameA;
                int[] sameB;
                FindSame(ref a, ref b, out sameA, out sameB);
                Relation<T>[] rezult = new Relation<T>[0];
                for (int i = 0; i < sameA.Length; i++)
                {
                    Array.Resize(ref rezult, rezult.Length + 1);
                    rezult[i] = a[sameA[i]];
                }
                return rezult;
            }
            catch (NotComperableTypes e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public static Relation<T>[] Union(Relation<T>[] a, Relation<T>[] b)
        {
            try
            {
                if(!CheckType(a))
                    throw new NotComperableTypes();
                int[] sameA;
                int[] sameB;
                int rezInd = 0;
                FindSame(ref a, ref b, out sameA, out sameB);
                Relation<T>[] rezult = new Relation<T>[0];
                for (int i = 0; i < a.Length; i++)
                {
                    Array.Resize(ref rezult, rezult.Length + 1);
                    rezult[rezInd] = a[i];
                    rezInd++;
                }
                WriteNotSame(ref b, ref sameB, ref rezult);
                return rezult;
            }
            catch (NotComperableTypes e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        private static void WriteNotSame(ref Relation<T>[] a, ref int[] sameA, ref Relation<T>[] rezult)
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

        private static void FindSame(ref Relation<T>[] a, ref Relation<T>[] b, out int[] sameA, out int[] sameB)
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

        private static void DeleteRepeat<TYpe>(ref TYpe[] mas)
        {
            TYpe[] checkmas = new TYpe[mas.Length];
            checkmas = mas;
            TYpe tmp;
            int endInd = mas.Length - 1, reptime = 0;
            for (int i = 0; i < checkmas.Length; i++)
            {
                TYpe check = checkmas[i];
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

        private static int[,] MakeMatrix(Relation<T>[] rel)
        {
            if (CheckType(rel))
                throw new NotComperableTypes();
            int maxRel = FindMax(rel);

            return null;
        }

        public static int FindMax(Relation<T>[] rel)
        {
            Relation<T> maxRel = rel[0];
            //if (!(rel[0].X is string) && !(rel[0].X is char))
            {
                for (int i = 0; i < rel.Length; i++)
                {
                    if (maxRel < rel[i])
                    {
                        maxRel = rel[i];
                    }
                }
                if (int.TryParse((maxRel.X.CompareTo(maxRel.Y) >= 0 ? maxRel.X : maxRel.Y).ToString(), out int result))
                    return result;
                else
                    return 0;
            }
         
        }

        private static bool CheckType(object obj)
        {
            if (obj is Relation<char>[] || obj is Relation<float>[] || obj is Relation<double>[] || obj is Relation<int>[])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class NotComperableTypes:ApplicationException
    {
        public NotComperableTypes() :base("Can`t compare types. Use char, float, int, double types instead")
        {}
    }

}