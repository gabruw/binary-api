using Domain.DTO;
using Domain.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Api.Utils
{
    public class ResponseFactory
    {
        /// <summary>
        /// Padroniza o formato de saída da aplicação
        /// </summary>
        /// <param name="errors">Lista de erros a serem exibidas</param>
        /// <returns>Retorna uma string que contém os erros</returns>
        public static string GetResponse(List<string> errors)
        {
            Response response = new Response(errors);

            return JsonConvert.SerializeObject(response);
        }

        /// <summary>
        /// Padroniza o formato de saída da aplicação
        /// </summary>
        /// <param name="diffLeft">Objeto que contem os valores para comparação</param>
        /// <param name="diffRight">Objeto que contem os valores para comparação</param>
        /// <returns>Retorna uma string que contém os erros ou as observações</returns>
        public static string GetResponse(DiffLeft diffLeft, DiffRight diffRight)
        {
            if (diffLeft.isValid && diffRight.isValid)
            {
                Response response = new Response(diffLeft.Value, diffRight.Value);

                return JsonConvert.SerializeObject(response);
            }
            else
            {
                List<string> errors = diffLeft.GetValidationMessage;
                errors.AddRange(diffRight.GetValidationMessage);

                return GetResponse(errors);
            }
        }
    }
}
