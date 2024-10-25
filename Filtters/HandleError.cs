

namespace MvcDay2Task.Filtters;

public class HandleError : Attribute, IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        ViewResult viewResult = new ViewResult();
        viewResult.ViewName = "Error";

        context.Result = viewResult;
    }
}

