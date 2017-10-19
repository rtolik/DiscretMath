using System;

namespace DiscreteMath
{
    public class Relation<T> : IComparable<Relation<T>> where T : IComparable<T>
    {
        public T X { get; set; }
        public T Y { get; set; }

        public Relation(T x, T y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }

        public int CompareTo(Relation<T> other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var xComparison = X.CompareTo(other.X);
            if (xComparison == Y.CompareTo(other.Y))
                return xComparison;
            else
            {
                return -1;
            }
        }

        public static bool operator ==(Relation<T> left, Relation<T> right)
        {
            return left.CompareTo(right) == 0 ? true : false;
        }

        public static bool operator !=(Relation<T> left, Relation<T> right)
        {
            return left.CompareTo(right) == 1 ? true : false;
        }

        public static bool operator >(Relation<T> left, Relation<T> right)
        {
            return left.CompareTo(right) > 0 ? true : false;
        }

        public static bool operator <(Relation<T> left, Relation<T> right)
        {
            return left.CompareTo(right) < 0 ? true : false;
        }

        public static bool operator >=(Relation<T> left, Relation<T> right)
        {
            return left.CompareTo(right) >= 0 ? true : false;
        }

        public static bool operator <=(Relation<T> left, Relation<T> right)
        {
            return left.CompareTo(right) <= 0 ? true : false;
        }
    }
}
