using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Repositorios.Interfaces;
using System.Runtime.CompilerServices;
using WebApplication2.Models;

namespace SistemaDeTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemasTarefasDBContex _dBContex;
        private Func<object, bool> x;

        public UsuarioRepositorio(SistemasTarefasDBContex sistemasTarefasDBContex)
        {
            _dBContex = sistemasTarefasDBContex;
            
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dBContex.Usuarios.FirstOrDefaultAsync( x => x.id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dBContex.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
           await _dBContex.Usuarios.AddAsync(usuario);
           await _dBContex.SaveChangesAsync();

            return usuario;
        }
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if(usuarioPorId == null)
            {
                throw new Exception($"Usuário para ID: {id} não foi encontrado no banco de dados.");
            }

            usuarioPorId.Name = usuario.Name;
            usuarioPorId.Email = usuario.Email;

            _dBContex.Usuarios.Update(usuarioPorId);
            await _dBContex.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para ID: {id} não foi encontrado no banco de dados.");
            }
            _dBContex.Usuarios.Remove(usuarioPorId);
            await _dBContex.SaveChangesAsync();
            return true;
        }
     
    }
}
