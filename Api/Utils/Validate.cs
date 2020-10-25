using Domain.DTO;
using Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Api.Utils
{
    public class Validate
    {
        /// <summary>
        /// Padroniza o formato de saída da aplicação para um erro
        /// </summary>
        /// <param name="error">Erro a ser adicionado a saída</param>
        /// <returns>Retorna um objeto Response que contém os erros e as observações</returns>
        public static Response FormatError(string error)
        {
            List<string> errors = new List<string>();
            errors.Add(error);

            return new Response(errors);
        }

        /// <summary>
        /// Padroniza o formato de saída da aplicação para uma observação
        /// </summary>
        /// <param name="observation">Observação a ser adicionada a saída</param>
        /// <returns>Retorna um objeto Response que contém os erros e as observações</returns>
        public static Response FormatObservationRemove(Diff diff)
        {
            List<string> observations = new List<string>();

            observations.Add(string.Format("Valor {0} removido com sucesso.", diff.Value));
            return new Response(null, observations);

        }

        /// <summary>
        /// Padroniza o formato de saída da aplicação para somente um valor e o valida
        /// </summary>
        /// <param name="diff">Objeto que contem os valores para validação</param>
        /// <returns>Retorna um objeto Response que contém os erros e as observações</returns>
        public static Response FormatObservationInclude(Diff diff)
        {
            List<string> errors = new List<string>();
            List<string> observations = new List<string>();

            if (diff == null)
            {
                diff = new Diff();
                diff.Validate();
            }

            if (diff.isValid)
            {
                observations.Add(string.Format("Valor {0} adicionado com sucesso.", diff.Value));
                return new Response(errors, observations);
            }
            else
            {
                errors.AddRange(diff.GetValidationMessage);
                return new Response(errors);
            }
        }

        /// <summary>
        /// Padroniza o formato de saída da aplicação, valida e compara os valores com o intuito de
        /// recuperar os valores diferentes
        /// </summary>
        /// <param name="diffLeft">Objeto que contem os valores para validação</param>
        /// <param name="diffRight">Objeto que contem os valores para validação</param>
        /// <returns>Retorna um objeto Response que contém os erros e as observações</returns>
        public static Response VerifyDiff(DiffLeft diffLeft, DiffRight diffRight)
        {
            List<string> errors = new List<string>();
            List<string> observations = new List<string>();

            if (diffLeft == null)
            {
                diffLeft = new DiffLeft();
                diffLeft.Validate();
            }

            if (diffRight == null)
            {
                diffRight = new DiffRight();
                diffRight.Validate();
            }

            if (diffLeft.isValid && diffRight.isValid)
            {
                string leftValue = diffLeft.Value.ToLower();
                string rightValue = diffRight.Value.ToLower();

                if (leftValue.Equals(rightValue))
                {
                    observations.Add("Valor 'left' é idêntico ao valor 'right'.");
                }
                else
                {
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
                }

                return new Response(errors, observations);

            }
            else
            {
                errors.AddRange(diffLeft.GetValidationMessage);
                errors.AddRange(diffRight.GetValidationMessage);

                return new Response(errors);
            }
        }
    }
}
