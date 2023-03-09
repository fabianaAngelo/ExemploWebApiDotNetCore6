using ERP.Api.Configuration;
using ERP.Business.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinkSys.Api.Extensions
{
    /// <summary>
    /// Validação customizada para CPF
    /// </summary>
    public class CPFValidationAttribute : ValidationAttribute
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public CPFValidationAttribute() { }

        /// <summary>
        /// Validação server
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return true;

            return UsefulFunctions.ValidateCpf(value.ToString());
        }
    }
}
