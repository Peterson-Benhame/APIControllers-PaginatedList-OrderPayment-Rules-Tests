using Microsoft.AspNetCore.Mvc;
using ProvaPub.Services;

namespace ProvaPub.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class Parte1Controller :  ControllerBase
	{
		private readonly RandomService _randomService;

		public Parte1Controller(RandomService randomService)
		{
			_randomService = randomService;
		}

		/// <summary>
		/// Traz um número aleatório
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public int Index()
		{
			return _randomService.GetRandom();
		}
	}
}
