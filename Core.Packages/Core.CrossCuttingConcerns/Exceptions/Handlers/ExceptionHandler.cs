using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Core.CrossCuttingConcerns.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    //Fırlatılan exception BusinessException türündeyse HandleException metodunu çalıştır değilse HandleException metodunun Exception parametresi alan versiyonunu çalıştır.
    //Method overloading
    public Task HandleExceptionAsync(Exception exception) => exception switch
    {
        BusinessException businessException => HandleException(businessException),
        ValidationException validationException => HandleException(validationException),
        _ => HandleException(exception),
    };

    protected abstract Task HandleException(BusinessException businessException);
    protected abstract Task HandleException(ValidationException businessException);
    protected abstract Task HandleException(Exception exception);
}