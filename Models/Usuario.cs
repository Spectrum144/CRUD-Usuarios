using System.Collections.Generic;
using System.Linq;

namespace UsandoViews.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        private static List<Usuario> listagem = new List<Usuario>();

        public static IQueryable<Usuario> Listagem{
            get{
                return listagem.AsQueryable();
            }
        }

        static Usuario() {
            Usuario.listagem.Add(new Usuario{IdUsuario = 1, Nome = "Fulano", Email = "fulano@gmail.com"}); //método para adicionar usuários em memória
            Usuario.listagem.Add(new Usuario{IdUsuario = 2, Nome = "Ciclano", Email = "ciclano@gmail.com"});
            Usuario.listagem.Add(new Usuario{IdUsuario = 3, Nome = "Beltrano", Email = "beltrano@gmail.com"});
        }

        public static void Salvar(Usuario usuario){
                var usuarioExistente = Usuario.listagem.Find(u => u.IdUsuario == usuario.IdUsuario);
                if(usuarioExistente != null){
                    usuarioExistente.Nome = usuario.Nome;
                    usuarioExistente.Email = usuario.Email;

                }else{
                    int maiorId = Usuario.Listagem.Max(u => u.IdUsuario);
                    usuario.IdUsuario = maiorId + 1;
                    Usuario.listagem.Add(usuario);
                }
            }

        public static bool Excluir(int idUsuario){
            var usuarioExistente = Usuario.listagem.Find(u => u.IdUsuario == idUsuario);
            if(usuarioExistente != null){
                return Usuario.listagem.Remove(usuarioExistente);
            }
            return false;
        }

        // public static void Excluir(int? id){
        //     if(id.HasValue && Usuario.Listagem.Any(u => u.IdUsuario == id)){
        //         var usuario = Usuario.Listagem.Single(u => u.IdUsuario == id);
        //         return View(usuario);
        //     }
        //     return RedirectToAction("Usuarios");
        // }
    }
}