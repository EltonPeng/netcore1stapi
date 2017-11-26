using Microsoft.AspNetCore.Mvc;
using netcore1stapi.Interfaces;
using netcore1stapi.Models;

namespace netcore1stapi.Controllers
{
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

        public IActionResult Index()
        {
            return new ObjectResult(OperationTransient.OperationId);
        }
    }
}