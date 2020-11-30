using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arinsys.Components.AspNetCore
{
    public static class FormDefinitionExtensions
    {
        public static string GetPrefixedIdentifier<TFormDefinition>(this TFormDefinition formDefinition, string Identifier)
            where TFormDefinition : IBUIFormDefinition
        {
            return string.IsNullOrWhiteSpace(formDefinition.FormIdentifierPrefix) ? Identifier : $"{formDefinition.FormIdentifierPrefix}_{Identifier}";
        }
    }
}
