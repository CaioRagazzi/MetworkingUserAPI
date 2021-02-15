using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace MetWorkingUserApplication.Contracts.Response
{
    public class BaseResponse<T>
    {
        public Errors Errors { get; set; }
        public bool IsOk { get; set; }
        public T Data { get; set; }

        public BaseResponse()
        {
            Errors = new Errors {data = new List<string>()};
            IsOk = true;
        }

        public BaseResponse(T model, IEnumerable<ValidationFailure> failures)
        {
            Errors = new Errors {data = new List<string>()};
            IsOk = true;
            SetValidationErrors(failures);
        }

        public void SetIsOk(T result)
        {
            Data = result;
        }

        public void SetIsForbidden()
        {
            IsOk = false;
            Errors.IsForbbiden = true;
        }

        public void SetValidationErrors(IEnumerable<string> errors = null)
        {
            IsOk = false;
            Errors.IsForbbiden = false;
            Errors.data = errors?.ToList();
        }
        
        public void SetValidationErrors(IEnumerable<ValidationFailure> validationFailures)
        {
            IsOk = false;
            Errors.IsForbbiden = false;

            foreach (var failure in validationFailures)
            {
                Errors.data.Add(failure.ErrorMessage);
            }
            
        }
    }

    public class Errors
    {
        public bool IsForbbiden { get; set; }
        public List<string> data { get; set; }
    }
}