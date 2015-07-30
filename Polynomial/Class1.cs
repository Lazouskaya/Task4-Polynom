using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public class Polynom:ICloneable,IEquatable<Polynom>
    {
        public double[] koeff;
        private int degree;
        public Polynom(params double[] koefficients)
        {
            koeff= koefficients;
            degree = koefficients.Length-1;
        }

        public double this[int index]
        {
            get
            {
                return koeff[index];
            }
            //set { koeff[index] = value; }
        }   

        public static Polynom operator +(Polynom a, Polynom b)
        {
            Polynom greater;
            Polynom less;
            if (a.degree < b.degree){
                less = a;
                greater = b;}
            else{
                greater = a;
                less = b; }
            Polynom sum = (Polynom)greater.Clone();
            for (int i = 0; i <= less.degree; i++)
            { sum.koeff[i] += less[i];}
            return sum;
        }

        public static Polynom operator +(Polynom a, double num)
        {
            Polynom newPolynom = (Polynom) a.Clone();
            newPolynom.koeff[newPolynom.degree + 1] += num;
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
            for (int i = 0; i <= a.degree; i++)
            {
                newPolynom.koeff[i] *= num;
            }
            return newPolynom;
        }

        public static Polynom operator *(Polynom a, Polynom b)
        {
            double[] newKoeff = new double[a.degree+b.degree+1] ;
            for (int i = 0; i <= a.degree; i++)
            {
                for (int j = 0; j <= b.degree; j++)
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
        public object Clone()
        {
            Polynom newPolynom = (Polynom) this.MemberwiseClone();
            double[] koefficients = new double[this.degree+1];
            for (int i = 0; i <= this.degree; i++)
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
            for (int i = 0; i < this.degree+1; i++)
                if (i == this.degree)
                    sb.Append(string.Format("{0}", this[i]));
                else
                    sb.Append(string.Format("{0}x^{1} + ", this[i], this.degree - i));
            return sb.ToString();
        }

        public double Calculate(double x)
        {
            double value = 0;
            for (int i = 0; i <=this.degree ; i++)
            {
                value +=this[i]* Math.Pow(x, degree-i);
            }
            return value;
        }
    }
}
