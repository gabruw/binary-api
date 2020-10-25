using System.Linq;
using System.Collections.Generic;

namespace Domain.Entity
{
    public abstract class Base
    {
        private List<string> ValidationMessage = new List<string>();

        public List<string> GetValidationMessage
        {
            get
            {
                return ValidationMessage ?? (ValidationMessage = new List<string>());
            }
        }

        protected void ClearValidationMessage()
        {
            ValidationMessage.Clear();
        }

        protected void AddError(string message)
        {
            ValidationMessage.Add(message);
        }

        public abstract void Validate();

        public bool isValid
        {
            get
            {
                return !ValidationMessage.Any();
            }
        }
    }
}