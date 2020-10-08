using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using System.Globalization;
using System.Text;


namespace WebApplication11.Models
{
    public class Numero
    {
        public string extenso { get; set; }

        public Numero(string id) { }

        public void ConverteNumero(string id)
        {
            string numeroinvertido = new string(id.Reverse().ToArray());
            string sinalmenos = string.Empty;
            string aux = string.Empty;
            char[] chararray;
            string mensagemerro = string.Empty;

            string unidade = string.Empty;
            string dezena = string.Empty;
            string centena = string.Empty;
            string milhar = string.Empty;
            string dezenademilhar = string.Empty;

            aux = new string(numeroinvertido.Substring(0));

            // --------- Verifica se o número é negativo ---------\\
            if (aux.Contains('-'))
            {
                sinalmenos = "menos ";
                numeroinvertido = numeroinvertido.Substring(0, numeroinvertido.Length - 1);
            }

            // --------- Verifica o limite de caracteres ---------\\
            if (numeroinvertido.Length > 5)
            {
                numeroinvertido = string.Empty;
                sinalmenos = string.Empty;
                mensagemerro = "O valor informado está fora do intervalo [-99999, 99999]";
            }

            // --------- Verifica se o valor digitado é um número inteiro ---------\\
            chararray = numeroinvertido.ToCharArray(0, numeroinvertido.Length);

            foreach (char c in chararray)
            {
                if (!char.IsNumber(c))
                {
                    numeroinvertido = string.Empty;
                    sinalmenos = string.Empty;
                    mensagemerro = "O valor digitado é inválido";
                    break;
                }
            }

            // --------- Converte dezena de milhar de 10 a 19 ---------\\
            if (numeroinvertido.Length == 5 && numeroinvertido[4] == '1')
            {
                dezenademilhar = Dezena2Get(numeroinvertido, 3, 2);

                dezenademilhar = dezenademilhar + " mil";
            }

            // --------- Converte dezena de milhar---------\\
            else if (numeroinvertido.Length == 5 && numeroinvertido[4] != '0')
            {
                dezenademilhar = DezenaGet(numeroinvertido, 4);

                if (numeroinvertido[3] == '0')
                {
                    dezenademilhar = dezenademilhar + " mil";
                }
            }

            // --------- Converte milhar ---------\\
            if (numeroinvertido.Length >= 4 && numeroinvertido[3] != '0')
            {
                milhar = UnidadeOuMilharGet(numeroinvertido, 3);

                if (numeroinvertido.Length == 5 && numeroinvertido[4] != '1')
                {
                    milhar = " e " + milhar + " mil";
                }

                else if (numeroinvertido.Length == 4)
                {
                    milhar += " mil";
                }

                else if (numeroinvertido.Length == 5 && numeroinvertido[4] == '1')
                {
                    milhar = string.Empty;
                }
            }

            // --------- Converte centena ---------\\
            if (numeroinvertido.Length >= 3 && numeroinvertido[2] != '0')
            {
                centena = CentenaGet(numeroinvertido, 2);
            
                if (numeroinvertido[2] == '1' && numeroinvertido[1] == '0' && numeroinvertido[0] == '0')
                {
                    centena = "cem";

                    if (numeroinvertido.Length > 3)
                    {
                        centena = " e cem";
                    }
                }

                else if (numeroinvertido.Length > 3)
                {
                    centena = " e " + centena;
                }

                else if (numeroinvertido.Length > 3 && numeroinvertido[2] != '1')
                {
                    centena = " e" + centena;
                }
            }

            // --------- Converte dezena de 10 a 19 ---------\\
            if (numeroinvertido.Length >= 2 && numeroinvertido[1] == '1')
            {
                dezena = Dezena2Get(numeroinvertido, 0, 2);

                if (numeroinvertido.Length > 2)
                {
                    dezena = " e " + dezena;
                }
            }

            // --------- Converte dezena ---------\\
            else if (numeroinvertido.Length >= 2 && numeroinvertido[1] != '0')
            {

                dezena = DezenaGet(numeroinvertido, 1);

                if (numeroinvertido.Length > 2)
                {
                    dezena = " e " + dezena;
                }
            }

            // --------- Converte unidade ---------\\
            if (numeroinvertido.Length >= 1 && numeroinvertido[0] != '0')
            {
                unidade = UnidadeOuMilharGet(numeroinvertido, 0);

                if (numeroinvertido.Length >= 2 && numeroinvertido[1] == '1')
                {
                    unidade = string.Empty;
                }

                if (numeroinvertido.Length > 1 && unidade != string.Empty)
                {
                    unidade = " e " + unidade;
                }
            }

            if (numeroinvertido.Length == 1 && numeroinvertido[0] == '0')
            {
                unidade = "zero";
            }

            extenso = mensagemerro + sinalmenos + dezenademilhar + milhar + centena + dezena + unidade;
        }

        // --------- Realiza a conversão para extenso ---------\\
        public string UnidadeOuMilharGet(string num, int pos)
        {
            string e = string.Empty;

            switch (num[pos])
            {
                case '1': e = "um"; break;
                case '2': e = "dois"; break;
                case '3': e = "três"; break;
                case '4': e = "quatro"; break;
                case '5': e = "cinco"; break;
                case '6': e = "seis"; break;
                case '7': e = "sete"; break;
                case '8': e = "oito"; break;
                case '9': e = "nove"; break;
                default: break;
            }
            return e;
        }
        public string DezenaGet(string num, int pos)
        {
            string e = string.Empty;

            switch (num[pos])
            {
                case '2': e = "vinte"; break;
                case '3': e = "trinta"; break;
                case '4': e = "quarenta"; break;
                case '5': e = "cinquenta"; break;
                case '6': e = "sessenta"; break;
                case '7': e = "setenta"; break;
                case '8': e = "oitenta"; break;
                case '9': e = "noventa"; break;
                default: break;
            }
            return e;
        }
        public string Dezena2Get(string num, int sub1, int sub2)
        {
            string e = string.Empty;

            switch (num.Substring(sub1, sub2))
            {
                case "01": e = "dez"; break;
                case "11": e = "onze"; break;
                case "21": e = "doze"; break;
                case "31": e = "treze"; break;
                case "41": e = "quatorze"; break;
                case "51": e = "quinze"; break;
                case "61": e = "dezesseis"; break;
                case "71": e = "dezessete"; break;
                case "81": e = "dezoito"; break;
                case "91": e = "dezenove"; break;
                default: break;
            }
            return e;
        }
        public string CentenaGet(string num, int pos)
        {
            string e = string.Empty;

            switch (num[pos])
            {
                case '1': e = "cento"; break;
                case '2': e = "duzentos"; break;
                case '3': e = "trezentos"; break;
                case '4': e = "quatrocentos"; break;
                case '5': e = "quinhentos"; break;
                case '6': e = "seissentos"; break;
                case '7': e = "setecentos"; break;
                case '8': e = "oitocentos"; break;
                case '9': e = "novecentos"; break;
                default: break;
            }
            return e;
        }
    }
}
