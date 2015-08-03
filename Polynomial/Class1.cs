using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public class Polynom:ICloneable,IEquatable<Polynom>
    {
        private double[] koeff;

        public int Degree
        {
            get { return koeff.Length - 1; }
        }
        public Polynom(params double[] koefficients)
        {
            koeff= koefficients;
        }

        public double this[int index]
        {
            get
            {
                return koeff[index];
            }
            private set { koeff[index] = value; }
        }   

        public static Polynom operator +(Polynom a, Polynom b)
        {
            Polynom greater;
            Polynom less;
            if (a.Degree < b.Degree){
                less = a;
                greater = b;}
            else{
                greater = a;
                less = b; }
            Polynom sum = (Polynom)greater.Clone();
            for (int i = 0; i <= less.Degree; i++)
            { sum.koeff[i] += less[i];}
            return sum;
        }

        public static Polynom operator +(Polynom a, double num)
        {
            Polynom newPolynom = (Polynom) a.Clone();
            newPolynom.koeff[newPolynom.Degree + 1] += num;
            return newPolynom;
        }

        public static Polynom operator -(Polynom a, double num)
        {
            return a+(-num);
        }

        public static Polynom operator -(Polynom a, Polynom b)
        {
            Polynom minus = a+b*(-1);
            return minus;
        }

        public static Polynom operator *(Polynom a, double num)
        {
            Polynom newPolynom = (Polynom) a.Clone();
            for (int i = 0; i <= a.Degree; i++)
            {
                newPolynom.koeff[i] *= num;
            }
            return newPolynom;
        }

        public static Polynom operator *(Polynom a, Polynom b)
        {
            double[] newKoeff = new double[a.Degree+b.Degree+1] ;
            for (int i = 0; i <= a.Degree; i++)
            {
                for (int j = 0; j <= b.Degree; j++)
                {
                    newKoeff[i + j] += a[i]*b[j];
                }
            }
            return new Polynom(newKoeff);
        }

        public static bool operator ==(Polynom a, Polynom b)
        {
            return  ReferenceEquals(a,b);
        }

        public static bool operator !=(Polynom a, Polynom b)
        {
            return !ReferenceEquals(a,b);
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Polynom Clone()
        {
            Polynom newPolynom = (Polynom)this.MemberwiseClone();
            double[] koefficients = new double[this.Degree + 1];
            for (int i = 0; i <= this.Degree; i++)
            {
                koefficients[i] = this[i];
            }
            newPolynom.koeff = koefficients;
            return newPolynom;
        }

        public override bool Equals(Object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            Polynom polynom = obj as Polynom;
            return Equals(polynom);
        }

        public bool Equals(Polynom other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return this.koeff.Length == other.koeff.Length && this.koeff.SequenceEqual(other.koeff);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Degree+1; i++)
                if (i == this.Degree)
                    sb.Append(string.Format("{0}", this[i]));
                else
                    sb.Append(string.Format("{0}x^{1} + ", this[i], this.Degree - i));
            return sb.ToString();
        }

        public double Calculate(double x)
        {
            double value = 0;
            for (int i = 0; i <=this.Degree ; i++)
            {
                value +=this[i]* Math.Pow(x, Degree-i);
            }
            return value;
        }
    }
}
