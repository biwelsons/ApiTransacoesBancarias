using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTransacoesBancarias
{




    [Route("api/[controller]")]
    [ApiController]

    public class TransacaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransacaoController(AppDbContext context)
        {
            _context = context;
        }


        // GET: api/Transacao
        [HttpGet]
        [Authorize]

        public async Task<ActionResult<IEnumerable<Transacao>>> GetTransacoes()
        {
            return await _context.Transacoes.ToListAsync();
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Transacao>> GetTransacao(int id)
        {
            var transacao = await _context.Transacoes.FindAsync(id);

            if (transacao == null)
            {
                return NotFound();
            }

            return transacao;
        }

        // POST: api/Transacao
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Transacao>> PostTransacao(Transacao transacao)
        {
            _context.Transacoes.Add(transacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTransacao), new { id = transacao.Id }, transacao);
        }

        // PUT: api/Transacao/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutTransacao(int id, [FromBody] Transacao transacao)
        {
            if (id != transacao.Id)
            {
                return BadRequest("Transação não encontrada");
            }

            var transacaoExistente = await _context.Transacoes.FindAsync(id);

            if (transacaoExistente == null)
            {
                return NotFound("Id Inexistente");
            }

            if (transacao.DataHora != default)
            {
                transacaoExistente.DataHora = transacao.DataHora;
            }

            if (!string.IsNullOrEmpty(transacao.ModoTransacao))
            {
                transacaoExistente.ModoTransacao = transacao.ModoTransacao;
            }

            if (!string.IsNullOrEmpty(transacao.Categoria))
            {
                transacaoExistente.Categoria = transacao.Categoria;
            }

            if (!string.IsNullOrEmpty(transacao.NotaObservacao))
            {
                transacaoExistente.NotaObservacao = transacao.NotaObservacao;
            }

            if (!string.IsNullOrEmpty(transacao.TipoTransacao))
            {
                transacaoExistente.TipoTransacao = transacao.TipoTransacao;
            }

            if (transacao.Valor != default)
            {
                transacaoExistente.Valor = transacao.Valor;
            }


            _context.Entry(transacaoExistente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransacaoExists(id))
                {
                    return NotFound("Id inexistente");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Atualização bem sucedida");
        }


        // DELETE: api/Transacao/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTransacao(int id)
        {
            var transacao = await _context.Transacoes.FindAsync(id);
            if (transacao == null)
            {
                return NotFound();
            }

            _context.Transacoes.Remove(transacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransacaoExists(int id)
        {
            return _context.Transacoes.Any(e => e.Id == id);
        }


        [HttpDelete("Estorno/{id}")]
        [Authorize]
        public async Task<ActionResult> EstornarTransacao(int id)
        {
            var transacaoExistente = await _context.Transacoes.FindAsync(id);

            if (transacaoExistente == null)
            {
                return NotFound("Transação não encontrada.");
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var estorno = new Transacao
                    {
                        DataHora = DateTime.Now,
                        ModoTransacao = transacaoExistente.ModoTransacao,
                        Categoria = transacaoExistente.Categoria,
                        NotaObservacao = transacaoExistente.NotaObservacao + " Estorno da transação ID: " + transacaoExistente.Id,
                        Valor = transacaoExistente.Valor,
                        TipoTransacao = (transacaoExistente.TipoTransacao == "Receita") ? "Despesa" : "Receita"
                    };

                    _context.Transacoes.Add(estorno);

                    await _context.SaveChangesAsync();
                    transaction.Commit();

                    return Ok("Transação estornada com sucesso.");
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return StatusCode(500, "Erro ao estornar a transação.");
                }
            }
        }


        [HttpPut("Estorno/{id}")]
        [Authorize]
        public async Task<IActionResult> EstornarATransacao(int id)
        {
            var transacaoExistente = await _context.Transacoes.FindAsync(id);

            if (transacaoExistente == null)
            {
                return NotFound("Transação não encontrada.");
            }

            // Modificar os detalhes da transação para representar um estorno
            transacaoExistente.DataHora = DateTime.Now;
            transacaoExistente.NotaObservacao = transacaoExistente.NotaObservacao + " Estorno da transação ID: " + transacaoExistente.Id;
            transacaoExistente.Valor = transacaoExistente.Valor;
            transacaoExistente.TipoTransacao = (transacaoExistente.TipoTransacao == "Receita") ? "Despesa" : "Receita";

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Transação estornada com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao estornar a transação.");
            }
        }


        [HttpGet("FiltrarTransacoes")]
        [Authorize]
        public ActionResult<IEnumerable<Transacao>> FiltrarTransacoes([FromBody] FiltroTransacao filtro)
        {
            IQueryable<Transacao> query = _context.Transacoes.AsQueryable();

            // Filtrar por modo de transação
            if (!string.IsNullOrEmpty(filtro.ModoTransacao))
            {
                query = query.Where(t => t.ModoTransacao == filtro.ModoTransacao);
            }

            // Filtrar por categoria
            if (!string.IsNullOrEmpty(filtro.Categoria))
            {
                query = query.Where(t => t.Categoria == filtro.Categoria);
            }

            // Filtrar por nota/observação
            if (!string.IsNullOrEmpty(filtro.NotaObservacao))
            {
                query = query.Where(t => t.NotaObservacao == filtro.NotaObservacao);
            }

            // Filtrar por valor
            if (filtro.Valor.HasValue)
            {
                if (filtro.TipoValor == "maior")
                {
                    query = query.Where(t => t.Valor > filtro.Valor.Value);
                }
                else if (filtro.TipoValor == "menor")
                {
                    query = query.Where(t => t.Valor < filtro.Valor.Value);
                }
            }

            // Filtrar por tipo de transação
            if (!string.IsNullOrEmpty(filtro.TipoTransacao))
            {
                query = query.Where(t => t.TipoTransacao == filtro.TipoTransacao);
            }

            // Filtrar por data
            if (!string.IsNullOrEmpty(filtro.Data))
            {
                if (filtro.Data.Length == 4) // Ano
                {
                    if (int.TryParse(filtro.Data, out int year))
                    {
                        query = query.Where(t => t.DataHora.Year == year);
                    }
                }
                else if (filtro.Data.Length == 7) // Ano e mês
                {
                    if (DateTime.TryParse(filtro.Data, out DateTime parsedDate))
                    {
                        query = query.Where(t => t.DataHora.Year == parsedDate.Year && t.DataHora.Month == parsedDate.Month);
                    }
                }
                else if (filtro.Data.Length == 10) // Data completa
                {
                    if (DateTime.TryParse(filtro.Data, out DateTime parsedDate))
                    {
                        query = query.Where(t => t.DataHora.Date == parsedDate.Date);
                    }
                }
            }

            var result = query.ToList();
            return Ok(result);
        }


    }
}