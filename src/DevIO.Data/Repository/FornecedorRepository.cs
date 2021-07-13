using DevIO.Business.Interfaces;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext context) : base(context) { }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedores.AsTracking().Include(c => c.Endereco).FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedores.AsTracking()
                .Include(c => c.Produtos)
                .Include(c => c.Endereco)
                .Include(c => c.Id)
                .FirstOrDefaultAsync(c => c.Id == id);

        }
    }
}
