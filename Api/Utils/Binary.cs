using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Utils
{
    public class Binary
    {
        /// <summary>
        /// Transforma um valor binário em uma string descriptografada
        /// e a retorna em um objeto 'Diff'
        /// </summary>
        /// <param name="diff">Objeto 'Diff' que contem um 'Value' criptografado</param>
        /// <returns>Retorna um objeto 'Diff' contendo um 'Value' descriptografado</returns>
        public static Diff BinaryToString(Diff diff)
        {
            List<Byte> byteList = new List<Byte>();

            diff.Value = diff.Value.Replace(" ", "");
            for (int i = 0; i < diff.Value.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(diff.Value.Substring(i, 8), 2));
            }

            diff.Value = Encoding.ASCII.GetString(byteList.ToArray());
            return diff;
        }
    }
}
