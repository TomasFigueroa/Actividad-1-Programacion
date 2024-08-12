using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Actividad1.Pages
{
    public class IndexModel : PageModel
    {
        private const string FirstVisitKey = "FirstVisit";

        public string Message { get; set; }

        public void OnGet()
        {
            // Verifica si es la primera vez que se carga la página
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(FirstVisitKey)))
            {
                // Si es la primera vez, establece la sesión y muestra el mensaje inicial
                HttpContext.Session.SetString(FirstVisitKey, "Visited");
                Message = "Hola Mundo - Es la primera vez que se ha cargado la página";
            }
            else
            {
                // Si ya ha sido visitada, muestra el mensaje correspondiente
                Message = "Esta página ya ha sido visitada";
            }
        }

        public void OnPost()
        {
            // En caso de que se necesite manejar una recarga del formulario
            OnGet();
        }
    }
}
