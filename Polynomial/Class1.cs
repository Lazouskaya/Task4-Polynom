using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public class Polynom
    {
        public double[] Koeff { get; set; }
        private int Degree { get; set; }
        public Polynom(params double[] koefficients)
        {
            Koeff= koefficients;
            Degree = koefficients.Length-1;
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
            double[] newKoeff = new double[greater.Degree+1];
            for (int i=0; i<=greater.Degree; i++)
            { newKoeff[i] = greater.Koeff[i];}
            for (int i = 0; i <= less.Degree; i++)
            { newKoeff[i] += less.Koeff[i];}
            Polynom sum = new Polynom(newKoeff);
            return sum;
        }

        public static Polynom operator -(Polynom a, Polynom b)
        {
            Polynom greater;
            Polynom less;
            if (a.Degree < b.Degree)
            {
                less = a;
                greater = b;
            }
            else
            {
                greater = a;
                less = b;
            }
            double[] newKoeff = new double[greater.Degree + 1];
            for (int i = 0; i <= greater.Degree; i++)
            { newKoeff[i] = greater.Koeff[i]; }
            for (int i = 0; i <= less.Degree; i++)
            { newKoeff[i] -= less.Koeff[i]; }
            //следует добавить удаление нулей из конца массива;
            Polynom minus = new Polynom(newKoeff);
            return minus;
        }
    }
}
