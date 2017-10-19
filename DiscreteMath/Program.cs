using System;
using System.Linq;

namespace DiscreteMath
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 4, 3, 8, 6, 9, 15 };
            int[] b = { 6, 56, 7, 3, 6, 8 };
            Console.WriteLine("A:");
            Print(a);
            Console.WriteLine("B:");
            Print(b);
            int[] c = DiscretPlural<int>.Union(ref a, ref b);
            Console.WriteLine("Result of Union A and B:");
            Print(c);
            c = DiscretPlural<int>.Intersection(ref a, ref b);
            Console.WriteLine("Result of Intersection A and B:");
            Print(c);
            c = DiscretPlural<int>.AlterUnion(ref a, ref b);
            Console.WriteLine("Result of AlterUnion A and B:");
            Print(c);
            c = DiscretPlural<int>.Without(ref a, ref b);
            Console.WriteLine("Result of A Without B:");
            Print(c);
            Console.WriteLine("Result of Decrt Product A and B");
            Relation<int>[] res = DiscretPlural<int>.Decart(ref a, ref b);
            Print(res);
            Console.WriteLine();
            Relation<int>[] d = new Relation<int>[6];
            d[0] = new Relation<int>(1, 2);
            d[1] = new Relation<int>(1, 3);
            d[2] = new Relation<int>(1, 5);
            d[3] = new Relation<int>(2, 3);
            d[4] = new Relation<int>(3, 4);
            d[5] = new Relation<int>(5, 2);
            Console.WriteLine("D:");
            Print(d);
            Console.WriteLine();
            Relation<int>[] e = new Relation<int>[6];
            e[0] = new Relation<int>(1, 3);
            e[1] = new Relation<int>(1, 4);
            e[2] = new Relation<int>(2, 2);
            e[3] = new Relation<int>(3, 4);
            e[4] = new Relation<int>(4, 2);
            e[5] = new Relation<int>(2, 4);
            Console.WriteLine("E");
            Print(e);
            Console.WriteLine();
            Relation<int>[] f = DiscretRelation<int>.Compose(d, e);
            Console.WriteLine("Result of Compose D and E:");
            Print(f);
            Console.WriteLine();

            f = DiscretRelation<int>.Pow(e, 3);
            Console.WriteLine("Result of Power E to 3:");
            Print(f);
            Console.WriteLine();

            f = DiscretRelation<int>.AlterUnion(ref e, ref f);
            Console.WriteLine("Result of AlterUnion E and F:");
            Print(f);
            Console.WriteLine();

            f = DiscretRelation<int>.Intersection(ref e, ref f);
            Console.WriteLine("Result of Intersection E and F:");
            Print(f);
            Console.WriteLine();

            f = DiscretRelation<int>.Union(e, f);
            Console.WriteLine("Result of Union E and F:");
            Print(f);
            Console.WriteLine();

            Console.WriteLine("\n\n\n\nFindMax(f)" + DiscretRelation<int>.FindMax(f));
        }

        public static void Print<T>(T[] mas)
        {
            
            Console.Write("{");
            foreach (T el in mas)
            {
                //Console.Beep();
                Console.Write("\t" + el + ";");
            }
            Console.Write("}");
            Console.WriteLine();
        }
    }
}