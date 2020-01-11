using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApi.Models.Validator
{
    public class ShowDateFilteredValidator: AbstractValidator<ShowDateFiltered>
    {
        public ShowDateFilteredValidator()
        {
            RuleFor(x => x).Must(IsValidDates).WithMessage(x=>"From and To dates neded");
        }

        private bool IsValidDates(ShowDateFiltered model)
        {
            var culture = GetCulture(model.Iso);
            DateTime fromDate;
            var isValidFrom = DateTime.TryParse(model.From, culture, DateTimeStyles.None, out fromDate);
            if(isValidFrom)
            {
                DateTime toDate;
                var isValidTo = DateTime.TryParse(model.To, culture, DateTimeStyles.None, out toDate);
                if(isValidTo)
                {
                    return toDate >= fromDate;
                }
                return isValidTo;
            }
            return isValidFrom;
        }
        
        private static CultureInfo GetCulture(string iso)
        {
            var culture = new CultureInfo("es", false);
            if (!string.IsNullOrWhiteSpace(iso))
            {
                culture = new CultureInfo(iso, false);
            }

            return culture;
        }
    }
}
