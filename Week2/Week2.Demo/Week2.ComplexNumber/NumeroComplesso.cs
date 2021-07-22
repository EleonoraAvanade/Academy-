using System;

namespace Week2.ComplexNumber
{
    public enum Format
    {
        Algebrico,
        Parentesi
    }

    public class NumeroComplesso
    {

        public double Reale { get; set; }
        public double Immaginaria { get; set; }

        public double Modulo
        {
            get
            {
                return Math.Sqrt(Math.Pow(Reale, 2) + Math.Pow(Immaginaria, 2));
            }
        }

        public NumeroComplesso Coniugato
        {
            get
            {
                return new NumeroComplesso()
                {
                    Reale = this.Reale,
                    Immaginaria = -this.Immaginaria
                };
            }
        }

        public NumeroComplesso Somma(NumeroComplesso value)
        {
            //NumeroComplesso risultato = new NumeroComplesso();
            //risultato.Reale = this.Reale + value.Reale;
            //risultato.Immaginaria = this.Immaginaria + value.Immaginaria;
            //return risultato;

            return new NumeroComplesso
            {
                Reale = this.Reale + value.Reale,
                Immaginaria = this.Immaginaria + value.Immaginaria
            };
        }

        public static NumeroComplesso operator +(NumeroComplesso a, NumeroComplesso b)
        {
            return a.Somma(b);
        }

        public NumeroComplesso Differenza(NumeroComplesso value)
        {
            double parteReale = value.Reale > 0 ? this.Reale - value.Reale : this.Reale + value.Reale;
            double parteImmaginaria = value.Immaginaria > 0 ? this.Immaginaria - value.Immaginaria : this.Immaginaria + value.Immaginaria;
            return new NumeroComplesso
            {
                Reale = parteReale,
                Immaginaria = parteImmaginaria
            };
        }

        public NumeroComplesso Moltiplicazione(NumeroComplesso value)
        {
            return new NumeroComplesso
            {
                Reale = this.Reale * value.Reale - this.Immaginaria * value.Immaginaria,
                Immaginaria = this.Reale * value.Immaginaria + this.Immaginaria * value.Reale
            };
        }

        public NumeroComplesso Divisione(NumeroComplesso value)
        {
            double denom = Math.Pow(value.Reale, 2) + Math.Pow(value.Immaginaria, 2);
            if (denom == 0)
            {
                //throw new DivideByZeroException();
                throw new NumeroComplessoException("Spiacente, la tua operazione non va a buon fine")
                {
                    PrimoOperatore = this,
                    SecondoOperatore = value
                };
            }
            double realeRisul = (this.Reale * value.Reale + this.Immaginaria * value.Immaginaria) / denom;
            double immRisul = (this.Immaginaria * value.Reale - this.Reale * value.Immaginaria) / denom;
            return new NumeroComplesso
            {
                Reale = realeRisul,
                Immaginaria = immRisul
            };
        }

        public override string ToString()
        {
            return $"Reale: {Reale} - Immaginaria: {Immaginaria}";
        }

        public string ToString(Format format)
        {
            switch (format)
            {
                case Format.Algebrico:
                    return $"{Reale} { (Immaginaria < 0 ? "-" : "+") } i {Math.Abs(Immaginaria)}";
                    break;
                case Format.Parentesi:
                    return $"({Reale}, {Immaginaria})";
                    break;
                default:
                    return this.ToString();
            }
        }

    }
}
