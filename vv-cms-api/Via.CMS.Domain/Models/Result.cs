namespace Via.CMS.Domain.Models
{
    public class Result<T>
    {
        public string[] Messages { get; private set; }
        public T Value { get; private set; }
        public bool Success { get => Messages == null || Messages.Length == 0; }

        public static Result<T> CreateSuccess(T value)
        {
            return new Result<T>()
            {
                Value = value
            };
        }

        public static Result<T> CreateFailure(string message)
        {
            return CreateFailure(new[] { message });
        }

        public static Result<T> CreateFailure(string[] messages)
        {
            return new Result<T>()
            {
                Messages = messages
            };
        }
    }
}
