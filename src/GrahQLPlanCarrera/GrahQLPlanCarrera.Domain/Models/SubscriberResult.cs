namespace GrahQLPlanCarrera.Domain.Models
{
    public class SubscriberResult<T>
    {
        public object Result { get; set; }
        public Action OnCompleted { get; set; }
        public Action<Exception> OnError { get; set; }
        public Action OnInitialized { get; set; }
        public Action<Product> OnNext { get; set; }
    }
}