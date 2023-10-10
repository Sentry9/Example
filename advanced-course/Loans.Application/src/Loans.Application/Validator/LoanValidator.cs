using System.Text;
using Loans.Application.Base;
using Loans.Application.Limits;
using Microsoft.Extensions.Options;

namespace Loans.Application.Validator;

using System;
using System.Collections.Generic;

internal class LoanValidator : ILoanValidator
{
    private readonly LoanApplicationLimitsOptions _loanApplicationLimitsOptions;
    public LoanValidator(IOptions<LoanApplicationLimitsOptions> loanConfiguration)
    {
        _loanApplicationLimitsOptions = loanConfiguration.Value;
    }
    public void Validate(LoanApplicationModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Модель заявки на кредит не может быть null.");
        }
        var validationErrors = new List<string>();

        if (string.IsNullOrWhiteSpace(model.FirstName))
        {
            validationErrors.Add("Имя клиента обязательно для заполнения.");
        }

        if (string.IsNullOrWhiteSpace(model.LastName))
        {
            validationErrors.Add("Фамилия клиента обязательна для заполнения.");
        }

        if (string.IsNullOrWhiteSpace(model.MiddleName))
        {
            validationErrors.Add("Отчество клиента обязательно для заполнения.");
        }

        if (CalculateAge(model.BirthDate) < 18)
        {
            validationErrors.Add("Клиенту должно быть больше 18 лет.");
        }

        if (model.Salary <= 0)
        {
            validationErrors.Add("Зарплата должна быть положительным числом.");
        }

        if (model.DesiredAmount <= 0)
        {
            validationErrors.Add("Желаемая сумма кредита должна быть положительным числом.");
        }

        if (model.TermInYears <= 0)
        {
            validationErrors.Add("Срок кредита должен быть положительным числом.");
        }
        
        if (model.DesiredAmount < (double?)_loanApplicationLimitsOptions.MinLoanAmount)
        {
            validationErrors.Add($"Запрашиваемая сумма кредита слишком мала (минимум: {_loanApplicationLimitsOptions.MinLoanAmount}).");
        }

        if (model.DesiredAmount > (double?)_loanApplicationLimitsOptions.MaxLoanAmount)
        {
            validationErrors.Add($"Запрашиваемая сумма кредита слишком велика (максимум: {_loanApplicationLimitsOptions.MaxLoanAmount}).");
        }

        if (model.TermInYears < _loanApplicationLimitsOptions.MinLoanTermInYears)
        {
            validationErrors.Add($"Срок кредита слишком короткий (минимум: {_loanApplicationLimitsOptions.MinLoanTermInYears} лет).");
        }

        if (model.TermInYears > _loanApplicationLimitsOptions.MaxLoanTermInYears)
        {
            validationErrors.Add($"Срок кредита слишком длинный (максимум: {_loanApplicationLimitsOptions.MaxLoanTermInYears} лет).");
        }

        if (model.Salary < (double?)_loanApplicationLimitsOptions.MinSalary)
        {
            validationErrors.Add($"Зарплата клиента ниже минимальной (минимум: {_loanApplicationLimitsOptions.MinSalary}).");
        }

        if (validationErrors.Count > 0)
        {
            var errorsStringBuilder = new StringBuilder();
            foreach (string s in validationErrors)
            {
                errorsStringBuilder.Append(s);
                errorsStringBuilder.Append(' ');
            }
            throw new LoanValidationException(errorsStringBuilder.ToString());
        }
    }

    private int CalculateAge(DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;
        if (birthDate.Date > today.AddYears(-age))
        {
            age--;
        }
        return age;
    }
}
