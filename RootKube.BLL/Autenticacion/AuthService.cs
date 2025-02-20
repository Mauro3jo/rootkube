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

        // 🔹 Método para Autenticar Usuario y Registrar Sesión
        public (Usuario, int) AutenticarUsuario(string correo, string contraseña)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Correo == correo);
            if (usuario == null || usuario.Contraseña != HashContraseña(contraseña))
            {
                Console.WriteLine("❌ Usuario o contraseña incorrectos.");
                return (null, 0);
            }

            // Generar Token Seguro
            string token = GenerarToken();
            Token nuevoToken = new Token()
            {
                IdToken = Guid.NewGuid(),
                IdUsuario = usuario.IdUsuario,
                Token1 = token,
                FechaCreacion = DateTime.UtcNow,
                FechaExpiracion = DateTime.UtcNow.AddHours(5)
            };

            _context.Tokens.Add(nuevoToken);
            _context.SaveChanges();

            // 🔹 Registrar Sesión y devolver el ID de la sesión creada
            int idSesion = RegistrarSesion(usuario.IdUsuario);

            return (usuario, idSesion);
        }

        // 🔹 Método para Registrar Sesión y devolver el ID de la sesión
        private int RegistrarSesion(int idUsuario)
        {
            var sesion = new Sesione()
            {
                IdUsuario = idUsuario,
                FechaInicio = DateTime.UtcNow
            };

            _context.Sesiones.Add(sesion);
            _context.SaveChanges();

            return sesion.IdSesion; // 🔹 Retornamos el ID de la sesión creada
        }

        // 🔹 Método para Cerrar Sesión solo de la sesión activa
        public bool CerrarSesion(int idUsuario, int idSesion)
        {
            var sesionActiva = _context.Sesiones
                .FirstOrDefault(s => s.IdUsuario == idUsuario && s.IdSesion == idSesion && s.FechaFin == null);

            if (sesionActiva != null)
            {
                sesionActiva.FechaFin = DateTime.UtcNow;
                _context.SaveChanges();
                Console.WriteLine("✅ Sesión cerrada correctamente.");
                return true;
            }

            Console.WriteLine("⚠ No se encontró la sesión activa.");
            return false;
        }

        // 🔹 Método para Validar Token
        public bool ValidarToken(string token)
        {
            return _context.Tokens.Any(t => t.Token1 == token && t.FechaExpiracion > DateTime.UtcNow);
        }

        // 🔹 Método para Registrar Usuario
        public bool RegistrarUsuario(string nombre, string correo, string contraseña, string claveProducto, string rol, int? idLocal)
        {
            var claveValida = _context.ClavesProductos.FirstOrDefault(c => c.Clave == claveProducto);
            if (claveValida == null)
            {
                Console.WriteLine("❌ Clave de producto inválida. Registro denegado.");
                return false;
            }

            if (_context.Usuarios.Any(u => u.Correo == correo))
            {
                Console.WriteLine("❌ El correo ya está registrado.");
                return false;
            }

            // 🔹 Hash de la contraseña
            string contraseñaHash = HashContraseña(contraseña);

            Usuario nuevoUsuario = new Usuario()
            {
                Nombre = nombre,
                Correo = correo,
                Contraseña = contraseñaHash,
                Rol = rol,
                FechaCreacion = DateTime.UtcNow
            };

            _context.Usuarios.Add(nuevoUsuario);
            _context.SaveChanges();

            if (rol != "Administrador" && idLocal.HasValue)
            {
                UsuarioLocale nuevaRelacion = new UsuarioLocale()
                {
                    IdUsuario = nuevoUsuario.IdUsuario,
                    IdLocal = idLocal.Value
                };
                _context.UsuarioLocales.Add(nuevaRelacion);
                _context.SaveChanges();
            }

            Console.WriteLine("✅ Usuario registrado correctamente.");
            return true;
        }

        // 🔹 Método para Limpiar Tokens Expirados
        public void LimpiarTokensExpirados()
        {
            var tokensExpirados = _context.Tokens.Where(t => t.FechaExpiracion < DateTime.UtcNow).ToList();
            _context.Tokens.RemoveRange(tokensExpirados);
            _context.SaveChanges();
            Console.WriteLine($"🧹 {tokensExpirados.Count} tokens expirados eliminados.");
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

        // 🔹 Método para Generar Token Seguro
        private string GenerarToken()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }
    }
}
