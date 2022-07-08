using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Desafio.AMcom.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TemperaturasController : ControllerBase
{
    private readonly ILogger<TemperaturasController> _logger;
    private readonly IMemoryCache _memoryCache;

    public TemperaturasController(ILogger<TemperaturasController> logger, IMemoryCache memoryCache)
    {
        _logger = logger;
        _memoryCache = memoryCache;
    }

    [HttpGet("Fahrenheit/{temperatura:decimal}")]
    public ActionResult GetConversaoFahrenheit(decimal temperatura)
    {
        try
        {
            _logger.LogInformation($"Recebida temperatura para conversão: {temperatura}");
            string dados = _memoryCache.GetOrCreate(temperatura, k =>
            {
                Temperatura temp = temperatura;
                return _memoryCache.Set(k, temp.ToString(), TimeSpan.FromMinutes(50));
            });

            _logger.LogInformation($"Resultado concluído: {dados}");
            return Ok(dados);
        }
        catch (Exception err)
        {
            _logger.LogError(err, "Ocorreu um problema ao converter");
            return BadRequest(err);
        }
    }

    [HttpPost("txt")]
    public ActionResult SalvaTemperaturatxt(TemperaturaModel temperatura)
    {
        try
        {
            string dados = _memoryCache.GetOrCreate(temperatura.ValorFahrenheit, k =>
            {
                Temperatura temp = temperatura.ValorFahrenheit;
                UtilidadesArquivo.EscrevaTemperaturaTxt(temp);
                return _memoryCache.Set(k, temp.ToString(), TimeSpan.FromMinutes(50));
            });

            return Ok(dados);
        }
        catch (Exception err)
        {
            _logger.LogError(err, "Ocorreu um problema ao escrever arquivo");
            return BadRequest(err);
        }
    }

    private static readonly IEnumerable<Pais> _paises = _paises = UtilidadesArquivo.LeiaTemperaturaTxt();

    [HttpGet("paises")]
    public ActionResult RetornaPaises([FromQuery] int page = 1, [FromQuery] int pageSize = 10, string nomePais = default)
    {
        var paises = _paises.Where(p => p.Nome_pais.PesquisaPartes(nomePais)).Skip((page - 1) * pageSize).Take(pageSize);
        return Ok(paises);
    }

    [HttpGet("pais-por-sigla/{sigla:alpha}")]
    public ActionResult RetornaPaisPorSigla([StringLength(2)] string sigla)
    {
        var pais = _paises.FirstOrDefault(m => m.Sigla.Equals(sigla.ToUpper()));
        if (pais == null) NotFound();
        return Ok(pais);
    }
}