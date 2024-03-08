using Atividade1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atividade1.Controllers
{
    public class ConvidadoController : Controller
    {
        static List<Convidade> convidado = new List<Convidade>()
        {
            new Convidade
            {
                convidadoId = 1,
                Nome = "Felipe",
                EMail = "felipe@gmail.com",
                Telefone = "88392342",
                comparecimento = true,
            },
            new Convidade
            {
                convidadoId = 2,
                Nome = "João Pedro",
                EMail = "joaopedro@gmail.com",
                Telefone = "88392342",
                comparecimento = false,
            },
            new Convidade
            {
                convidadoId = 3,
                Nome = "João Marcelo",
                EMail = "joaomarcelo@gmail.com",
                Telefone = "88392342",
                comparecimento = true,
            }
        };
        public IActionResult Index()
        {
            return View(convidado);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Convidade conv)
        {
            conv.convidadoId = convidado.Select(x => x.convidadoId).Max() + 1;
            convidado.Add(conv);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(convidado.Where(x => x.convidadoId == id).First());
        }

        public IActionResult Edit(int id)
        {
            return View(convidado.Where(x => x.convidadoId == id).First());
        }

        [HttpPost]
        public IActionResult Edit(Convidade conv)
        {
            convidado.Remove(convidado.Where(x => x.convidadoId == conv.convidadoId).First());
            convidado.Add(conv);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(convidado.Where(x => x.convidadoId == id).First());
        }

        [HttpPost]
        public IActionResult Delete(Convidade conv)
        {
            convidado.Remove(convidado.Where(x => x.convidadoId == conv.convidadoId).First()); ;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public  IActionResult ListaConvidados()
        {
            return View(convidado.Where(x => x.comparecimento == true).ToList());
        }


    }
}
