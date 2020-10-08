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
        string numero = string.Empty;

        public Numero(string id)
        {
            numero = id;
        }
        public void EscreveNumero()
        {
            ConverteNumero();
        }
        public void ConverteNumero()
        {
            string numeroinvertido = new string(numero.Reverse().ToArray());
            string sinalmenos = string.Empty;
            string aux = string.Empty;
            char[] chararray;

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
            }

            chararray = numeroinvertido.ToCharArray(0, numeroinvertido.Length);

            foreach (char c in chararray)
            {
                if (!char.IsNumber(c))
                {
                    numeroinvertido = string.Empty;
                    extenso = "O valor digitado é inválido";
                    break;
                }
            }


            if (numeroinvertido.Length == 5 && numeroinvertido[4] == '1')
            {
                switch (numero.Substring(0, 2))
                {
                    case "10": dezenademilhar = "dez"; break;
                    case "11": dezenademilhar = "onze"; break;
                    case "12": dezenademilhar = "doze"; break;
                    case "13": dezenademilhar = "treze"; break;
                    case "14": dezenademilhar = "quatorze"; break;
                    case "15": dezenademilhar = "quinze"; break;
                    case "16": dezenademilhar = "dezesseis"; break;
                    case "17": dezenademilhar = "dezessete"; break;
                    case "18": dezenademilhar = "dezoito"; break;
                    case "19": dezenademilhar = "dezenove"; break;
                    default: break;
                }

                dezenademilhar = dezenademilhar + " mil";
            }

            else if (numeroinvertido.Length == 5 && numeroinvertido[4] != '0')
            {
                switch (numeroinvertido[4])
                {
                    case '1': dezenademilhar = "dez"; break;
                    case '2': dezenademilhar = "vinte"; break;
                    case '3': dezenademilhar = "trinta"; break;
                    case '4': dezenademilhar = "quarenta"; break;
                    case '5': dezenademilhar = "cinquenta"; break;
                    case '6': dezenademilhar = "sessenta"; break;
                    case '7': dezenademilhar = "setenta"; break;
                    case '8': dezenademilhar = "oitenta"; break;
                    case '9': dezenademilhar = "noventa"; break;
                    default: break;
                }

                if (numeroinvertido[3] == '0')
                {
                    dezenademilhar = dezenademilhar + " mil";
                }
            }

            if (numeroinvertido.Length >= 4 && numeroinvertido[3] != '0')
            {
                switch (numeroinvertido[3])
                {
                    case '1': milhar = "um"; break;
                    case '2': milhar = "dois"; break;
                    case '3': milhar = "três"; break;
                    case '4': milhar = "quatro"; break;
                    case '5': milhar = "cinco"; break;
                    case '6': milhar = "seis"; break;
                    case '7': milhar = "sete"; break;
                    case '8': milhar = "oito"; break;
                    case '9': milhar = "nove"; break;
                    default: break;
                }

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

            if (numeroinvertido.Length >= 3 && numeroinvertido[2] != '0')
            {
                switch (numeroinvertido[2])
                {
                    case '1': centena = "cento"; break;
                    case '2': centena = "duzentos"; break;
                    case '3': centena = "trezentos"; break;
                    case '4': centena = "quatrocentos"; break;
                    case '5': centena = "quinhentos"; break;
                    case '6': centena = "seissentos"; break;
                    case '7': centena = "setecentos"; break;
                    case '8': centena = "oitocentos"; break;
                    case '9': centena = "novecentos"; break;
                    default: break;
                }

                if (numeroinvertido.Length > 3)
                {
                    centena = " " + centena;
                }

                else if (numeroinvertido[2] == '1' && numeroinvertido[1] == '0' && numeroinvertido[0] == '0')
                {
                    centena = "cem";

                    if (numeroinvertido.Length > 3)
                    {
                        centena = " e cem";
                    }
                }

                else if (numeroinvertido.Length > 3 && numeroinvertido[2] != '1')
                {
                    centena = " e" + centena;
                }
            }

            if (numeroinvertido.Length >= 2 && numeroinvertido[1] == '1')
            {
                switch (numeroinvertido.Substring(0, 2))
                {
                    case "01": dezena = "dez"; break;
                    case "11": dezena = "onze"; break;
                    case "21": dezena = "doze"; break;
                    case "31": dezena = "treze"; break;
                    case "41": dezena = "quatorze"; break;
                    case "51": dezena = "quinze"; break;
                    case "61": dezena = "dezesseis"; break;
                    case "71": dezena = "dezessete"; break;
                    case "81": dezena = "dezoito"; break;
                    case "91": dezena = "dezenove"; break;
                    default: break;
                }

                if (numeroinvertido.Length > 2)
                {
                    dezena = " e " + dezena;
                }
            }

            if (numeroinvertido.Length >= 2 && numeroinvertido[1] != '0')
            {
                switch (numeroinvertido[1])
                {
                    case '2': dezena = "vinte"; break;
                    case '3': dezena = "trinta"; break;
                    case '4': dezena = "quarenta"; break;
                    case '5': dezena = "cinquenta"; break;
                    case '6': dezena = "sessenta"; break;
                    case '7': dezena = "setenta"; break;
                    case '8': dezena = "oitenta"; break;
                    case '9': dezena = "noventa"; break;
                    default: break;
                }

                if (numeroinvertido.Length > 2)
                {
                    dezena = " e " + dezena;
                }
            }

            if (numeroinvertido.Length >= 1)
            {
                switch (numeroinvertido[0])
                {
                    case '1': unidade = "um"; break;
                    case '2': unidade = "dois"; break;
                    case '3': unidade = "três"; break;
                    case '4': unidade = "quatro"; break;
                    case '5': unidade = "cinco"; break;
                    case '6': unidade = "seis"; break;
                    case '7': unidade = "sete"; break;
                    case '8': unidade = "oito"; break;
                    case '9': unidade = "nove"; break;
                    default: break;
                }

                if (numeroinvertido.Length >= 2 && numeroinvertido[1] == '1')
                {
                    unidade = string.Empty;
                }

                else if (numeroinvertido.Length > 1 && unidade != string.Empty)
                {
                    unidade = " e " + unidade;
                }
            }

            extenso = sinalmenos + dezenademilhar + milhar + centena + dezena + unidade;
        }

    }
}
