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
            RuleFor(x => x.From).NotEmpty().WithMessage(x=>"From date neded");
            RuleFor(x => x.To).NotEmpty().WithMessage(x => "To date neded");
            RuleFor(x => ValidateDateIso(x.From,x.Iso)).LessThan(x => ValidateDateIso(x.To, x.Iso)).WithMessage(x=>"Invalid date period");
        }
        
        private DateTime ValidateDateIso(string date, string iso)
        {
            //Futher control exceptions
            if(string.IsNullOrWhiteSpace(date))
            {
                return default(DateTime);
            }
            var culture = new CultureInfo("es", false);
            if(!string.IsNullOrWhiteSpace(iso))
            {
                culture = new CultureInfo(iso, false);
            }

            return DateTime.Parse(date, culture);
        }
    }
}
