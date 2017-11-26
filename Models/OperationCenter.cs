using netcore1stapi.Interfaces;

namespace netcore1stapi.Models 
{
    public class OperationCenter 
    {
        public IOperationTransient OperationTransient { get; }

        public IOperationScoped OperationScoped { get; }

        public IOperationSingleton OperationSingleton { get; }

        public IOperationSingletonInstance OperationSingletonInstance { get; }

        public OperationCenter(IOperationTransient operationTransient,
        IOperationScoped operationScoped,
        IOperationSingleton operationSingleton,
        IOperationSingletonInstance operationSingletonInstance)
        {
            OperationTransient = operationTransient;
            OperationScoped = operationScoped;
            OperationSingleton = operationSingleton;
            OperationSingletonInstance = operationSingletonInstance;
        }
    }
}