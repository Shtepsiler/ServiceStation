﻿using Application.Operations.Jobs.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Validation
{
    public class CreateJobCommandValidator : AbstractValidator<CreateJobCommand>
    {
        public CreateJobCommandValidator()
        {
            RuleFor(request => request.ModelId)
                .NotEmpty()
                .WithMessage("Id can't be empty.")
                .NotNull()
                .WithMessage("Id can't be Null.");


            RuleFor(request => request.ManagerId)
                .NotEmpty()
                .WithMessage("Id can't be empty.")
                .NotNull()
                .WithMessage("Id can't be Null.");


            RuleFor(request => request.IssueDate)
                .NotEmpty()
                .WithMessage("Id can't be empty.")
                .NotNull()
                .WithMessage("Id can't be Null."); 
            
            RuleFor(request => request.Description)
                .NotEmpty()
                .WithMessage("Id can't be empty.")
                .NotNull()
                .WithMessage("Id can't be Null."); 
            
            RuleFor(request => request.ClientId)
                .NotEmpty()
                .WithMessage("Id can't be empty.")
                .NotNull()
                .WithMessage("Id can't be Null."); 
            
          


        }
    }
}