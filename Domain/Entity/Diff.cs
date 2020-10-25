namespace Domain.Entity
{
    public class Diff : Base
    {
        public long Id { get; set; }

        public string Value { get; set; }

        public override void Validate()
        {
            ClearValidationMessage();

            if (string.IsNullOrWhiteSpace(Value))
            {
                AddError("Atributo 'value' é obrigatório.");
            }
        }
    }
}
