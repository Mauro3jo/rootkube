using System;
using System.Collections.Generic;
using System.Linq;
using RootKube.DAL.Contexto;
using RootKube.Models.Entidades;

namespace RootKube.BLL.Administracion
{
    public class LocalesService
    {
        private readonly RootKubeDbContext _context;

        public LocalesService()
        {
            _context = new RootKubeDbContext();
        }

        // 🔹 Obtener todos los locales
        public List<Locale> ObtenerLocales()
        {
            return _context.Locales.ToList();
        }

        // 🔹 Crear un nuevo local
        public bool CrearLocal(string nombre, string direccion)
        {
            if (_context.Locales.Any(l => l.Nombre == nombre))
                return false; // Ya existe un local con este nombre

            Locale nuevoLocal = new Locale
            {
                Nombre = nombre,
                Direccion = direccion
            };

            _context.Locales.Add(nuevoLocal);
            _context.SaveChanges();
            return true;
        }

        // 🔹 Modificar un local existente
        public bool ModificarLocal(int idLocal, string nombre, string direccion)
        {
            var local = _context.Locales.FirstOrDefault(l => l.IdLocal == idLocal);
            if (local == null) return false;

            local.Nombre = nombre;
            local.Direccion = direccion;
            _context.SaveChanges();
            return true;
        }

        // 🔹 Eliminar un local
        public bool EliminarLocal(int idLocal)
        {
            var local = _context.Locales.FirstOrDefault(l => l.IdLocal == idLocal);
            if (local == null) return false;

            _context.Locales.Remove(local);
            _context.SaveChanges();
            return true;
        }
    }
}
