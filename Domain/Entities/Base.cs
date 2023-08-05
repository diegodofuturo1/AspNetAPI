using System.Text;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System;

namespace Domain.Entities
{
    public abstract class Base
    {
        public long Id { get; set; }
        public bool Active { get; set; } = true;

        internal List<string> _errors;

        public IReadOnlyCollection<string> Errors => _errors;

        public bool IsValid => _errors.Count == 0;

        private void AddErrorList(IList<ValidationFailure> errors)
        {
            foreach (var error in errors)
                _errors.Add(error.ErrorMessage);
        }

        private void CleanErrors()
            => _errors.Clear();

        protected bool Validate<T, J>(T validator, J obj) where T : AbstractValidator<J>
        {
            CleanErrors();

            var validation = validator.Validate(obj);

            if (validation.Errors.Count > 0)
                AddErrorList(validation.Errors);

            return _errors.Count == 0;
        }

        public string ErrorsToString()
        {
            var builder = new StringBuilder();

            foreach (var error in _errors)
                builder.Append(" " + error);

            return builder.ToString();
        }

    }
}
