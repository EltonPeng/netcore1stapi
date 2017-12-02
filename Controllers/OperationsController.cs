using Microsoft.AspNetCore.Mvc;
using netcore1stapi.Interfaces;
using netcore1stapi.Models;

namespace netcore1stapi.Controllers
{
    [Route("api/[controller]")]
    public class OperationsController : Controller 
    {
        private OperationCenter OperationCenter;

        private IOperationTransient OperationTransient;

        private IOperationScoped OperationScoped;

        private IOperationSingleton OperationSingleton;

        private IOperationSingletonInstance OperationSingletonInstance;

        public OperationsController(OperationCenter operationCenter,
            IOperationTransient operationTransient,
            IOperationScoped operationScoped,
            IOperationSingleton operationSingleton,
            IOperationSingletonInstance operationSingletonInstance)
        {
            OperationCenter = operationCenter;
            OperationTransient = operationTransient;
            OperationScoped = operationScoped;
            OperationSingleton = operationSingleton;
            OperationSingletonInstance = operationSingletonInstance;
        }

        ///this.HttpContext.RequestServices.GetService()
        ///Generally, you shouldn't use these properties directly, 
        ///preferring instead to request the types your classes 
        ///you require via your class's constructor, and 
        ///letting the framework inject these dependencies. 
        ///This yields classes that are easier to test (see Testing) 
        ///and are more loosely coupled.

        [HttpGet]
        public IActionResult Index()
        {
            var result = new { 
                sessionId = HttpContext.Session.Id,
                transient = OperationTransient.OperationId, 
                scoped = OperationScoped.OperationId,
                singleton = OperationSingleton.OperationId,
                singletonInstance = OperationSingletonInstance.OperationId,
                center_transient = OperationCenter.OperationTransient,
                center_scoped = OperationCenter.OperationScoped,
                center_singleton = OperationCenter.OperationSingleton,
                center_singletonInstance = OperationCenter.OperationSingletonInstance };

            return new ObjectResult(result);
        }
    }
}