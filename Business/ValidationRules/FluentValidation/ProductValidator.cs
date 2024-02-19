using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.ProductName).NotNull();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            //If we want to create an RuleFor Method we can do like below
            RuleFor(p => p.ProductName).Must(StartsWithA).WithMessage("Products should start wşth A letter");

        }

        private bool StartsWithA(string arg)
        {
            return arg.StartsWith("A");
        }


    }

}
