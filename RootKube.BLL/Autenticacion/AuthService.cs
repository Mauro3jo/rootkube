using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using RootKube.DAL.Contexto;
using RootKube.Models.Entidades;

namespace RootKube.BLL.Autenticacion
{
    public class AuthService
    {
        private readonly RootKubeDbContext _context;

        public AuthService()
        {
            _context = new RootKubeDbContext();
        }

        // 🔹 Método para Autenticar Usuario y Generar Token
        public Usuario AutenticarUsuario(string correo, string contraseña)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Correo == correo);
            if (usuario == null || usuario.Contraseña != HashContraseña(contraseña))
            {
                Console.WriteLine("❌ Usuario o contraseña incorrectos.");
                return null;
            }

            // Generar Token
            string token = GenerarToken();
            Token nuevoToken = new Token()
            {
                IdToken = Guid.NewGuid(),
                IdUsuario = usuario.IdUsuario,
                Token1 = token,
                FechaCreacion = DateTime.Now,
                FechaExpiracion = DateTime.Now.AddHours(5)
            };

            _context.Tokens.Add(nuevoToken);
            _context.SaveChanges();

            return usuario; // 🔹 Devuelve el usuario en vez de solo un token
        }


        // 🔹 Método para Validar Token
        public bool ValidarToken(string token)
        {
            return _context.Tokens.Any(t => t.Token1 == token && t.FechaExpiracion > DateTime.Now);
        }

        // 🔹 Método para Registrar Usuario (con local si no es administrador)
        public bool RegistrarUsuario(string nombre, string correo, string contraseña, string claveProducto, string rol, int? idLocal)
        {
            // 🔸 Verificar si la clave del producto es válida
            var claveValida = _context.ClavesProductos.FirstOrDefault(c => c.Clave == claveProducto);
            if (claveValida == null)
            {
                Console.WriteLine("❌ Clave de producto inválida. Registro denegado.");
                return false;
            }

            // 🔸 Verificar si el usuario ya existe por correo
            if (_context.Usuarios.Any(u => u.Correo == correo))
            {
                Console.WriteLine("❌ El correo ya está registrado.");
                return false;
            }

            // 🔸 Hash de la contraseña antes de guardarla
            string contraseñaHash = HashContraseña(contraseña);

            // 🔸 Crear nuevo usuario
            Usuario nuevoUsuario = new Usuario()
            {
                Nombre = nombre,
                Correo = correo,
                Contraseña = contraseñaHash,
                Rol = rol,
                FechaCreacion = DateTime.Now
            };

            _context.Usuarios.Add(nuevoUsuario);
            _context.SaveChanges(); // Guardar primero el usuario para obtener su ID

            // 🔸 Si el usuario NO es Administrador, se asigna a un local
            if (rol != "Administrador" && idLocal.HasValue)
            {
                UsuarioLocale nuevaRelacion = new UsuarioLocale()
                {
                    IdUsuario = nuevoUsuario.IdUsuario,
                    IdLocal = idLocal.Value
                };
                _context.UsuarioLocales.Add(nuevaRelacion);
                _context.SaveChanges(); // Guardar la relación usuario-local
            }

            Console.WriteLine("✅ Usuario registrado correctamente.");
            return true;
        }

        // 🔹 Método para Hash de Contraseñas
        private string HashContraseña(string contraseña)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        // 🔹 Método para Generar Token Aleatorio
        private string GenerarToken()
        {
            return Guid.NewGuid().ToString();
        }
        public bool ValidarCredenciales(Usuario usuario, string contraseña)
        {
            return usuario.Contraseña == HashContraseña(contraseña);
        }

    }
}
