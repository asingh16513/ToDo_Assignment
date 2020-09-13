using Ninject;

namespace Application.Helper
{
    public class GetInstance
    {
        public static readonly IKernel Kernel;

        static GetInstance()
        {
            if (Kernel == null) Kernel = new StandardKernel(new DependencyResolver());
        }

        /// <summary>
        /// Generic method to get any type of db class from factory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
