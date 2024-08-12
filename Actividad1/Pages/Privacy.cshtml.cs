using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Actividad1.Pages
{
    public class PrivacyModel : PageModel
    {
        private const string FirstVisitKey = "FirstVisit";
        private const string PageReloadKey = "PageReloadCount";

        public int UserCount { get; set; }
        public int PageReloadCount { get; set; }
        public string Message { get; set; }

        public void OnGet()
        {
            // Contador de usuarios utilizando Session
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(FirstVisitKey)))
            {
                HttpContext.Session.SetString(FirstVisitKey, "Visited");

                // Obtener el valor actual de UserCount o establecerlo en 0 si es null
                int currentUserCount = HttpContext.Session.GetInt32("UserCounter") ?? 0;
                HttpContext.Session.SetInt32("UserCounter", currentUserCount + 1);
            }

            // Obtener el número total de usuarios que han accedido
            UserCount = HttpContext.Session.GetInt32("UserCounter") ?? 0;

            // Contador de recargas utilizando Session
            int currentPageReloadCount = HttpContext.Session.GetInt32(PageReloadKey) ?? 0;
            HttpContext.Session.SetInt32(PageReloadKey, currentPageReloadCount + 1);
            PageReloadCount = HttpContext.Session.GetInt32(PageReloadKey).Value;

            Message = PageReloadCount == 1
                ? "Hola Mundo - Es la primera vez que se ha cargado la página"
                : "Esta página ya ha sido visitada";
        }

        public void OnPost()
        {
            OnGet(); // Recargar la página
        }
    }

}
