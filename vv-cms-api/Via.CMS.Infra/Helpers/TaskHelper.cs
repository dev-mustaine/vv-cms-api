using System.Threading;

namespace Via.CMS.Infra.Helpers
{
    public static class TaskHelper
    {
        public static CancellationToken NovoToken(int milliseconds = 40000) => new CancellationTokenSource(milliseconds).Token;

    }
}
