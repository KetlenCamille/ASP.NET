using Ecommerce.DAO;

namespace Ecommerce.Controllers
{
    public class Singleton
    {
        private static Context contexto;

        private Singleton()
        {

        }
        public static Context GetInstance()
        {
            if (contexto == null)
                contexto = new Context();

            return contexto;
        }
    }
}