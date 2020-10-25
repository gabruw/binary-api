using System.Collections.Generic;
using System.Linq;

namespace Domain.DTO
{
    public class Response
    {
        public Response()
        {
            
        }

        public Response(List<string> errors)
        {
            this.Errors = errors;
        }

        public Response(string leftValue, string rightValue)
        {
            this.Observations = VerifyValues(leftValue, rightValue);
        }

        public List<string> Errors { get; set; }
        public List<string> Observations { get; set; }

        /// <summary>
        /// Compara os dois valores e verifica se os mesmos são idênticos ou do mesmo tamanho.
        /// </summary>
        /// <param name="leftValue">Valor a ser comparado</param>
        /// <param name="rightValue">Valor a ser comparado</param>
        /// <returns>Uma lista com as observações verificadas</returns>
        private List<string> VerifyValues(string leftValue, string rightValue)
        {
            List<string> observations = new List<string>();
            
            leftValue = leftValue.ToLower();
            rightValue = rightValue.ToLower();

            if (leftValue.Equals(rightValue))
            {
                observations.Add("Valor 'left' é idêntico ao valor 'right'.");
                return observations;
            }

            if (leftValue.Length == rightValue.Length)
            {
                observations.Add("Tamanho do valor 'left' é idêntico ao tamanho do valor 'right'.");
            }

            char[] leftChar = leftValue.ToCharArray();
            char[] rightChar = rightValue.ToCharArray();

            var differences = leftChar.Except(rightChar);
            foreach (var diff in differences)
            {
                observations.Add(string.Format("O valor '{0}' não está presente em ambos.", diff));
            }

            return observations;
        }
    }
}
