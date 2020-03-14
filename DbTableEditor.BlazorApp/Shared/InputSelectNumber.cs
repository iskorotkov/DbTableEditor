using System;
using Microsoft.AspNetCore.Components.Forms;

namespace DbTableEditor.BlazorApp.Shared
{
    public class InputSelectNumber<TValue> : InputSelect<TValue>
    {
        protected override bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage)
        {
            if (typeof(TValue) == typeof(int))
            {
                if (int.TryParse(value, out var resultInt))
                {
                    result = (TValue)(object)resultInt;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationErrorMessage = "The chosen value is not a valid number.";
                    return false;
                }
            }
            else
            {
                throw new InvalidOperationException($"{GetType()} does not support the type '{typeof(TValue)}'.");
            }
        }
    }
}
