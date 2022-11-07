using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Shared.Boxes;

public static class BoxDto
{
    public class Index
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
    }
    
    public class Detail : Index
    {

    }

    public class Mutate
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }

        public class Validator : AbstractValidator<Mutate>
        {
            public Validator()
            {
                RuleFor(x => x.CustomerId).NotEmpty();
                RuleFor(x => x.Name).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Name is required").Length(5, 250).WithMessage("Name length should be greater than 5");
                RuleFor(x => x.Width).InclusiveBetween(1, 250).WithMessage("Width should be between 1 and 250");
                RuleFor(x => x.Height).InclusiveBetween(1, 250).WithMessage("Height should be between 1 and 250");
                RuleFor(x => x.Length).InclusiveBetween(1, 250).WithMessage("Length should be between 1 and 250");
            }
        }
    }
}
