using Monitoramento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Monitoramento.Controllers
{
    public class HomeController : Controller
    {
        private Conta _conta;

        public HomeController()
        {
            try
            {
                _conta = (Conta)System.Web.HttpContext.Current.Session["conta"];
            }
            catch
            {
                _conta = new Conta();
            }

            if (_conta == null)
                _conta = new Conta();

            System.Web.HttpContext.Current.Session["conta"] = _conta;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendNumber(int? valor)
        {

            if (valor != null)
            {

                if (valor.Value > 100)
                {
                    var contaFinalizada = (Conta)System.Web.HttpContext.Current.Session["conta"];

                    _conta = null;

                    System.Web.HttpContext.Current.Session["conta"] = _conta;

                    ViewBag.Titulo = "Operação Finalizada";

                    return View("Monitor", contaFinalizada);
                }

                if (valor.Value % 2 == 0)
                    _conta.ListaNumPar.Add(valor.Value);
                else
                    _conta.ListaNumImpar.Add(valor.Value);

                System.Web.HttpContext.Current.Session["conta"] = _conta;

            }

            return RedirectToAction("Index");
        }

        public ActionResult Monitor()
        {
            ViewBag.Titulo = "Monitor";
            return View(_conta);
        }

    }
}